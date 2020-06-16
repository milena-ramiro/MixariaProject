using ProjectMixaria.Model;
using ProjectMixaria.Servicos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ProjectMixaria.ViewModel
{
    public class MercadoSelecionadoViewModel : INotifyPropertyChanged
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

        private string _nomeMercado;
        public string NomeMercado
        {
            get { return _nomeMercado; }
            set
            {
                _nomeMercado = value;
                OnPropertyChanged("NomeMercado");
            }
        }

        private IEnumerable<tbPromocao> _produtos;
        public IEnumerable<tbPromocao> Produtos
        {
            get { return _produtos; }
            set
            {
                _produtos = value;
                OnPropertyChanged("Produtos");
            }
        }

        private tbEstab _estab { get; set; }

        #endregion

        #region METODOS

        public MercadoSelecionadoViewModel(tbEstab estab)
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            Task.Run(() => CarregarProdutos(estab));
            _estab = estab;
        }
        

        ~MercadoSelecionadoViewModel()
        {
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }

        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess == NetworkAccess.Internet)
            {
                Conectando();
                Task.Run(() => CarregarProdutos(_estab));
            }
            else
            {
                SemInternet();
            }
        }

        private async void CarregarProdutos(tbEstab estab)
        {
            try
            {
                Carregando = true;
                NomeMercado = estab.Nome.ToUpper();
                Produtos = await ServiceWS.GetProdutos(estab.Codigo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Carregando = false;
                IsConected = false;
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
