using Domain.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ICategoryService _categoryService;

        public CustomerController(ICustomerService customerService, ICategoryService categoryService)
        {
            _customerService = customerService;
            _categoryService = categoryService;
        }

        public async Task<ActionResult> Index()
        {
            var categoryNames = _categoryService.GetCategoryNames();
            ViewBag.Categories = null;//new MultiSelectList(categoryNames, "CategoryId", "CategoryName");

            var customersDto = await _customerService.GetPage(1, 25, "", "");

            return View(customersDto);
        }
    }
}