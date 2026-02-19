// Ethan Wood - Section 2
// Category.cs - Model representing a movie category (maps to Categories table; used for dropdown and FK)

using System.ComponentModel.DataAnnotations;

namespace Mission6_Wood.Models;

public class Category
{
    // Primary key; matches CategoryID foreign key on Movie
    [Key]
    public int CategoryID { get; set; }

    // Display name for the category (e.g. Comedy, Drama, Family)
    public string CategoryName { get; set; }
}