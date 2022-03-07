using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

        private Result selectedimagepopular;
        public Result SelectedImagePopular { get => selectedimagepopular; set { selectedimagepopular = value; RaiseOnPropertyChanged(); if (value != null) { PushDetails(value.id); } } }

        private Result selectedimagetoprated;
        public Result SelectedImageTopRated { get => selectedimagetoprated; set { selectedimagetoprated = value; RaiseOnPropertyChanged(); if (value != null) { PushDetails(value.id); } } }

        private Result selectedimageupcoming;
        public Result SelectedImageUpComing { get => selectedimageupcoming; set { selectedimageupcoming = value; RaiseOnPropertyChanged(); if (value != null) { PushDetails(value.id); } } }

        private ObservableCollection<Result> upcoming;
        public ObservableCollection<Result> UpComing { get => upcoming; set { upcoming = value; RaiseOnPropertyChanged(); } }

        public ObservableCollection<Result> MoviesToGivePopular;
        public ObservableCollection<Result> MoviesToGiveTopRated;
        public ObservableCollection<Result> MoviesToGiveUpComing;
        public ICommand SearchBarCommand { get; private set; }
        public MainPageViewmodel()
        {
            MoviesToGivePopular = new ObservableCollection<Result>();
            MoviesToGiveTopRated = new ObservableCollection<Result>();
            MoviesToGiveUpComing = new ObservableCollection<Result>();

            SearchBarCommand = new Command((searchbar) => FilterMovies(searchbar?.ToString()));

            GetMovies();
        }

        private void PushDetails(int id)
        {
            App.Current.MainPage.Navigation.PushAsync(new MovilDetailsPage(id));
        }

        private void FilterMovies(string searchbar)
        {
            if (searchbar == null)
                return;

            if (searchbar.Length < 3)
            {
                Popular = MoviesToGivePopular;
                TopRated = MoviesToGiveTopRated;
                UpComing = MoviesToGiveUpComing;
                return;
            }

            SetMovies(searchbar);
        }

        private void SetMovies(string searchbar)
        {
            Popular = new ObservableCollection<Result>(MoviesToGivePopular.Where(mp => mp.title.ToUpper().Contains(searchbar.ToUpper())));
            TopRated = new ObservableCollection<Result>(MoviesToGiveTopRated.Where(mt => mt.title.ToUpper().Contains(searchbar.ToUpper())));
            UpComing = new ObservableCollection<Result>(MoviesToGiveUpComing.Where(mu => mu.title.ToUpper().Contains(searchbar.ToUpper())));
        }

        public async void GetMovies()
        {
            ApiManager apimanager = new ApiManager(Application.Current.Resources["Url"].ToString());

            Popular = new ObservableCollection<Result>(await apimanager.GetMovies("popular"));
            MoviesToGivePopular = Popular;
            TopRated = new ObservableCollection<Result>(await apimanager.GetMovies("top_rated"));
            MoviesToGiveTopRated = TopRated;
            UpComing = new ObservableCollection<Result>(await apimanager.GetMovies("upcoming"));
            MoviesToGiveUpComing = UpComing;
        }

        public void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void CleanSelected()
        {
            SelectedImagePopular = null;
            SelectedImageUpComing = null;
            SelectedImageTopRated = null;
        }
    }
}
