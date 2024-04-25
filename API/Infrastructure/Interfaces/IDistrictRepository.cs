using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Ìnfrastructure.Interfaces
{
    public interface IDistrictRepository
    {
        Task<IEnumerable<District>> GetAllDistrics();
        Task<Salesman> GetMainSalesman(int salesmanid);
        Task<IEnumerable<Store>> GetStoresByDistrictId(int districtId);
        Task AddSalesManToDistrict (Salesman salesMan, int districtId, bool isMain);
    }
}
