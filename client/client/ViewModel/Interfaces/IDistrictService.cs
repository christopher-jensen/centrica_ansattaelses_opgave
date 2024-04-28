using client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Interfaces
{
    public interface IDistrictService
    {
        Task<IEnumerable<District>> GetDistricts();
        Task<IEnumerable<Store>> GetStores(int districtId);
        Task<IEnumerable<Salesman>> GetSalesmen(int districtId);
    }
}
