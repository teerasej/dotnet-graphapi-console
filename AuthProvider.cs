
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Identity.Client;

namespace GraphAPI_1
{
    public class AuthProvider : IAuthenticationProvider
    {
        private IPublicClientApplication _msalClient;
        private string[] _scopes;
        private IAccount _userAccount;

        public AuthProvider(string clientId, string[] scopes)
        {
            _scopes = scopes;

            _msalClient = PublicClientApplicationBuilder
                .Create(clientId)
                .WithAuthority(AadAuthorityAudience.AzureAdAndPersonalMicrosoftAccount, true)
                .WithRedirectUri("http://localhost")
                .Build();
        }

        public async Task AuthenticateRequestAsync(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.Authorization =
                new AuthenticationHeaderValue("bearer", await GetAccessToken());
        }
        
         public async Task<string> GetAccessToken()
        {
            // If there is no saved user account, the user must sign-in
            if (_userAccount == null)
            {
                try
                {
                    // Invoke device code flow so user can sign-in with a browser
                    // Don't forget to turn on default client type: https://github.com/azuread/microsoft-authentication-library-for-dotnet/wiki/Client-Applications#invalid-client
                    var result = await _msalClient.AcquireTokenInteractive(_scopes).ExecuteAsync();

                    _userAccount = result.Account;
                    return result.AccessToken;
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Error getting access token: {exception.Message}");
                    return null;
                }
            }
            else
            {
                // If there is an account, call AcquireTokenSilent
                // By doing this, MSAL will refresh the token automatically if
                // it is expired. Otherwise it returns the cached token.

                    var result = await _msalClient
                        .AcquireTokenSilent(_scopes, _userAccount)
                        .ExecuteAsync();

                    return result.AccessToken;
            }
        }
    }
}