using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TotalTechPrueba.Model;
using TotalTechPrueba.Services;
using Xamarin.Forms;

namespace TotalTechPrueba.ViewModel
{
    public class MovieDetailsViewmodel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private MovieDetails moviedetail;
        public MovieDetails MovieDetail { get => moviedetail; set { moviedetail = value; RaiseOnPropertyChanged(); } }

        private List<Cast> moviecredits;
        public List<Cast> MovieCredits { get => moviecredits; set { moviecredits = value; RaiseOnPropertyChanged(); } }
        public MovieDetailsViewmodel(int id)
        {
            GetMovieDetail(id);
            GetMovieCredits(id);
        }
        private async void GetMovieDetail(int id)
        {
            MovieDetail = await new ApiManager(Application.Current.Resources["Url"].ToString()).GetMovieDetails(id);
        }
        private async void GetMovieCredits(int id)
        {
            MovieCredits = await new ApiManager(Application.Current.Resources["Url"].ToString()).GetMovieCredits(id);
        }

        public void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
