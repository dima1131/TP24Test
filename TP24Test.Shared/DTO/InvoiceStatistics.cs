using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP24Test.Shared.Models;

namespace TP24Test.Shared.DTO
{
    public class InvoiceStatistics
    {
        public IEnumerable<Invoice> OpenInvoives { get; set; }
        public IEnumerable<Invoice> ClosedInvoices { get; set; }
        public double TotalOpenInvoices
        {
            get
            {
                return OpenInvoives.Sum(x => x.OpeningValue);
            }
        }
        public double TotalClosedInvoices
        {
            get
            {
                return ClosedInvoices.Sum(x => x.OpeningValue);
            }
        }
    }
}
