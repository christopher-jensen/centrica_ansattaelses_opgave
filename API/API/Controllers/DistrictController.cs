using Infrastructure.Interfaces;
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

        /// <summary>
        /// Gets all districts in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetDistricts")]
        public async Task<IActionResult> GetDistricts()
        {
            try
            {
                IEnumerable<District> result = await _districtRepository.GetAllDistrics();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetStores/{districtName}")]
        public async Task<IActionResult> GetStoresByDistrict([FromRoute] string districtName)
        {
            try
            {
                IEnumerable<Store> stores = await _districtRepository.GetStoresByDistrictName(districtName);
                return Ok(stores);
            }
            catch (Exception ex)
            {
                return BadRequest("Could not find stores for district: " + districtName);
            }
        }

        /// <summary>
        /// Add a salesman to a given district. Can also change main salesman if isMain is set to true
        /// </summary>
        /// <param name="salesmanId">The id of the salesman who should be moved</param>
        /// <param name="districtName">The district to move him to (case insensitive)</param>
        /// <param name="isMain">True: set salesman to main salesman of district. False: move to another district</param>
        /// <returns></returns>
        [HttpPut("Salesman/{salesmanId}/district/{districtName}/isMain-{isMain}")]
        public async Task<IActionResult> AddSalesManToDistrict([FromRoute] int salesmanId, [FromRoute] string districtName, [FromRoute] bool isMain)
        {
            try
            {
                int result = await _districtRepository.AddSalesManToDistrict(salesmanId, districtName, isMain);
                if (result > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Could not add salesman");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Could not add salesman. It seems that the salesman does not exists in the database");
            }
        }
        /// <summary>
        /// Get salesmen for a given district
        /// </summary>
        /// <param name="districtName">Name of district who's salesmen you want</param>
        /// <returns></returns>
        [HttpGet("Salesman/GetSalesmen/{districtName}")]
        public async Task<IActionResult> GetSalesmen([FromRoute] string districtName)
        {
            try
            {
                IEnumerable<Salesman> result = await _districtRepository.GetSalesmen(districtName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Could not find salesmen for district: " + districtName);
            }
        }
        /// <summary>
        /// Gets the main salesman of the district you provide
        /// </summary>
        /// <param name="districtName">Name of the district</param>
        /// <returns></returns>
        [HttpGet("Salesman/GetMainSalesman/{districtName}")]
        public async Task<IActionResult> GetMainSalesman([FromRoute] string districtName)
        {
            try
            {
                Salesman result = await _districtRepository.GetMainSalesman(districtName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Could not find salesmen for district: " + districtName);
            }
        }
    }
}
