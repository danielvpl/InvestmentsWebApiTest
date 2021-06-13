using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public class HttpRequestHelper<T>
    {
        public static async Task<T> GetResult(string apiUrlBase, string getTdsEndpoint)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri(apiUrlBase);
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.GetAsync(getTdsEndpoint);
                if (response.IsSuccessStatusCode)
                {
                    //GET
                    var result = await response.Content.ReadAsStringAsync();

                    return JSONHelper.AsObjectList<T>(result);
                }
                else
                {
                    throw new NullReferenceException("Serviço Indisponível!");
                }
            }
        }

    }
}
