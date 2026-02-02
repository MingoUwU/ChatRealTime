using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

public class ChatHub : Hub
{
    private readonly ILogger<ChatHub> _logger;

    public ChatHub(ILogger<ChatHub> logger)
    {
        _logger = logger;
    }

    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public async Task JoinChat(string user)
    {
        _logger.LogInformation(">>> {User} joined the chat", user);
        await Clients.All.SendAsync("ReceiveMessage", "System", $"{user} joined the chat");
    }

    public async Task SendImage(string user, string imageBase64)
    {
        await Clients.All.SendAsync("ReceiveImage", user, imageBase64);
    }

    public async Task SendFile(string user, string fileName, string fileBase64)
    {
        await Clients.All.SendAsync("ReceiveFile", user, fileName, fileBase64);
    }
}
