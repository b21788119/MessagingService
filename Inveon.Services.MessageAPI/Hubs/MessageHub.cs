using Microsoft.AspNetCore.SignalR;
namespace Inveon.Services.MessageAPI.Hubs;

public class MessageHub : Hub
{
    public override Task OnConnectedAsync()
    {
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        return base.OnDisconnectedAsync(exception);
    }



}
