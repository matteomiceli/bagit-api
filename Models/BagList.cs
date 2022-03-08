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

    public void AddItem(Product product)
    {
        _context.Products.Add(product);
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