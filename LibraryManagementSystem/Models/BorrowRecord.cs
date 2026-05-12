using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class BorrowRecord
    {
        public int Id { get; set; }

        [Required]
        public int MemberId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Borrow date is required")]
        public DateTime BorrowDate { get; set; }

        [Required(ErrorMessage = "Due date is required")]
        public DateTime DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

        public decimal FineAmount { get; set; }

        public Member Member { get; set; }
        public Book Book { get; set; }
    }
}