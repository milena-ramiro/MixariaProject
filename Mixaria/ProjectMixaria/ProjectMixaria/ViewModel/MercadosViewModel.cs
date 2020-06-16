using ProjectMixaria.Model;
using ProjectMixaria.Servicos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProjectMixaria.ViewModel
{
    public class MercadosViewModel : INotifyPropertyChanged
    {

        #region CAMPOS

       
        private string _corConexao;
        public string CorConexao
        {
            get { return _corConexao; }
            set
            {
                _corConexao = value;
                OnPropertyChanged("CorConexao");
            }
        }

        private string _statusConexao;
        public string StatusConexao
        {
            get { return _statusConexao; }
            set
            {
                _statusConexao = value;
                OnPropertyChanged("StatusConexao");
            }
        }

        private bool _isConected;
        public bool IsConected
        {
            get { return _isConected; }
            set
            {
                _isConected = value;
                OnPropertyChanged("IsConected");
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }


        public IEnumerable<tbPromocao> Produtos_Mercado { get; set; }

        private ObservableCollection<tbEstab> _estabs;
        public ObservableCollection<tbEstab> Estabelecimentos
        {
            get
            {
                return _estabs;
            }
            set
            {
                _estabs = value;
                OnPropertyChanged("Estabelecimentos");
            }
        }

        public ICommand SelectedItemMercado => new Command<tbEstab>(GoPaginaProdutos);
        private tbEstab _estab { get; set; }

        #endregion

        #region METODOS

        private async void GoPaginaProdutos(tbEstab estab)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                if (estab != null )
                {
                    _estab = estab;
                    await ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.MercadoSelecionadoPage(_estab));
                }
            }
            else
            {
                await ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.Erro());
            }

        }

        public MercadosViewModel()
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;


            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                Task.Run(() => CarregarMercados());
            }
            else
            {
                Bufferizador();
            }

        }

        private void Bufferizador()
        {
            Estabelecimentos = ServiceWS.estabs;
            SemInternet();
        }

        

        ~MercadosViewModel()
        {
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }


        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess == NetworkAccess.Internet)
            {
                Conectando();
                Task.Run(() => CarregarMercados());
            }
            else
            {
                SemInternet();
            }
        }

        private async Task CarregarMercados()
        {
            IsBusy = true;

            try
            {
                Estabelecimentos = await ServiceWS.GetMercados();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro {0}" + e);
            }
            finally
            {
                IsConected = false;
                IsBusy = false;
            }
        }

        private void SemInternet()
        {
            IsConected = true;
            StatusConexao = "Sem internet";
            CorConexao = "Red";
        }

        private void Conectando()
        {
            IsConected = true;
            StatusConexao = "Conectando...";
            CorConexao = "Green";
        }

        #endregion

        #region NOTIFICAÇÃO

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        

        #endregion

    }
}
