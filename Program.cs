using System;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Flurl.Http;

namespace GraphAPI_1
{
    class Program
    {
        
        private static readonly string _clientId = "38478b47-0715-4ce9-8d56-90ff0d503ce4";
        static async Task Main(string[] args)
        {

            string[] scopes = new string[] { 
                "User.Read", 
                "Directory.Read.All"
            };

            var authProvider = new AuthProvider(_clientId, scopes);

            var token = authProvider.GetAccessToken().Result;
            Console.WriteLine($"Access token: {token}");

            var photoJson = await "https://graph.microsoft.com/v1.0/me/photo/"
                .WithOAuthBearerToken(token)
                .GetStringAsync();
            Console.WriteLine("My Photo Infomation:");
            Console.WriteLine(photoJson);

             var drive = await "https://graph.microsoft.com/v1.0/me/drive/"
                .WithOAuthBearerToken(token)
                .GetStringAsync();

            Console.WriteLine("My OneDrive:");
            Console.WriteLine(drive);


            var users = await "https://graph.microsoft.com/v1.0/users/"
                .WithOAuthBearerToken(token)
                .GetStringAsync();
            Console.WriteLine("Users in org:");
            Console.WriteLine(users);

        }
    }
}
