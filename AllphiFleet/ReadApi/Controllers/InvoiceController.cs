using System.Collections.Generic;
using System.Linq;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadApi.Logging;
using ReadServices.Interfaces;

namespace ReadApi.Controllers
{
    [Route("api/invoice")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ILoggerManager _logger;
        public InvoiceController(IInvoiceService invoiceService, ILoggerManager logger)
        {
            _invoiceService = invoiceService;
            _logger = logger;
        }
        [HttpGet(Name = "getAllInvoices")]
        //authorize for test
        [Authorize] 
        public IActionResult Get()
        {

            _logger.LogInfo("Retrieving all invoices.");

            IEnumerable<InvoiceDTO> factuurDTOs = _invoiceService.GetInvoices();

            _logger.LogInfo($"retrieving {factuurDTOs.Count()} records.");

            return Ok(factuurDTOs);
        }

        [HttpGet("{id}", Name = "GetInvoice")]
        public IActionResult Get(long id)
        {
            InvoiceDTO factuurDTO = _invoiceService.GetInvoice(id);
            if (factuurDTO == null)
            {
                return NotFound("Invoice has not been found.");
            }
            return Ok(factuurDTO);
        }

    }
}
