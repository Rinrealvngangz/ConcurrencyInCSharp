using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asynchronous_Programming.Module
{
    class SemaphoreExample
    {
        private readonly string apiURL;
        private readonly HttpClient httpClient;
        public SemaphoreExample(string apiURL)
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
                var cards = await GetCards(1000);
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
           using var semaphore = new SemaphoreSlim(100);
            var tasks = new List<Task<HttpResponseMessage>>();
            tasks = cards.Select(async card =>
             {
                 var json = JsonConvert.SerializeObject(card);
                 var content = new StringContent(json, Encoding.UTF8, "application/json");
                 await semaphore.WaitAsync();
                 try
                 {
                     return await httpClient.PostAsync($"{apiURL}/cards", content);
                 }
                 finally
                 {
                     semaphore.Release();
                 }

             }).ToList();
           
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
