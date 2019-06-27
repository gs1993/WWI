using Domain.Dtos;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Web.ViewModels
{
    public class CustomerFormViewModel
    {
        public string CustomerName { get; set; }
        public IEnumerable<SelectListItem> CategoryNames { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int[] SelectedCategoryIds { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public IEnumerable<CustomerListDto> Customers { get; set; }


        public static CustomerFormViewModel Create(IEnumerable<CustomerListDto> customers, DateTime? fromDate,
            DateTime? toDate, IEnumerable<CategoryNameDto> categoryNames, int[] selectedCategoryIds, string customerName,
            int? pageNumber, int? pageSize)
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
                SelectedCategoryIds = selectedCategoryIds ?? new int[0],
                PageNumber = pageNumber ?? 1,
                PageSize = pageSize ?? CustomerService.DefaultPageSize
            };
        }
    }
}