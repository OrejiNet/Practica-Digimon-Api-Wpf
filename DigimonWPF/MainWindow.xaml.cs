using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DigimonWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillDtaGridAsync();
           

        }

        public async void FillDtaGridAsync()
        {

            Digimon[] digimons = await  GetDigimons();
            DtaGridDigimon.ItemsSource = digimons;

        }




        public async Task<Digimon[]> GetDigimons()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://digimon-api.herokuapp.com/api/digimon");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Digimon[] model = JsonConvert.DeserializeObject<Digimon[]>(responseBody);
            // model = JsonConvert.DeserializeObject<List<Digimon>>(responseBody);

            return model;
            
        }


    }

    public class Digimon
    {

        public string Name { get; set; }
        public string Img { get; set; }
        public string Level { get; set; }


    }

}
