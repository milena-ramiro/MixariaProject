using ProjectMixaria.Model;
using ProjectMixaria.Servicos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProjectMixaria.ViewModel
{
    public class InicioPageViewModel : INotifyPropertyChanged
    {

        #region CAMPOS

        private double _opacidade1;
        public double Opacidade1
        {
            get { return _opacidade1; }
            set
            {
                _opacidade1 = value;
                OnPropertyChanged("Opacidade1");
            }
        }

        private double _opacidade2;
        public double Opacidade2
        {
            get { return _opacidade2; }
            set
            {
                _opacidade2 = value;
                OnPropertyChanged("Opacidade2");
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

        public Command AcessarTopCommand { get; set; }
        public Command AcessarMercadosCommand { get; set; }
        public ObservableCollection<tbEstab> estabelecimentos { get; set; }
        public ObservableCollection<tbTop30> top_prod { get; set; }

        #endregion

        #region METODOS

        public InicioPageViewModel()
        {
            Opacidade1 = Opacidade2 = 1;
            AcessarTopCommand = new Command(TopProdutos);
            AcessarMercadosCommand = new Command(Mercados);
        }

        private async void Mercados()
        {
            try
            {
                Opacidade1 = 0.7;
                await Task.Delay(10);
                Carregando = true;
                await Task.Delay(1200);

                if (Connectivity.NetworkAccess == NetworkAccess.Internet || ServiceWS.estabs != null)
                {
                    Erro = false;
                    await ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.MercadosPage(), false);
                }
                else
                {
                    await ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.Erro(), false);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro {0}" + e);
            }
            finally
            {
                Opacidade1 = 1;
                Carregando = false;
            }

        }

        private async void TopProdutos()
        {
            try
            {
                Opacidade2 = 0.7;
                await Task.Delay(10);
                Carregando = true;
                await Task.Delay(1200);

                if (Connectivity.NetworkAccess == NetworkAccess.Internet || ServiceWS.top30 != null)
                {
                    Erro = false;
                    await ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.Top30Page(), false);
                }
                else
                {
                    await ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.Erro(), false);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro {0}" + e);
            }
            finally
            {
                Carregando = false;
                Opacidade2 = 1;
            }

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
