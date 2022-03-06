using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalTechPrueba.Services;
using TotalTechPrueba.View;
using TotalTechPrueba.ViewModel;
using Xamarin.Forms;

namespace TotalTechPrueba
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MainPageViewmodel();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            (BindingContext as MainPageViewmodel).CleanSelected();
            base.OnAppearing();
        }
    }
}
