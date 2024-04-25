using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IDistrict
    {
        public string Name { get; set; }
        public ISalesman GetMainSalesman();
        public IEnumerable<IStore> GetStores();

    }
}
