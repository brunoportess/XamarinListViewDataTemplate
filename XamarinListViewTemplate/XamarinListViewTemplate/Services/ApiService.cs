using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XamarinListViewTemplate.Models;

namespace XamarinListViewTemplate.Services
{
    public class ApiService
    {
        private string GerarHash(
            string ts, string publicKey, string privateKey)
        {
            byte[] bytes =
                Encoding.UTF8.GetBytes(ts + privateKey + publicKey);
            var gerador = MD5.Create();
            byte[] bytesHash = gerador.ComputeHash(bytes);
            return BitConverter.ToString(bytesHash)
                .ToLower().Replace("-", String.Empty);
        }

        public async Task<List<dynamic>> ListaPersonagens()
        {
            List<dynamic> personagens;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            string ts = DateTime.Now.Ticks.ToString();
            string publicKey = "";
            string hash = GerarHash(ts, publicKey,
                "");
            var url = "https://gateway.marvel.com:443/v1/public/characters?ts=" + ts + "&apikey=" + publicKey + "&hash=" + hash;
            var response = await client.GetStringAsync(url);
            
            var responseObject = JObject.Parse(response);
            //dynamic resultado = JsonConvert.DeserializeObject<dynamic>(conteudo);
            //personagens = resultado["data"]["results"];
            personagens = JsonConvert.DeserializeObject<List<dynamic>>(responseObject["data"]["results"].ToString());


            return personagens;
        }
    }
}
