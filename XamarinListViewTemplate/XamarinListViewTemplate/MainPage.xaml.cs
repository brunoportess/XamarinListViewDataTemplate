using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinListViewTemplate
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            PopularLista();
        }

        private void PopularLista()
        {
            List<dynamic> DadosLista = new List<dynamic>
            {
                new
                {
                    Nome = "Usuario 1",
                    Tipo = "user"
                },
                new
                {
                    Endereco = "Rua do vizinho",
                    Tipo = "created"
                }
            };

            ListaExemplo.ItemsSource = DadosLista;
        }
    }
}
