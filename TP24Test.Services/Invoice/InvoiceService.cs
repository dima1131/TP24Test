using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP24Test.Repository.Data;
using TP24Test.Shared.DTO;
using TP24Test.Shared.Models;

namespace TP24Test.Services.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly TP24Context _context;

        public InvoiceService(TP24Context context)
        {
            _context = context;
        }

        public IQueryable<Invoice> GetInvoicesAsync()
        {
            return _context.Invoices.AsQueryable();
        }

        private async Task<IEnumerable<Invoice>> GetOpenInvoices()
        {
            return await _context.Invoices.Where(x => x.ClosedDate == null).ToListAsync();
        }
        private async Task<IEnumerable<Invoice>> GetClosedInvoices()
        {
            return await _context.Invoices.Where(x => x.ClosedDate != null).ToListAsync();
        }

        public async Task<Invoice> GetInvoiceAsync(Guid reference)
        {
            return await _context.Invoices.FindAsync(reference);
        }

        public async Task<Invoice> CreateInvoiceAsync(Invoice transaction)
        {
            _context.Invoices.Add(transaction);
            await _context.SaveChangesAsync();

            return transaction;
        }

        public async Task UpdateInvoiceAsync(Invoice transaction)
        {
            _context.Entry(transaction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInvoiceAsync(Guid reference)
        {
            var transaction = await GetInvoiceAsync(reference);

            _context.Invoices.Remove(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task<InvoiceStatistics> GetInvoiceStatisticsAsync()
        {
            InvoiceStatistics statistics = new InvoiceStatistics();
            statistics.OpenInvoives = await GetOpenInvoices();
            statistics.ClosedInvoices = await GetClosedInvoices();

            return statistics;
        }
    }
}
