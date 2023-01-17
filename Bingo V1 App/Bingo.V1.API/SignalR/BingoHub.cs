using Microsoft.AspNetCore.SignalR;

namespace Bingo.V1.API.SignalR;

public class BingoHub :Hub
{   public async Task SendMessage(string playerName, string selectedButton)
    {
        await Clients.All.SendAsync("ReceiveMessage", playerName, selectedButton);
    }
}
