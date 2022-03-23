using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Asynchronous_Programming.Module
{
    class Task_WhenAll
    {
        private readonly string apiURL;
        private readonly HttpClient httpClient;
        public Task_WhenAll(string apiURL)
        {
            this.apiURL = apiURL;
            httpClient = new HttpClient();
        }

        public async Task btnStart_Click()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                var cards = await GetCards(20);
                await ProcessCards(cards);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show($"Operation finalized in {stopwatch.ElapsedMilliseconds / 1000.0} seconds");
        }

        private async Task ProcessCards(List<string> cards)
        {
            var tasks = new List<Task<HttpResponseMessage>>();
         await Task.Run(() =>
            {
                foreach (var card in cards)
                {
                    var json = JsonConvert.SerializeObject(card);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var responseTask = httpClient.PostAsync($"{apiURL}/cards", content);
                    tasks.Add(responseTask);
                }
            });
         

            await Task.WhenAll(tasks);
        } 
        private async Task<List<string>> GetCards(int amountOfCards)
        {
           return await Task.Run(() =>
            {
                var cards = new List<string>();

                for (int i = 0; i < amountOfCards; i++)
                {
                    cards.Add(i.ToString().PadLeft(16, '0'));
                }

                return cards;
            });
          
        }



    }
}
