using System.Collections.Generic;
using System.Security.Claims;
using Thinktecture.IdentityServer.Core;
using Thinktecture.IdentityServer.Core.Services.InMemory;

namespace MIP.IdentityServer.v1.Configuration
{
    static class Users
    {
        public static List<InMemoryUser> Get()
        {
            var users = new List<InMemoryUser>
            {
                new InMemoryUser{
                    Subject = "818727", 
                    Username = "itua", 
                    Password = "itua", 
                    Claims = new[]
                    {
                        new Claim(Constants.ClaimTypes.Name, "Umair Ali"),
                        new Claim(Constants.ClaimTypes.GivenName, "Umair"),
                        new Claim(Constants.ClaimTypes.Email, "umair@mail.com"),
                        new Claim(Constants.ClaimTypes.Role, "Developer")
                    }
                },
                new InMemoryUser{
                    Subject = "88421113", 
                    Username = "itaa", 
                    Password = "itaa", 
                    Claims = new[]
                    {
                        new Claim(Constants.ClaimTypes.Name, "Anis Ahmed"),
                        new Claim(Constants.ClaimTypes.GivenName, "Anis"),
                        new Claim(Constants.ClaimTypes.Email, "anis@mail.com"),
                        new Claim(Constants.ClaimTypes.Role, "Developer"),
                        new Claim(Constants.ClaimTypes.Role, "Admin")
                    }
                },
            };

            return users;
        }
    }
}