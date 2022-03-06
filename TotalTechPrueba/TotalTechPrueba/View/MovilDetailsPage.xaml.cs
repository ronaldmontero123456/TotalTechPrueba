﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalTechPrueba.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TotalTechPrueba.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovilDetailsPage : ContentPage
    {
        public MovilDetailsPage(int id)
        {
            BindingContext = new MovieDetailsViewmodel(id);
            InitializeComponent();
        }
    }
}