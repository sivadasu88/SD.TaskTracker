using System.Collections.Generic;

namespace SD.TaskTracker.IdentityServer
{
    public class Secrets
    {
        public static List<Clients> GetClientIdSecrets()
        {
            return new List<Clients>()
            {
                new Clients()
                {
                    ClientId="admin.client.secret",
                    ClientSecret="F9F10A06-7709-4359-85F5-C71059669374"
                },
                new Clients()
                {
                    ClientId = "user.client.secret",
                    ClientSecret = "F9F10A06-7709-4359-85F5-C71059669373"
                },

            };
        }
    }
}