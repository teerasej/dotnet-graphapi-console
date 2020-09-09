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

            GraphHelper.Initialize(authProvider);
            var user = GraphHelper.GetMeAsync().Result;
            Console.WriteLine($"Welcome {user.DisplayName}\n");

            var userPhoto = GraphHelper.GetUserPhotoAsync().Result;
            Console.WriteLine($"My Photo Infomation: {userPhoto}");



        }
    }
}
