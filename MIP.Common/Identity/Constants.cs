using Thinktecture.IdentityServer.Core;

namespace MIP.Common.Identity
{
    public static class ApplicationConstants
    {
        public const string UrlBaseAuth = "http://localhost:2571";
        public const string UrlBaseApi = "http://localhost:13301";
        public const string UrlBaseWeb = "http://localhost:14104";
        public const string ConnectionString = "DefaultConnection";

        public const string AuthorizeEndpoint = UrlBaseAuth + "/connect/authorize";
        public const string LogoutEndpoint = UrlBaseAuth + "/connect/endsession";
        public const string TokenEndpoint = UrlBaseAuth + "/connect/token";
        public const string UserInfoEndpoint = UrlBaseAuth + "/connect/userinfo";
        public const string IdentityTokenValidationEndpoint = UrlBaseAuth + "/connect/identitytokenvalidation";
        public const string TokenRevocationEndpoint = UrlBaseAuth + "/connect/revocation";


        public const string ConsoleAppClientName = "ClientName-ConsoleApp";
        public const string ConsoleAppClientId = "ClientId-ConsoleApp";
        public const string ConsoleAppClientSecret = "ClientSecret-ConsoleApp";

        public const string WebAppClientName = "ClientName-MvcApp";
        public const string WebAppClientId = "ClientId-MvcApp";
        public const string WebAppClientSecret = "ClientSecret-MvcApp";

    }

    public static class ApplicationClaimTypes
    {
        public const string Role = Constants.ClaimTypes.Role;
        public const string Values = "app/claim/values";
    }

    public static class ApplicationClaimValues
    {
        public const string Create = "create";
        public const string Read = "read";
        public const string Update = "update";
        public const string Delete = "delete";
    }

    public static class ApplicationScopes
    {
        public const string MvcApp = "app/scope/mvcapp";
        public const string ConsoleApp = "app/scope/consoleapp";
    }

    public static class ApplicationRoleTypes
    {
        public static string Admin = "app/role/admin";
        public static string Developer = "app/role/developer";
    }
}
