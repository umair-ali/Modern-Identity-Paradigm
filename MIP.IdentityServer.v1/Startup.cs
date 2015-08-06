using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using MIP.IdentityServer.v1.Configuration;
using Owin;
using Thinktecture.IdentityServer.Core.Configuration;
using Thinktecture.IdentityServer.Core.Logging;

[assembly: OwinStartup(typeof(MIP.IdentityServer.v1.Startup))]

namespace MIP.IdentityServer.v1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            LogProvider.SetCurrentLogProvider(new DiagnosticsTraceLogProvider());

            var factory = InMemoryFactory.Create(
                users: Users.Get(),
                clients: Clients.Get(),
                scopes: Scopes.Get());

            var options = new IdentityServerOptions
            {
                RequireSsl = false,
                SigningCertificate = Certificate.Load(),
                Factory = factory,
            };

            app.UseIdentityServer(options);
        }
    }
}
