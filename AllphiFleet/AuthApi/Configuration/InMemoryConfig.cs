using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

public static class InMemoryConfig
{
    public static IEnumerable<IdentityResource> GetIdentityResources() =>
      new List<IdentityResource>
      {
          new IdentityResources.OpenId(),
          new IdentityResources.Profile()
      };

    public static List<TestUser> GetUsers() =>
      new List<TestUser>
      {
          new TestUser
          {
              SubjectId = "a9ea0f25-b964-409f-bcce-c923266249b4",
              Username = "Mick",
              Password = "MickPassword",
              Claims = new List<Claim>
              {
                  new Claim("given_name", "Mick"),
                  new Claim("family_name", "Mining")
              }
          },
          new TestUser
          {
              SubjectId = "c95ddb8c-79ec-488a-a485-fe57a1462340",
              Username = "Jane",
              Password = "JanePassword",
              Claims = new List<Claim>
              {
                  new Claim("given_name", "Jane"),
                  new Claim("family_name", "Downing")
              }
          }
  };

    public static IEnumerable<Client> GetClients() =>
        new List<Client>
        {
           new Client
           {
               //parameters in te geven in post
                ClientId = "readapi",
                ClientSecrets = new [] { new Secret("allphisecret".Sha512()) },
                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,

                //specify scopes
                AllowedScopes = { "api1.read" }
            },
           new Client
            {
               /* This configuration adds a new client application that uses the recommended flow for server-side web applications:
                * the authorization code flow with Proof-Key for Code Exchange (PKCE)
                * For this client, you have also set a redirect URI. 
                * Because this flow takes place via the browser, IdentityServer must know an allowed list of URLs to send the user back to,
                * once user authentication and client authorization is complete;
                * what URLs it can return the authorization result to. 
                * */
                ClientId = "oidcClient",
                ClientName = "Example Client Application",
                ClientSecrets = new List<Secret> {new Secret("mvcsecret".Sha256())}, // change me!
    
                AllowedGrantTypes = GrantTypes.Hybrid,
                RedirectUris = new List<string> {"https://localhost:44384/signin-oidc"}, //mvc app port (oidcClient app)
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    "role",
                    "api1.read"
                },

                RequirePkce = false,
                //AllowPlainTextPkce = false
}
        };

    public static IEnumerable<ApiScope> GetApiScopes() =>
        new List<ApiScope> {

            new ApiScope(name: "api1.read",   displayName: "ReadAPI"),

            new ApiScope(name: "write",  displayName: "WriteAPI")
        };

    public static IEnumerable<ApiResource> GetApiResources() =>
        new List<ApiResource>
        {
            new ApiResource("api1", "ReadAPI")
            {
                Scopes = { "api1.read" }
            },
            new ApiResource("write", "WriteAPI")
            {
                Scopes = { "WriteAPI" }
            }
        };
}