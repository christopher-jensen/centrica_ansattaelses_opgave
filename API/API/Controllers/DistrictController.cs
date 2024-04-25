using Ìnfrastructure.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Infrastructure.Repositories;
using MySqlConnector;

namespace API.Controllers
{
    [Route("/District")]
    public class DistrictController : Controller
    {
        private readonly IDistrictRepository _districtRepository;

        public DistrictController(IDistrictRepository repo)
        {
            _districtRepository = repo;
        }


        [HttpGet("GetDistricts")]
        public async Task<IActionResult> GetDistricts() {
            try
            {
                IEnumerable<District> result = await _districtRepository.GetAllDistrics();
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetStores/{district_id}")]
        public async Task<IActionResult> GetStoresByDistrict([FromRoute] int district_id)
        {
            try
            {
                IEnumerable<Store> stores = await _districtRepository.GetStoresByDistrictId(district_id);
                return Ok(stores);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddSalesman")]
        public async Task<IActionResult> AddSalesManToDistrict([FromBody] int district_id, [FromBody] bool is_main, [FromBody] int salesmanId)
        {
            try
            {
                Console.WriteLine(district_id +" " + is_main + "" + salesmanId);
                int result = await _districtRepository.AddSalesManToDistrict(salesmanId, district_id, is_main);  
                if (result > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Could not add salesman");
                }
            } catch(Exception ex)
            {
                return BadRequest("Could not add salesman. It seems that the salesman does not exists in the database");
            }

        }

    }
}
