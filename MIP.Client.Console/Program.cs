﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using MIP.Common.Identity;
using Thinktecture.IdentityModel.Client;

namespace MIP.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            const string username = "itua";
            const string password = "itua";

            System.Console.WriteLine("Making Login request with Username: {0} and Password: {1}...", username, password);

            var response = GetUserToken(username, password);
            if (response == null) return;
            System.Console.WriteLine("Token Found: {0}", response.AccessToken);
            
            System.Console.WriteLine("\nGetting claims from token...");
            var claims = GetClaimsFromToken(response.AccessToken, ApplicationConstants.UrlBaseAuth + "/resources");
            foreach (var item in claims)
            {
                System.Console.WriteLine(item.Type.Split('/').Last() + " : " + item.Value);
            }
            System.Console.ReadLine();
        }

        private static TokenResponse GetUserToken(String username, String password)
        {
            var client = new OAuth2Client(
                new Uri(ApplicationConstants.TokenEndpoint),
                ApplicationConstants.ConsoleAppClientId,
                ApplicationConstants.ConsoleAppClientSecret);

            return client.RequestResourceOwnerPasswordAsync(username, password, ApplicationScopes.ConsoleApp).Result;
        }

        private static IEnumerable<Claim> GetClaimsFromToken(string token, String audience)
        {
            const string certString = "MIIDBTCCAfGgAwIBAgIQNQb+T2ncIrNA6cKvUA1GWTAJBgUrDgMCHQUAMBIxEDAOBgNVBAMTB0RldlJvb3QwHhcNMTAwMTIwMjIwMDAwWhcNMjAwMTIwMjIwMDAwWjAVMRMwEQYDVQQDEwppZHNydjN0ZXN0MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAqnTksBdxOiOlsmRNd+mMS2M3o1IDpK4uAr0T4/YqO3zYHAGAWTwsq4ms+NWynqY5HaB4EThNxuq2GWC5JKpO1YirOrwS97B5x9LJyHXPsdJcSikEI9BxOkl6WLQ0UzPxHdYTLpR4/O+0ILAlXw8NU4+jB4AP8Sn9YGYJ5w0fLw5YmWioXeWvocz1wHrZdJPxS8XnqHXwMUozVzQj+x6daOv5FmrHU1r9/bbp0a1GLv4BbTtSh4kMyz1hXylho0EvPg5p9YIKStbNAW9eNWvv5R8HN7PPei21AsUqxekK0oW9jnEdHewckToX7x5zULWKwwZIksll0XnVczVgy7fCFwIDAQABo1wwWjATBgNVHSUEDDAKBggrBgEFBQcDATBDBgNVHQEEPDA6gBDSFgDaV+Q2d2191r6A38tBoRQwEjEQMA4GA1UEAxMHRGV2Um9vdIIQLFk7exPNg41NRNaeNu0I9jAJBgUrDgMCHQUAA4IBAQBUnMSZxY5xosMEW6Mz4WEAjNoNv2QvqNmk23RMZGMgr516ROeWS5D3RlTNyU8FkstNCC4maDM3E0Bi4bbzW3AwrpbluqtcyMN3Pivqdxx+zKWKiORJqqLIvN8CT1fVPxxXb/e9GOdaR8eXSmB0PgNUhM4IjgNkwBbvWC9F/lzvwjlQgciR7d4GfXPYsE1vf8tmdQaY8/PtdAkExmbrb9MihdggSoGXlELrPA91Yce+fiRcKY3rQlNWVd4DOoJ/cPXsXwry8pWjNCo5JD8Q+RQ5yZEy7YPoifwemLhTdsBz3hlZr28oCGJ3kbnpW0xGvQb3VHSTVVbeei0CfXoW6iz1";
            var cert = new X509Certificate2(Convert.FromBase64String(certString));

            var parameters = new TokenValidationParameters
            {
                ValidAudience = audience,
                ValidIssuer = ApplicationConstants.UrlBaseAuth,
                IssuerSigningToken = new X509SecurityToken(cert)
            };

            var handler = new JwtSecurityTokenHandler();
            SecurityToken jwt;
            var id = handler.ValidateToken(token, parameters, out jwt);

            return id.Claims;
        }
    }
}
