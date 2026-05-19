using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public class BorrowRecord
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Member is required")]
        public int MemberId { get; set; }

        [Required(ErrorMessage = "Book is required")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Borrow date is required")]
        [DataType(DataType.Date)]
        public DateTime BorrowDate { get; set; }

        [Required(ErrorMessage = "Due date is required")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [StringLength(30, ErrorMessage = "Status cannot be more than 30 characters")]
        public string Status { get; set; }

        [Range(0, 500, ErrorMessage = "Fine amount must be between 0 and 500")]
        public decimal FineAmount { get; set; }

        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
    }
}