using Microsoft.AspNetCore.SignalR;
using bagit_api.Models;
using System.Threading.Tasks;

namespace bagit_api.Hubs;

public class ListHub : Hub
{
    public async Task AddItemToList(string itemName, string quantity)
    {
        TestList.List.AddItem(new Product
        {
            Name = itemName,
            Quantity = int.Parse(quantity),
            MockShoppingListId = 1
        });
        await Clients.All.SendAsync("ItemsUpdated", TestList.List.GetList().ToArray());
    }
    public async Task RemoveItemFromList(string name)
    {
        TestList.List.DeleteItem(name);
        await Clients.All.SendAsync("ItemsUpdated", TestList.List.GetList());
    }
}