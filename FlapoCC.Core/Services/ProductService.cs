using FlapoCC.Core.Data.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlapoCC.Core.Services
{
    public class ProductService
    {
        private HttpClient _httpClient;

        public ProductService()
        {
            _httpClient = new HttpClient();
            // Konfigurationsoptionen für den HttpClient hinzufügen.
        }

        public async Task<List<Product>> GetProductsAsync(string serviceUrl)
        {
            try
            {
                // GET-Anforderung
                HttpResponseMessage response = await _httpClient.GetAsync(serviceUrl);

                // die Anforderung erfolgreich war (Statuscode 200)
                if (response.IsSuccessStatusCode)
                {
                    // die Antwort als JSON-Zeichenfolge abrufen
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // die JSON-Daten in C#-Objekte deserialisieren
                    List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonResponse);

                    return products;
                }
                else
                {
                    //TODO:
                    Console.WriteLine($"Fehler beim Abrufen der Daten. Statuscode: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler: " + ex.Message);
                return null;
            }
        }
    }
}