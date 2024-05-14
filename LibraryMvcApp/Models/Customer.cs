using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LibraryMvcApp.Models
{
    public class Customer : IdentityUser //customer inherits properties from IdentityUser
    {
        [Required]
        [MaxLength(150)]
        [Display(Name = "Låntagare")]
        public string? CustomerFullName { get; set; } = String.Empty;

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
