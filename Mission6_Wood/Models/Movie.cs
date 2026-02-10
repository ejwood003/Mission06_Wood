// Ethan Wood - Section 2
// Movie.cs - Model representing a single movie in the collection (maps to Movies table)

using System.ComponentModel.DataAnnotations;

namespace Mission6_Wood.Models;

public class Movie
{
    // Primary key for the database; auto-generated when a new movie is added
    [Key]
    public int MovieId { get; set; }

    // Required field: category of the film (e.g. Comedy, Drama, Family)
    [Required(ErrorMessage = "Category is required")]
    public string Category { get; set; } = "";
    
    // Required field: title of the movie
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = "";
    
    // Required field: release year (nullable type for model binding with optional form value)
    [Required(ErrorMessage = "Year is required")]
    public int? Year { get; set; }
    
    // Required field: director name(s)
    [Required(ErrorMessage = "Director is required")]
    public string Director { get; set; } = "";
    
    // Required field: rating (e.g. G, PG, PG-13, R)
    [Required(ErrorMessage = "Rating is required")]
    public string Rating { get; set; } = "";
    
    // Optional: whether the movie was edited (yes/no); stored as true/false in database
    public bool? Edited { get; set; }
    
    // Optional: person the movie was lent to, if any
    public string? LentTo { get; set; }
    
    // Optional: notes; limited to 25 characters for display/storage
    [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters")]
    public string? Notes { get; set; }
}
