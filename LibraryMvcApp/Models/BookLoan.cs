using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryMvcApp.Models
{
    public enum LoanStatus
    {
        Utlånad,
        Återlämnad,
        Sen,
        ÅterlämnadSent
    }
    public class BookLoan
    {
        [Key]
        public int BookLoanId { get; set; }
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        [Display(Name = "Låntagare")]
        public Customer? Customer { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        [Display(Name = "Bok")]
        public Book? Book { get; set; }
        [Display(Name = "Lånestatus")]
        public LoanStatus LoanStatus { get; set; } = LoanStatus.Utlånad;
        [Display(Name = "Lånedatum")]
        public DateTime LoanDate { get; set; }
        [Display(Name = "Sista lånedatum")]
        public DateTime LastLoanDate { get; set; }
        [Display(Name = "Återlämning")]
        public DateTime? ReturnDate { get; set; }

        public BookLoan()
        {
            LoanDate = DateTime.Now;
            LastLoanDate = LoanDate.AddDays(30);
            if (ReturnDate > LastLoanDate)
            {
                LoanStatus = LoanStatus.Sen;
            }
            else
            {
                LoanStatus = LoanStatus.Utlånad;
            }
        }
        public void UpdateLoanStatus() //determindes the status of the loan based on todays date!
        {
            if (ReturnDate.HasValue)
            {
                if (ReturnDate > LastLoanDate)
                {
                    LoanStatus = LoanStatus.ÅterlämnadSent;
                }
                else
                {
                    LoanStatus = LoanStatus.Återlämnad;
                }
            }
            else if (DateTime.Now > LastLoanDate)
            {
                LoanStatus = LoanStatus.Sen;
            }
            else
            {
                LoanStatus = LoanStatus.Utlånad;
            }
        }
        public void UpdateBookStock()
        {
            if (LoanStatus == LoanStatus.Utlånad || LoanStatus == LoanStatus.Sen)
            {
                Book.InStock = false;
            }
            else
            {
                Book.InStock = true;
            }
        }
    }
}
