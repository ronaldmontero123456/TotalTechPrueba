﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalTechPrueba.Services;
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
    }
}