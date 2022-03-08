using System.ComponentModel.DataAnnotations;

namespace bagit_api.Models;

public class User
{
    [Key]
    public int UserId { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Password { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    
    public virtual ICollection<ShoppingList> Lists { get; set; }
}