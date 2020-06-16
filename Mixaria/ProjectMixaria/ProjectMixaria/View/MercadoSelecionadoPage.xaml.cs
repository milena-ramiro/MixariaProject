using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProjectMixaria.Model;

namespace ProjectMixaria.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MercadoSelecionadoPage : ContentPage
    {
        public MercadoSelecionadoPage(tbEstab estab)
        {
            InitializeComponent();


            BindingContext = new ViewModel.MercadoSelecionadoViewModel(estab);

        }
    }
}