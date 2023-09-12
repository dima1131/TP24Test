using Microsoft.EntityFrameworkCore.Query;
using TP24Test.Shared.DTO;
using TP24Test.Shared.Models;

namespace TP24Test.Services.Invoices
{
    public interface IInvoiceService
    {
        Task<Invoice> CreateInvoiceAsync(Invoice transaction);
        Task DeleteInvoiceAsync(Guid reference);
        Task<Invoice> GetInvoiceAsync(Guid reference);
        IQueryable<Invoice> GetInvoicesAsync();
        Task<InvoiceStatistics> GetInvoiceStatisticsAsync();
        Task UpdateInvoiceAsync(Invoice transaction);
    }
}