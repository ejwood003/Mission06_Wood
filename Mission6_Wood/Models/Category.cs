using System.ComponentModel.DataAnnotations;

namespace Mission6_Wood.Models;

public class Category
{
    [Key]
    public int CategoryID { get; set; }
    
    public string CategoryName { get; set; }
}