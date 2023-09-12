using Microsoft.AspNetCore.Mvc;
using TP24Test.Services.Invoices;
using TP24Test.Shared.DTO;
using TP24Test.Shared.Models;

namespace TP24Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
       


        private readonly ILogger<TransactionController> _logger;
        private readonly IInvoiceService _transactionService;
        public TransactionController(ILogger<TransactionController> logger, IInvoiceService transactionService)
        {
            _logger = logger;
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<IEnumerable<Invoice>> Get()
        {
            return  _transactionService.GetInvoicesAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Invoice>> Create(Invoice transaction)
        {
            await _transactionService.CreateInvoiceAsync(transaction);

            return CreatedAtAction(nameof(Get), new { reference = transaction.Reference }, transaction);
        }
        [HttpPut]
        public async Task<ActionResult> Update(Invoice transaction)
        {
            await _transactionService.UpdateInvoiceAsync(transaction);

            return NoContent();
        }

        [HttpGet("GetStatisstics")]
        public async Task<ActionResult<InvoiceStatistics>> GetStatisstics()
        {
            return await _transactionService.GetInvoiceStatisticsAsync();
        }

    }
}