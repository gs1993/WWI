using System.Collections.Generic;
using Domain.Dtos;

namespace Domain.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryNameDto> GetCategoryNames(bool orderByNameDesc = false);
    }
}