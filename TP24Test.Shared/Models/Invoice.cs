using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP24Test.Shared.Enums;

namespace TP24Test.Shared.Models
{
    public class Invoice
    {

        [Required]
        [Key]
        public Guid Reference { get; set; } = Guid.NewGuid();
        [Required]
        public string CurrencyCode { get; set; }
        [Required]
        public string IssueDate { get; set; }
        [Required]
        public double OpeningValue { get; set; }
        [Required]
        public double PaidValue { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public bool Cancelled { get; set; }
        [Required]
        public string DebtorName { get; set; }
        [Required]
        public string DebtorReference { get; set; }
        public string DebtorAddress1 { get; set; }
        public string DebtorAddress2 { get; set; }
        public string DebtorTown { get; set; }
        public string DebtorState { get; set; }
        public string DebtorZip { get; set; }
        [Required]
        public string DebtorCountryCode { get; set; }
        public string DebtorRegistrationNumber { get; set; }

        [NotMapped]
        public string Status
        {
            get
            {
                return ClosedDate != null && ClosedDate.Value < DateTime.Now ? InvoiceStatus.Closed.ToString() : InvoiceStatus.Open.ToString();
            }
        }
    }

}
