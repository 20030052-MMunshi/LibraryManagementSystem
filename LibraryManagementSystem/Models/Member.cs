using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Member name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be more than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(15, ErrorMessage = "Phone number cannot be more than 15 characters")]
        public string Phone { get; set; }

        public virtual ICollection<BorrowRecord> BorrowRecords { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}