using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Member is required")]
        public int MemberId { get; set; }

        [Required(ErrorMessage = "Book is required")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Comment is required")]
        [StringLength(300, ErrorMessage = "Comment cannot be more than 300 characters")]
        public string Comment { get; set; }

        [DataType(DataType.Date)]
        public DateTime FeedbackDate { get; set; }

        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
    }
}