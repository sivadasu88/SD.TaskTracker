using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SD.TaskTracker.IdentityServer
{
    public class ResourceStore : IResourceStore
    {
        private readonly IEnumerable<ApiResource> apiResources;
        private readonly IEnumerable<IdentityResource> identityResource;

        public ResourceStore()
        {
            this.apiResources = GetApiResources();
            this.identityResource = GetIdentityResources();
        }

        public Task<ApiResource> FindApiResourceAsync(string name)
        {
            var apiResource = this.apiResources.FirstOrDefault(ar => ar.Name == name);
            return Task.FromResult(apiResource);
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            if (scopeNames == null) throw new ArgumentNullException(nameof(scopeNames));

            var apiResourcesEntities = from i in this.apiResources
                                       where scopeNames.Contains(i.Name)
                                       select i;
            return Task.FromResult(apiResourcesEntities);
        }

        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            if (scopeNames == null) throw new ArgumentNullException(nameof(scopeNames));

            var identityResourcesEntities = from i in identityResource
                                            where scopeNames.Contains(i.Name)
                                            select i;

            return Task.FromResult(identityResourcesEntities);
        }

        //will turn off from DiscoveryEndpoint
        public Task<Resources> GetAllResourcesAsync()
        {
            return Task.FromResult(new Resources());
        }


        private IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
            };
        }

        private IEnumerable<ApiResource> GetApiResources()
        {
            yield return new ApiResource(
                name: KnownScopes.Admin,
                displayName: "Admin"
                );
            yield return new ApiResource(
                          name: KnownScopes.User,
                          displayName: "User"
                          );
        }
    }
}
