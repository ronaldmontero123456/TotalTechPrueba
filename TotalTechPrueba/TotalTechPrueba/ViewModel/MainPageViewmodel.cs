using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TotalTechPrueba.Model;
using TotalTechPrueba.Services;
using TotalTechPrueba.View;
using Xamarin.Forms;

namespace TotalTechPrueba.ViewModel
{
    public class MainPageViewmodel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private ObservableCollection<Result> popular;
        public ObservableCollection<Result> Popular { get => popular; set { popular = value; RaiseOnPropertyChanged(); } }

        private ObservableCollection<Result> toprated;
        public ObservableCollection<Result> TopRated { get => toprated; set { toprated = value; RaiseOnPropertyChanged(); } }

        private ObservableCollection<Result> upcoming;
        public ObservableCollection<Result> UpComing { get => upcoming; set { upcoming = value; RaiseOnPropertyChanged(); } }
        public Command imagecommand { get; private set; }
        public Command ImageCommand { get => imagecommand; set { imagecommand = value; RaiseOnPropertyChanged(); } }
        public MainPageViewmodel()
        {
            ImageCommand = new Command(PushDetails);

            GetMovies();
        }

        private void PushDetails(object id)
        {
            App.Current.MainPage.Navigation.PushAsync(new MovilDetailsPage());
        }

        public async void GetMovies()
        {
            ApiManager apimanager = new ApiManager(Application.Current.Resources["Url"].ToString());

            Popular = new ObservableCollection<Result>(await apimanager.GetMovies("popular"));
            TopRated = new ObservableCollection<Result>(await apimanager.GetMovies("top_rated"));
            UpComing = new ObservableCollection<Result>(await apimanager.GetMovies("upcoming"));
        }

        public void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
