using Domain.Services;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}