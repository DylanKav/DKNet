using System.Collections.Generic;

namespace DKNET.Core
{
    public sealed class DKServerCore : DKCore
    {
        public List<ClientData> Users = new List<ClientData>();
        
        public void AddUser(ClientData newClient)
        {
            Users.Add(newClient);
        }

        public void RemoveUser(ClientData removedClient)
        {
            Users.Remove(removedClient);
        }
    }
}