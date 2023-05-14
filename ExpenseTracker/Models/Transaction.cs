using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Range(1,int.MaxValue, ErrorMessage ="please select a category.")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "amount shoud be greater then zero.")]
        public int Amount { get; set; }


        [Column(TypeName = "nvarchar(75)")]
        public string? Note { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [NotMapped]
        public string? CategoryWithIcon
        {
            get
            {
                return Category == null ? "" : Category.Title + " " + Category.Icon;
            }
        }

        [NotMapped]
        public string? formattedamount
        {
            get
            {
                return ((Category == null || Category.Type == "Expense") ? "- " :"+ ") + Amount.ToString("c0");
            }
        }
    }
}
