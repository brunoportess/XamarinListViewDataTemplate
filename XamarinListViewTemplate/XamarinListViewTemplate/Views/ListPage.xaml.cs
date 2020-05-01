
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinListViewTemplate.Models;
using XamarinListViewTemplate.Services;

namespace XamarinListViewTemplate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ApiService _api { get; set; }
        public List<Personagem> _lista { get; set; }
        public ListPage()
        {
            InitializeComponent();
            _api = new ApiService();
            //Task.Run(() => Popular());
            Popular();
        }

        private async void Popular()
        {
            var dadosApi = await _api.ListaPersonagens();
            _lista = new List<Personagem>();

            foreach (var item in dadosApi)
            {
                //var item = JObject.Parse(data);
                var personagem = new Personagem
                {
                    Nome = item["name"],
                    Descricao = item["description"],
                    UrlImagem = item["thumbnail"]["path"] + "." + item["thumbnail"]["extension"],
                    UrlWiki = item["urls"][1]["url"]
                };
                try
                {
                    _lista.Add(personagem);
                }
                catch (System.Exception e)
                {

                    Debug.WriteLine(personagem);
                    Debug.WriteLine(e.Message);
                }
            }

            ListaExemplo.ItemsSource = _lista;
        }
    }
}