using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface ISalesman
    {
        public string fullName { get; }
        public string firstName { get; }
        public string lastName { get; }
        public IEnumerable<IDistrict> GetDistricts();
    }
}
