using Domain.Dtos;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace Web.ViewModels
{
    public class CustomerFormViewModel
    {
        public string CustomerName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FromDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ToDate { get; set; }
        public IEnumerable<SelectListItem> CategoryNames { get; set; }
        public int SelectedCategoryId { get; set; }
        
        public CustomerDetailsDto SelectedCustomer { get; set; }
        public IEnumerable<CustomerListDto> Customers { get; set; }


        public static CustomerFormViewModel Create(IEnumerable<CustomerListDto> customers, DateTime? fromDate,
            DateTime? toDate, IEnumerable<CategoryNameDto> categoryNames, int selectedCategoryId, string customerName)
        {
            if (categoryNames == null)
                categoryNames = new List<CategoryNameDto>();

            var categoryNamesSelectList = categoryNames.Select(c => new SelectListItem()
            {
                Text = c.CategoryName,
                Value = c.CategoryId.ToString()
            });

            return new CustomerFormViewModel()
            {
                Customers = customers ?? new List<CustomerListDto>(),
                FromDate = fromDate ?? CustomerService.DefaultDateFrom,
                ToDate = toDate ?? CustomerService.DefaultDateTo,
                CategoryNames = categoryNamesSelectList,
                CustomerName = customerName,
                SelectedCategoryId = selectedCategoryId
            };
        }
    }
}