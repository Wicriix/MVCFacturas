using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace ServerAuthIdentity
{
    public static class SD //static details
    {
        public const string Admin = "admin";
        public const string Customer = "customer";

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                // some standard scopes from the OIDC spec
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> apiResources =>
            new[]
            {
                new ApiResource("magic")
                {
                    Scopes = new List<string>{ "magic", "read", "write", "delete" },
                    ApiSecrets= new List<Secret>{new Secret("secret".Sha256())},
                    UserClaims = new List<string>{"role"}
                
                }
            };


        public static IEnumerable<ApiScope> GetApiScopes() =>
            new List<ApiScope>
            {
                new ApiScope(name: "magic",   displayName: "all data"),
                new ApiScope(name: "read",   displayName: "Read your data."),
                new ApiScope(name: "write",  displayName: "Write your data."),
                new ApiScope(name: "delete", displayName: "Delete your data.")
            };

        public static IEnumerable<Client> Clients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "service.client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "api1", "api2.read_only" }
                },
                new Client
                {
                    ClientId = "magic",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = { "magic",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email
                    },
                    RedirectUris = { "https://localhost:7217/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:7217/signout-callback-oidc" },
                    RequireConsent = true,
                    AllowOfflineAccess = true,
                },
                                new Client
                {
                    ClientId = "magic2",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    AllowedScopes = { 
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email
                    },
                    RequireClientSecret = false,
                    RedirectUris = { "https://localhost:7194/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:7194/signout-callback-oidc" },
                    RequireConsent = true,
                    AllowOfflineAccess = true,
                    AllowAccessTokensViaBrowser = true
                }
            };
        }

    }
}
