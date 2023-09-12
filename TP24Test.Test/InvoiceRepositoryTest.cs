using Bogus;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using TP24Test.Repository.Data;
using TP24Test.Services.Invoices;
using TP24Test.Shared.DTO;
using TP24Test.Shared.Models;

namespace TP24Test.Test
{
    [TestClass]
    public class InvoiceRepositoryTest
    {
        List<Invoice> invoices;
        IInvoiceService invoiceService;

        [TestInitialize]
        public async Task Init()
        {
            invoices = GenerateData(10);
            var data = invoices.AsQueryable();
            var mockTP24Context = new Mock<TP24Context>();
            var mockSet = new Mock<DbSet<Invoice>>();
            mockSet.As<IQueryable<Invoice>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Invoice>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Invoice>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Invoice>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockTP24Context.Setup(x => x.Invoices).Returns(mockSet.Object);
            mockTP24Context.Setup(x => x.SaveChanges()).Returns(1);

            invoiceService = new InvoiceService(mockTP24Context.Object);
        }

        [TestMethod]
        [Priority(1)]
        public async Task create_new_invoice_test()
        {
            var invoice = GenerateData(1).First();
            var addedInvoice = await invoiceService.CreateInvoiceAsync(invoice);

            addedInvoice.Should().NotBeNull();
        }

        [TestMethod]
        [Priority(2)]
        public async Task get_all_invoices_test()
        {
            var response = invoiceService.GetInvoicesAsync().ToList();

            response.Count().Should().Be(0);
        }

        [TestMethod]
        [Priority(2)]
        public async Task update_invoice_test()
        {
            var invoice = invoices.First();
            var response = invoiceService.UpdateInvoiceAsync(invoice);

            response.Should().NotBeNull();
        }

        private List<Invoice> GenerateData(int count)
        {
            var faker = new Faker<Invoice>()
                .RuleFor(x => x.Reference, f => f.Random.Guid())
                .RuleFor(x => x.OpeningValue, f => f.Random.Double())
                .RuleFor(x => x.PaidValue, f => f.Random.Double())
                .RuleFor(x => x.CurrencyCode, f => f.Commerce.Locale)
                .RuleFor(x => x.DueDate, f => f.Date.Past())
                .RuleFor(x => x.Cancelled, f => f.Random.Bool())
                .RuleFor(x => x.DebtorName, f => f.Person.FullName.ToString())
                .RuleFor(x => x.DebtorAddress1, f => f.Person.Address.Street)
                .RuleFor(x => x.DebtorCountryCode, f => f.Person.Address.State)
                .RuleFor(x => x.DebtorReference, f => f.Person.Email);

            return faker.Generate(count);
        }


        //Task<Invoice> CreateInvoiceAsync(Invoice transaction);
        //Task DeleteInvoiceAsync(Guid reference);
        //Task<Invoice> GetInvoiceAsync(Guid reference);
        //Task<IEnumerable<Invoice>> GetInvoicesAsync();
        //Task<InvoiceStatistics> GetInvoiceStatisticsAsync();
        //Task UpdateInvoiceAsync(Invoice transaction);
    }
}