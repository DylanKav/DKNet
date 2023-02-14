namespace DKNET.Core
{
    public interface DKCore
    {
        void AddUser(ClientData newClient);

        void RemoveUser(ClientData removedClient);
        
    }
}