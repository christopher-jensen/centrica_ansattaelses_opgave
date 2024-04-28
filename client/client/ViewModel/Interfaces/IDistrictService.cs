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
        Task<IEnumerable<Store>> GetStores(string districtName);
        Task<IEnumerable<Salesman>> GetSalesmen(string districtName);
        Task<Salesman> GetMainSalesMan(string districtName);
        Task UpdateSalesman(int salesmanId, bool isMain, string districtName);
    }
}
