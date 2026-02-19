// Ethan Wood - Section 2
// Movie.cs - Model representing a single movie in the collection (maps to Movies table)

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Wood.Models;

public class Movie
{
    // Primary key for the database; auto-generated when a new movie is added
    [Key]
    public int MovieId { get; set; }

    // Optional: category of the film (e.g. Comedy, Drama, Family)
    [ForeignKey("CategoryID")]
    public int? CategoryID { get; set; }
    public Category? Category { get; set; }
    
    // Required field: title of the movie
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = "";
    
    // Required field: release year (nullable type for model binding with optional form value)
    [Required(ErrorMessage = "Year is required")]
    [Range(1888, 10000, ErrorMessage = "Year cannot be before 1888")]
    public int Year { get; set; }
    
    // Optional field: director name(s)
    public string? Director { get; set; } = "";
    
    // Optional field: rating (e.g. G, PG, PG-13, R)
    public string? Rating { get; set; }
    
    // Required: whether the movie was edited (yes/no); stored as true/false in database
    [Required(ErrorMessage = "Please enter whether the movie was edited or not")]
    public bool Edited { get; set; }
    
    // Required: whether the movie was copied to plex; stored as true/false in database
    [Required(ErrorMessage = "Please enter whether the movie was copied to plex or not")]
    public bool CopiedToPlex { get; set; }
    
    // Optional: person the movie was lent to, if any
    public string? LentTo { get; set; }
    
    // Optional: notes; limited to 25 characters for display/storage
    [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters")]
    public string? Notes { get; set; }
}
