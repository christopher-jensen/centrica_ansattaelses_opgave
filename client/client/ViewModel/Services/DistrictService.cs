using ViewModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using client.Model;
using System.Net.Http.Headers;
using System.Net;

using System.Net.Http.Json;

namespace ViewModel.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly HttpClient _client;

        public DistrictService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7269/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<District>> GetDistricts()
        {
            IEnumerable<District> districst;
            Console.WriteLine(_client.BaseAddress + "District/GetDistricts");
            HttpResponseMessage res = await _client.GetAsync("District/GetDistricts");
            if (res.IsSuccessStatusCode)
            {
                districst = await res.Content.ReadFromJsonAsync<IEnumerable<District>>();
                return districst;
            }
            else
            {
                throw new Exception("Could not retrieve districts");
            }
        }

        public async Task<IEnumerable<Salesman>> GetSalesmen(int districtId)
        {
            var temp = new List<Salesman>();
            temp.Add(new Salesman(1, 1, "test", null, "test"));
            return temp;
        }

        public async Task<IEnumerable<Store>> GetStores(int districtId)
        {
            return new List<Store>();
        }
    }
}
