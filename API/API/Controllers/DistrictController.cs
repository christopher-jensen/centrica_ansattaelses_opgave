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

    }
}
