
using Microsoft.AspNetCore.SignalR;
namespace CyberTech_Backend.Hubs
{
    public class GameHub : Hub
    {
        //register incomming connection
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ReceiveMessage", "System", $"{Context.ConnectionId} joined the chat");
            await base.OnConnectedAsync();
        }

    }
}
