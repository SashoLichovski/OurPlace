using Microsoft.AspNetCore.SignalR;

namespace OurPlace.Hubs
{
    public class ChatHub : Hub
    {
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
    }
}
