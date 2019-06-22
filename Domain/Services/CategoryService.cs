using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CategoryService : ServiceBase, ICategoryService
    {
        public CategoryService(WideWorldImportersEntities db) : base(db)
        {
        }

        //TODO: Add cache
        public IEnumerable<CategoryNameDto> GetCategoryNames(bool orderByNameDesc = false)
        {
            var categories = Context.CustomerCategories
                .OrderBy(c => c.CustomerCategoryName)
                .Select(c => new CategoryNameDto()
                {
                    CategoryId = c.CustomerCategoryID,
                    CategoryName = c.CustomerCategoryName
                })
                .AsQueryable();

            if (orderByNameDesc)
                categories = categories.OrderByDescending(c => c.CategoryName);

            return categories.ToList();
        }
    }
}
