using System.Linq;
using bagit_api.Data;
using Microsoft.EntityFrameworkCore;

namespace bagit_api.Models;
public class BagList
{
    //public int Id { get; set; }
    public string? Owner { get; set; }
    public List<Item>? Items = new List<Item>();
    private readonly BagItDbContext _context;

    public BagList()
    {
        // TODO: Refactor this
        var optionsBuilder = new DbContextOptionsBuilder<BagItDbContext>();
        optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");

        _context = new BagItDbContext(optionsBuilder.Options);
    }

    public void AddItem(string itemName, string quantity)
    {
        
        Console.WriteLine(itemName);
        Console.WriteLine(quantity);
        
        
        // TODO: Let caller pass these parameters in
        int listId = 1;
        int userId = 1;

        var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
        var list = _context.ShoppingLists.FirstOrDefault(sl => sl.ListId == listId);

        var product = new Product
        {
            Name = itemName,
            Quantity = int.Parse(quantity)
        };

        var slProduct = new ShoppingListProduct
        {
            ListId = listId,
            Product = product
        };

        _context.Add(slProduct);
        _context.SaveChanges();
    }
    public void DeleteItem(string name)
    {
        Console.WriteLine(name);
        _context.Products.RemoveRange(_context.Products.Where(
            p => p.Name == name
            ));
        _context.SaveChanges();
    }

    public List<Product> GetList()
    {
        return _context.Products.ToList();
    }
}