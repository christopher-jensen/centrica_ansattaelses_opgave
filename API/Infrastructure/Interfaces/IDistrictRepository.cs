using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ìnfrastructure.Interfaces
{
    public interface IDistrictRepository
    {
        Task<IEnumerable<District>> GetAllDistrics();
        Task<Salesman> GetMainSalesman(string districtName);
        Task<IEnumerable<Salesman>> GetSalesmen(string districtName);
        Task<IEnumerable<Store>> GetStoresByDistrictName(string districtName);
        Task<int> AddSalesManToDistrict (int salesManId, string districtName, bool isMain);
    }
}
