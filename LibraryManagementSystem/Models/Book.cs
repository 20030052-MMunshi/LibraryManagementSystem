using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Book title is required")]
        [StringLength(100, ErrorMessage = "Title cannot be more than 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author name is required")]
        [StringLength(80, ErrorMessage = "Author name cannot be more than 80 characters")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        [StringLength(50, ErrorMessage = "Genre cannot be more than 50 characters")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "ISBN must be between 10 and 13 characters")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Availability status is required")]
        public string AvailabilityStatus { get; set; }

        public string CoverImageUrl { get; set; }
    }
}