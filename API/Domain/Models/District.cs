using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class District
    {
        //Used to construct object from database data
        public District(int id, string name, int main_sm)
        {
            Id = id;
            MainSalesmanId= main_sm;
            Name = name;
        }
        public string Name { get; set; }
        public int MainSalesmanId { get; set; }
        public int Id { get; set; }
    }
}
