namespace bagit_api.Models;
public class List
{
    public int? Id { get; set; }
    public string? Owner { get; set; }
    public Item[]? Items { get; set; }
}