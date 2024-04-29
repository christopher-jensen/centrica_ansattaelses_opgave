using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Domain.Models
{
    public class Store
    {
        public Store(int id, int district_id, string name)
        {
            Id = id;
            DistrictId = district_id;
            Name = name;
        }
        public int Id { get; }
        public int DistrictId { get; }
        public string Name { get; set; }
    }
}
