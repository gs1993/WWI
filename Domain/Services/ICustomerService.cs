using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos;

namespace Domain.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustumerListDto>> GetPage(int pageNumber, int pageSize, string customerName, string customerCategory);
    }
}