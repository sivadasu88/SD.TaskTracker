using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SD.TaskTracker.IdentityServer
{
    public class ClientStore : IClientStore
    {
        private readonly List<Client> clients;

        public ClientStore()
        {
            this.clients = new List<Client>();
            InitializeClients();
        }

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            return Task.FromResult(this.clients.SingleOrDefault(c => c.ClientId.Equals(clientId)));
        }
        private void InitializeClients()
        {
            foreach (var client in this.GetClientsInternal())
            {
                try
                {
                    client.ClientSecrets = this.GetSecretsFor(client);
                    this.clients.Add(client);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private IEnumerable<Client> GetClientsInternal()
        {

            yield return new Client
            {
                ClientId = "admin.client",
                ClientName = "Admin",
                Enabled = true,
                AllowedScopes = new List<string>
                {
                    KnownScopes.Admin,
                   KnownScopes.User,

                },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                RequireConsent = false,
                AccessTokenLifetime = 1200,
                AccessTokenType = AccessTokenType.Jwt
            };
            yield return new Client
            {
                ClientId = "user.client",
                ClientName = "User",
                Enabled = true,
                AllowedScopes = new List<string>
                {
                  KnownScopes.User,

                },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                RequireConsent = false,
                AccessTokenLifetime = 1200,
                AccessTokenType = AccessTokenType.Jwt
            };


        }

        private List<Secret> GetSecretsFor(Client client)
        {
            var secretKey = client.ClientId + ".secret";
            var secret = Secrets.GetClientIdSecrets().Where(a => a.ClientId == secretKey).Select(a => a.ClientSecret).FirstOrDefault();
            if (string.IsNullOrEmpty(secret))
            {
                throw new Exception($"{secretKey} environment variable is not set.  See DSCConfiguration\\non_production_client_secrets.bat");
            }
            return new List<Secret> { new Secret(secret.Sha256()) };
        }
    }
}
