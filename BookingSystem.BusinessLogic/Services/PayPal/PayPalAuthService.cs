using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Configuration;

namespace  BookingSystem.BusinessLogic.Services.Paypal
{
    public class PayPalAuthService
    {
        private readonly ClientCred _clientCred;
        
        private readonly string _basePath;
        public PayPalAuthService(IConfiguration configuration)
        {
            _clientCred = configuration.GetSection("PaypalClientCred").Get<ClientCred>();
            _basePath = configuration.GetSection("PayPal")["baseUrl"];
        }
        private string accessToken = string.Empty;
        public async Task<string> AccessTokenAsync ()
        {             
                if (accessToken.Length==0)
                {
                  await GetAccessTokenFromPayPalAsync();
                }
                return accessToken; 
            
        }




        private async Task GetAccessTokenFromPayPalAsync()
        {

            string url = $"{_basePath}/v1/oauth2/token";

            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(url)
            };

            var base64string = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{_clientCred.Client_id}:{_clientCred.Client_secret}"));

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64string);

            var body = new[] { new KeyValuePair<string, string>("grant_type", "client_credentials") };

            var response = await httpClient.PostAsync("", new FormUrlEncodedContent(body));

            AuthData authData;
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                authData = JsonConvert.DeserializeObject<AuthData>(jsonString);
            }

            else authData = null;
            accessToken = authData?.Access_token??string.Empty;
        }
    }

    internal class AuthData
    {
        public string Scope { get; set; }
        public string Access_token { get; set; }
        public string Token_type { get; set; }
        public string App_id { get; set; }
        public long Expires_in { get; set; }
        public string Nonce { get; set; }

    }
    internal class ClientCred
    {

        public string Client_id { get; set; } = string.Empty;
        public string Client_secret { get; set; } = string.Empty;
    }
}
