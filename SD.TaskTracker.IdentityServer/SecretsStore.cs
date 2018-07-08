using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SD.TaskTracker.IdentityServer
{
    public class SecretsStore
    {
        public static List<Secrets> GetClientIdSecrets()
        {
            return new List<Secrets>()
            {
                new Secrets()
                {
                    ClientId="sd.client.secret",
                    ClientSecret="F9F10A06-7709-4359-85F5-C71059669374"
                },
                new Secrets()
                {
                    ClientId = "admin.client.secret",
                    ClientSecret = "4E6D6453-9785-4693-AEE3-5F9C8165E51D"
                }
            };
         }
    }
   
}
