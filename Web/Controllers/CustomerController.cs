﻿using Domain.Dtos;
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
            var customersDto = await _customerService.GetPage(DateTime.MinValue, DateTime.Now, 0);

            var vm = CustomerFormViewModel.Create(customersDto, null, null, categoryNames, 0, null);
            //vm.SelectedCustomer = new CustomerDetailsDto();
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Index(CustomerFormViewModel vm)
        {
            var customersDto = await _customerService.GetPage(vm.FromDate, vm.ToDate, vm.SelectedCategoryId, vm.CustomerName);
            var categoryNames = _categoryService.GetCategoryNames();

            var result = CustomerFormViewModel.Create(customersDto, vm.FromDate, vm.ToDate, categoryNames, 
                vm.SelectedCategoryId, vm.CustomerName);

            return View(result);
        }

        public async Task<ActionResult> Details(int customerId)
        {
            if (customerId < 0)
                return View("Error");

            var customer = new CustomerDetailsDto() { CustomerName = "Test Name", CustomerCategoryName = "Test categury" };

            if (Request.IsAjaxRequest())
                return PartialView("CustomerDetails", customer);

            throw new NotImplementedException();
        }
    }
}