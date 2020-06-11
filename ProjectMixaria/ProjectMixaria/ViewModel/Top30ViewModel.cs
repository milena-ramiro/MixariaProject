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
    public class Top30PageViewModel : INotifyPropertyChanged
    {
        #region CAMPOS#

        private bool _carregando;
        public bool Carregando
        {
            get { return _carregando; }
            set
            {
                _carregando = value;
                OnPropertyChanged("Carregando");
            }
        }

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

        public ICommand OnLoadMoreCommand { get; set; }

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

        private bool _erro;
        public bool Erro
        {
            get { return _erro; }
            set
            {
                _erro = value;
                OnPropertyChanged("Erro");
            }
        }

        private ObservableCollection<tbTop30> _topProdutos;
        public ObservableCollection<tbTop30> TopProdutos
        {
            get
            {
                return _topProdutos;
            }
            set
            {
                _topProdutos = value;
                OnPropertyChanged("TopProdutos");
            }
        }

        #endregion

        #region METODOS#


        public Top30PageViewModel()
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;


            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                Task.Run(() => CarregarProdutos());
            }
            else
            {
                Bufferizador();
            }
            
        }

        private void Bufferizador()
        {
            TopProdutos = ServiceWS.top30;
            SemInternet();
        }

        ~Top30PageViewModel()
        {
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }

        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess == NetworkAccess.Internet)
            {
                Conectando();
                Task.Run(() => CarregarProdutos());
            }
            else
            {
                SemInternet();
            }
        }

        private async Task CarregarProdutos()
        {
            IsBusy = true;
            Erro = false;
            Carregando = true;
            
            try
            {
                TopProdutos = await ServiceWS.GetTopProdutos();
            }
            catch (Exception)
            {
                Erro = true;
            }
            finally
            {
                IsConected = false;
                IsBusy = false;
                Carregando = false;
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
            StatusConexao = "Conectando...";
            CorConexao = "Green";
        }

        #endregion

        #region NOTIFICAÇÃO #

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
