using System.Collections.Generic;
using MIP.Common.Identity;
using Thinktecture.IdentityServer.Core.Models;

namespace MIP.IdentityServer.v1.Configuration
{
    public class Clients
    {
        public static List<Client> Get()
        {
            return new List<Client>
            {
                // Resource Credentials - console app
                new Client
                {
                    Enabled = true,
                    ClientName = ApplicationConstants.ConsoleAppClientName,
                    ClientId = ApplicationConstants.ConsoleAppClientId,
                    AccessTokenType = AccessTokenType.Jwt, 

                    Flow = Flows.ResourceOwner,
                    ClientSecrets = new List<ClientSecret>
                    {
                        new ClientSecret(ApplicationConstants.ConsoleAppClientSecret.Sha256())
                    }
                },

                // Implicit Flow - web app
                new Client
                {
                    Enabled = true,
                    ClientName = ApplicationConstants.WebAppClientName,
                    ClientId = ApplicationConstants.WebAppClientId,
                    ClientSecrets = new List<ClientSecret>
                    { 
                        new ClientSecret(ApplicationConstants.WebAppClientSecret.Sha256())
                    },
                    Flow = Flows.Implicit,                    
                    RequireConsent = false,
                    IdentityTokenLifetime = 360,
                    AccessTokenLifetime = 3600,

                    RedirectUris = new List<string>
                    {
                        ApplicationConstants.UrlBaseWeb
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        ApplicationConstants.UrlBaseWeb
                    }
                }
            };
        }
    }
}