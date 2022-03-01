using Microsoft.AspNetCore.SignalR;
using bagit_api.Models;
using System.Threading.Tasks;

namespace bagit_api.Hubs;

public class ListHub : Hub
{
    public async Task AddItemToList(string user, string itemName, int quantity)
    {

        await Clients.All.SendAsync("ItemsUpdated", );
    }
    public async Task RemoveItemFromList(string user, int id)
    {
        await Clients.All.SendAsync("ItemsUpdated", );
    }
}