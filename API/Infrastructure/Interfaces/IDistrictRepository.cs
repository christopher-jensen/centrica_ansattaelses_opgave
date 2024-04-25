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
        Task<Salesman> GetMainSalesman(int salesmanid);
        Task<IEnumerable<Store>> GetStoresByDistrictId(int districtId);
        Task<int> AddSalesManToDistrict (int salesManId, int districtId, bool isMain);
    }
}
