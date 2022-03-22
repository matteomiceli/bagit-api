using Microsoft.AspNetCore.SignalR;
using bagit_api.Models;

namespace bagit_api.Hubs;

public class ListHub : Hub
{
    public async Task AddItemToList(string itemName, string quantity)
    {
        TestList.List.AddItem(itemName, quantity);
        await Clients.All.SendAsync("ItemsUpdated", TestList.List.GetList().ToArray());
    }
    public async Task RemoveItemFromList(string name)
    {
        TestList.List.DeleteItem(name);
        await Clients.All.SendAsync("ItemsUpdated", TestList.List.GetList());
    }

    public async Task GetList(string Id) {
        await Clients.All.SendAsync("ItemsUpdated", TestList.List.GetList());
    }
}