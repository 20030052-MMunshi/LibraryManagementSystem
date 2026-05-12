using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required]
        public int MemberId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        [StringLength(300)]
        public string Comment { get; set; }

        public Member Member { get; set; }
        public Book Book { get; set; }
    }
}