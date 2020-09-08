using System;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace GraphAPI_1
{
    class Program
    {
        
        private static readonly string _clientId = "38478b47-0715-4ce9-8d56-90ff0d503ce4";
        static async Task Main(string[] args)
        {
            var app = PublicClientApplicationBuilder.Create(_clientId)
                .WithRedirectUri("http://localhost")
                .Build();

            string[] scopes = new string[] { "User.Read" };

            var result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

            var token = result.AccessToken;
        }
    }
}
