
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorTicTacToe.Client.Pages
{
    public partial class Lobby 
    {
        private HubConnection? hubConnection;
        [Inject]
        private NavigationManager? NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/gamehub"))
                .Build();

            await hubConnection.StartAsync();
        }
    }
}
