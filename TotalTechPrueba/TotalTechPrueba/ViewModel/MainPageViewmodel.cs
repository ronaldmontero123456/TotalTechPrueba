﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TotalTechPrueba.Model;
using TotalTechPrueba.Services;

namespace TotalTechPrueba.ViewModel
{
    public class MainPageViewmodel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        
        private ObservableCollection<Result> popular;
        public ObservableCollection<Result> Popular { get => popular; set { popular = value; RaiseOnPropertyChanged();} }

        private ObservableCollection<Result> toprated;
        public ObservableCollection<Result> TopRated { get => toprated; set { toprated = value; RaiseOnPropertyChanged();} }

        private ObservableCollection<Result> upcoming;
        public ObservableCollection<Result> UpComing { get => upcoming; set { upcoming = value; RaiseOnPropertyChanged();} }
        public MainPageViewmodel()
        {
            Task.Run(async() => {
                Popular = new ObservableCollection<Result>(await ApiManager.GetInstance("https://api.themoviedb.org").GetMovies("popular"));
                TopRated = new ObservableCollection<Result>(await ApiManager.GetInstance("https://api.themoviedb.org").GetMovies("top_rated"));
                UpComing = new ObservableCollection<Result>(await ApiManager.GetInstance("https://api.themoviedb.org").GetMovies("upcoming"));
            });            
        }

        public void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}