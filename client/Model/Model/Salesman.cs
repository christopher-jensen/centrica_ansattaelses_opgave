using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Model
{
    public class Salesman : ISalesman
    {
        public Salesman(string firstName, string middelName, string Lastname)
        {
            fullName = firstName ;
        }
        public string fullName => throw new NotImplementedException();

        public string firstName => throw new NotImplementedException();

        public string lastName => throw new NotImplementedException();

        public IEnumerable<IDistrict> GetDistricts()
        {
            throw new NotImplementedException();
        }
    }
}
