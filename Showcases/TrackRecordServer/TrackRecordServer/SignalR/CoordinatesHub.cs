using Microsoft.AspNetCore.SignalR;

namespace TrackRecordServer.SignalR
{
    public class CoordinatesHub : Hub
    {
        // Group for Home/Index page
        public const string HomeIndexGroup = "HomeIndexGroup";

        // Entering the group when connecting
        public async Task JoinHomeIndexGroup()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, HomeIndexGroup);
        }

        // Exit group when disconnected (automatically when connection is broken)
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, HomeIndexGroup);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
