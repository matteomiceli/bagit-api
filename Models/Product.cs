using System.ComponentModel.DataAnnotations;

namespace bagit_api.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string? Icon { get; set; }
    public string? Category { get; set; }
    public string? Description { get; set; }
    public int? Quantity { get; set; }

    public int MockShoppingListId { get; set; }
    public MockShoppingList MockShoppingList { get; set; }
}