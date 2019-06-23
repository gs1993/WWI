using Domain.Dtos;
using System;
using System.Collections.Generic;
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
    }
}