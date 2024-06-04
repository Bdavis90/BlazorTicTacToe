using Microsoft.AspNetCore.SignalR;

namespace BlazorTicTacToe.Hubs
{
    public class GameHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"Player with Id '{Context.ConnectionId}' connected.");
            return base.OnConnectedAsync();
        }
    }
}
