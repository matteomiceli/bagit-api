using Microsoft.AspNetCore.SignalR;
using bagit_api.Models;
using System.Threading.Tasks;

namespace bagit_api.Hubs;

public class ListHub : Hub
{
    public BagList Baglist;
    public ListHub()
    {
        var list = new BagList()
        {
            Owner = "Matteo",
            Items = new List<Item>(),
        };
        this.Baglist = list;
    }
    public async Task AddItemToList(string user, string itemName, int quantity)
    {
        this.Baglist.AddItem(new Item
        {
            Name = itemName,
            Quantity = quantity
        });
        await Clients.All.SendAsync("ItemsUpdated", Baglist.GetList());
    }
    public async Task RemoveItemFromList(string user, int id)
    {
        this.Baglist.DeleteItem(id);
        await Clients.All.SendAsync("ItemsUpdated", Baglist.GetList());
    }
}