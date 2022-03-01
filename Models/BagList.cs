using System.Linq;

namespace bagit_api.Models;
public class BagList
{
    //public int Id { get; set; }
    public string? Owner { get; set; }
    public List<Item>? Items = new List<Item>();

    public void AddItem(Item item)
    {
        Items.Add(item);
    }
    public void DeleteItem(string name)
    {
        Items.RemoveAll(item => item.Name == name);
    }

    public List<Item> GetList()
    {
        return this.Items;
    }
}