using ProjectMixaria.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectMixaria.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MercadosPage : ContentPage
    {
        public MercadosPage()
        {
            InitializeComponent();

            

            BindingContext = new ViewModel.MercadosViewModel();

        }
    }
}