using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class TransactionController : Controller
    {
        private ITransactionService _transactionService { get; }

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<ActionResult> Index()
        {
            var minDate = await _transactionService.GetMinTransactionDate();
             
            return View();
        }
    }
}