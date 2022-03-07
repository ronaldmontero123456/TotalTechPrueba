using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TotalTechPrueba.Model;
using Xamarin.Forms;

namespace TotalTechPrueba.Services
{
    public class ApiManager
    {
        private HttpClient client;

        public ApiManager(string url)
        {
            client = new HttpClient() { BaseAddress = new Uri(url) };
            client.Timeout.Add(new TimeSpan(0, 8, 0));
        }
        public async Task<List<Result>> GetMovies(string type)
        {

            if (!CrossConnectivity.Current.IsConnected)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso", "No estas conectado a internet", "Aceptar");
                return null;
            }

            var request = await client.GetAsync($"/3/movie/{type}?api_key=763032488904923aa0bac2b791e3589b&language=en-US&page=1");

            if (request.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Movies>(request.Content.ReadAsStringAsync().Result).results.Take(10).ToList();

            return null;
        }


        public async Task<MovieDetails> GetMovieDetails(int id)
        {

            if (!CrossConnectivity.Current.IsConnected)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso", "No estas conectado a internet", "Aceptar");
                return null;
            }

            var request = await client.GetAsync($"/3/movie/{id}?api_key=763032488904923aa0bac2b791e3589b&language=en-US&page=1");

            if (request.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<MovieDetails>(request.Content.ReadAsStringAsync().Result);

            return null;
        }

        public async Task<List<Cast>> GetMovieCredits(int id)
        {

            if (!CrossConnectivity.Current.IsConnected)
            {
                await Application.Current.MainPage.DisplayAlert("Aviso", "No estas conectado a internet", "Aceptar");
                return null;
            }

            var request = await client.GetAsync($"/3/movie/{id}/credits?api_key=763032488904923aa0bac2b791e3589b&language=en-US&page=1");

            if (request.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<Credits>(request.Content.ReadAsStringAsync().Result).cast.Take(10).ToList();

            return null;
        }

    }
}
