using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Ìnfrastructure.Interfaces;
using Domain.Models;
using System.Data.SqlClient;
using System.Collections.Specialized;

namespace Infrastructure.Repositories
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly SqlConnection _conn;

        public DistrictRepository(SqlConnection conn)
        {
            _conn = conn;
        }

        public async Task<IEnumerable<District>> GetAllDistrics()
        {
            IEnumerable<District> districts = await _conn.QueryAsync<District>("SELECT * FROM district");
            return districts;
        }

        public async Task<Salesman> GetMainSalesman(int salesmanid)
        {
            string sql = "SELECT s.id, s.first_name, s.middle_name, s.last_name" +
                         "FROM Salesman s" +
                         "WHERE s.id=" + salesmanid;

            Salesman salesman = await _conn.QueryFirstAsync<Salesman>(sql);
            return salesman;
        }

        public async Task<IEnumerable<Store>> GetStoresByDistrictId(int districtId)
        {
            string sql = "SELECT *" +
             "FROM Store s" +
             "WHERE s.district_id=" + districtId;

            IEnumerable<Store> stores = await _conn.QueryAsync<Store>(sql);
            return stores;
        }

    }
}
