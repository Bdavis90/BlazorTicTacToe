
using BlazorTicTacToeShared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorTicTacToe.Client.Pages
{
    public partial class Lobby
    {
        private HubConnection? hubConnection;
        private string playerName = string.Empty;
        private string currentRoomName = string.Empty;
        private GameRoom? currentRoom;
        private List<GameRoom> rooms = new();
        [Inject]
        private NavigationManager? NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/gamehub"))
                .Build();

            // Subscribes to the Rooms method name published by the GameHub
            hubConnection.On<List<GameRoom>>("Rooms", roomList =>
            {
                Console.WriteLine($"We got rooms! Count = {roomList.Count}");
            });
            await hubConnection.StartAsync();
        }
        private async Task CreateRoom()
        {
            if (hubConnection is null) return;

            // Calls the CreateRoom method from the GameHub
            currentRoom = await hubConnection.InvokeAsync<GameRoom>("CreateRoom", currentRoomName, playerName);
        }
    }

}
