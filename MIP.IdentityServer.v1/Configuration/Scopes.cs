using System.Collections.Generic;
using MIP.Common.Identity;
using Thinktecture.IdentityServer.Core.Models;

namespace MIP.IdentityServer.v1.Configuration
{
    public class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            var scopes = new List<Scope>();

            scopes.AddRange(StandardScopes.All);

            var webScope = new Scope
            {
                Name = ApplicationScopes.MvcApp,
                DisplayName = "Web App Scope",
                Description = "Scope for Web Application",
                Type = ScopeType.Resource,
                IncludeAllClaimsForUser = true,
                ShowInDiscoveryDocument = true,
                Claims = new List<ScopeClaim>
                {
                    new ScopeClaim(ApplicationClaimTypes.Role, true),
                    new ScopeClaim(ApplicationClaimTypes.Values, true)
                }
            };
            scopes.Add(webScope);

            var consoleScope = new Scope
            {
                Name = ApplicationScopes.ConsoleApp,
                DisplayName = "Console App Scope",
                Description = "Scope for Console Application",
                Type = ScopeType.Resource,
                IncludeAllClaimsForUser = true,
                ShowInDiscoveryDocument = true,
                Claims = new List<ScopeClaim>
                {
                    new ScopeClaim(ApplicationClaimTypes.Values, true)
                }
            };
            scopes.Add(consoleScope);

            return scopes;
        }
    }
}