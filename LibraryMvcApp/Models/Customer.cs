using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LibraryMvcApp.Models
{
    public class Customer : IdentityUser
    {
        //[Key]
        //public int CustomerId { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name = "Låntagare")]
        public string? CustomerFullName { get; set; } = String.Empty;

        //[EmailAddress(ErrorMessage = "Invalid email address")]
        //[Required(ErrorMessage = "Email is required")]
        //public string Email { get; set; }
        //public string PasswordHash { get; set; }
        [Display(Name = "Lånehistorik")]
        public List<BookLoan>? BookLoans { get; set; }

        public Customer()
        {
        }
        public Customer(string customerFirstName, string customerLastName, string email)
        {
            CustomerFullName = customerFirstName + " " + customerLastName;
            Email = email;
        }
    }
}
