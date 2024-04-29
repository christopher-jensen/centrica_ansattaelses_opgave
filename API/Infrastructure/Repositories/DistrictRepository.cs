using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Interfaces;
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
        /// <summary>
        /// Gets the main salesman of the district you provide
        /// </summary>
        /// <param name="districtName">Name of the district</param>
        /// <returns></returns>
        public async Task<Salesman> GetMainSalesman(string districtName)
        {
            string sql = "SELECT s.id, s.first_name, s.middle_name, s.last_name " +
                         "FROM Salesman s " +
                         "JOIN district d ON s.id = d.main_sm " +
                         "WHERE LOWER(d.name) = '" + districtName.ToLower() + "'"; 

            Salesman salesman = await _conn.QueryFirstAsync<Salesman>(sql);
            return salesman;
        }

        public async Task<IEnumerable<Store>> GetStoresByDistrictName(string districtName)
        {
            string sql = "SELECT s.* " +
             "FROM Store s " +
             "JOIN district d ON s.district_id = d.id " +
             "WHERE LOWER(d.name)='" + districtName.ToLower() + "'";

            IEnumerable<Store> stores = await _conn.QueryAsync<Store>(sql);
            return stores;
        }

        /// <summary>
        /// Add a salesman to a given district. Can also change main salesman if isMain is set to true
        /// </summary>
        /// <param name="salesmanId">The id of the salesman who should be moved</param>
        /// <param name="districtName">The district to move him to (case insensitive)</param>
        /// <param name="isMain">True: set salesman to main salesman of district. False: move to another district</param>
        /// <returns></returns>
        public async Task<int> AddSalesManToDistrict(int salesmanId, string districtName, bool isMain)
        {
            // Tag blot salesmanId med?
            string sql;
            if (isMain)
            {
                sql = "UPDATE district " +
                      "SET main_sm = " + salesmanId +
                      " WHERE LOWER(name) = '" + districtName.ToLower() + "'";
            }
            else
            {
                string with = "WITH district_ids as ( " +
                              "SELECT id " +
                              "FROM district " +
                              "WHERE LOWER(name) = '" + districtName.ToLower() + "'" +
                              ")";
                sql = with +
                      " UPDATE salesman " +
                      "SET district_id = (SELECT id FROM district_ids) " +
                      " WHERE id = " + salesmanId;
            }
            int rowsAffected = await _conn.ExecuteAsync(sql);
            return rowsAffected;
        }
        /// <summary>
        /// Get salesmen for a given district
        /// </summary>
        /// <param name="districtName">Name of district who's salesmen you want</param>
        /// <returns></returns>
        public async Task<IEnumerable<Salesman>> GetSalesmen(string districtName)
        {
            string sql = "SELECT s.id, s.first_name, s.middle_name, s.last_name " + 
                "FROM salesman s " + 
                "JOIN district d ON s.district_id = d.id " + 
                "WHERE LOWER(d.name) = '" + districtName.ToLower() + "'";
            IEnumerable<Salesman> salesmen = await _conn.QueryAsync<Salesman>(sql);
            return salesmen;
        }
    }
}
