using Domain.Dtos;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Web.ViewModels;

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
            var customersDto = await _customerService.GetPage(DateTime.MinValue, DateTime.Now, null);

            var vm = CustomerFormViewModel.Create(customersDto, null, null, categoryNames, null, null, null, null);

            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Index(CustomerFormViewModel vm)
        {
            var customersDto = await _customerService.GetPage(vm.FromDate, vm.ToDate, vm.SelectedCategoryIds, vm.CustomerName, vm.PageNumber, vm.PageSize);
            var categoryNames = _categoryService.GetCategoryNames();

            var result = CustomerFormViewModel.Create(customersDto, vm.FromDate, vm.ToDate, categoryNames, vm.SelectedCategoryIds,
                vm.CustomerName, vm.PageNumber, vm.PageSize);

            return View(result);
        }
    }
}