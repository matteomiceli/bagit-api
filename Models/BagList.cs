using System.Linq;

namespace bagit_api.Models;
public class BagList
{
    public int Id { get; set; }
    public string? Owner { get; set; }
    public List<Item>? Items { get; set; }

    public void AddItem(Item item)
    {
        Items.Append(item);
    }
    public void DeleteItem(int id)
    {
        Items.RemoveAll(item => item.Id == id);
    }

    public List<Item> GetList()
    {
        return this.Items;
    }
}