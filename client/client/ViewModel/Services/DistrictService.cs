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
using System.Windows;

namespace ViewModel.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly HttpClient _client;

        public DistrictService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7269/District/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<District>> GetDistricts()
        {
            IEnumerable<District> districst;
            HttpResponseMessage res = await _client.GetAsync("GetDistricts");
            if (res.IsSuccessStatusCode)
            {
                districst = await res.Content.ReadFromJsonAsync<IEnumerable<District>>();
                return districst;
            }
            else
            {
                throw new Exception(res.StatusCode.ToString());
                //throw new Exception("Could not retrieve districts");
            }
        }

        public async Task<Salesman> GetMainSalesMan(string districtName)
        {
            Salesman salesman;
            HttpResponseMessage res = await _client.GetAsync("Salesman/GetMainSalesman/" + districtName);
            if (res.IsSuccessStatusCode)
            {
                salesman = await res.Content.ReadFromJsonAsync<Salesman>();
                return salesman;
            }
            else
            {
                string error = await res.Content.ReadAsStringAsync();
                throw new Exception(error);
            }
        }

        public async Task<IEnumerable<Salesman>> GetSalesmen(string districtName)
        {
            IEnumerable<Salesman> salesmen;
            HttpResponseMessage res = await _client.GetAsync("Salesman/GetSalesmen/" + districtName);
            if (res.IsSuccessStatusCode) 
            {
                salesmen = await res.Content.ReadFromJsonAsync<IEnumerable<Salesman>>();
                return salesmen;
            } 
            else 
            {
                string error = await res.Content.ReadAsStringAsync();
                throw new Exception(error);
            }
        }


        public async Task<IEnumerable<Store>> GetStores(string districtName)
        {
            IEnumerable<Store> stores;
            HttpResponseMessage res = await _client.GetAsync("GetStores/" + districtName);
            if (res.IsSuccessStatusCode)
            {
                stores = await res.Content.ReadFromJsonAsync<IEnumerable<Store>>();
                return stores;
            }
            else
            {
                string error = await res.Content.ReadAsStringAsync();
                throw new Exception(error);
            }
        }

        public async Task UpdateSalesman(int salesmanId, bool isMain, string districtName)
        {
            HttpResponseMessage res = await _client.PutAsync("Salesman/" + salesmanId + "/district/" + districtName + "/isMain-" + isMain, null);
            if (res.IsSuccessStatusCode) {
                return;
            }
            else
            {
                string error = await res.Content.ReadAsStringAsync();
                throw new Exception(error);
            }
        }

    }
}
