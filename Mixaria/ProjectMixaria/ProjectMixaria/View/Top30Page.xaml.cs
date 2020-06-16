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
    public partial class Top30Page : ContentPage
    {
        public Top30Page()
        {
            InitializeComponent();
            
            /*
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                BindingContext = new ViewModel.Top30PageViewModel();
            }
            else
            {
                BindingContext = new ViewModel.Top30PageViewModel(produtos);
            }*/

            BindingContext = new ViewModel.Top30PageViewModel();

        }
    }
}