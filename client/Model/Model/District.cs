using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Model
{
    public class District : IDistrict
    {
        private readonly int _id;
        private int _mainSmId;
        public District(int id, string name, int mainSmId)
        {
            _id = id;
            Name = name;
            _mainSmId = mainSmId; 
        }
        public string Name => throw new NotImplementedException();

        public ISalesman GetMainSalesman()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IStore> GetStores()
        {
            throw new NotImplementedException();
        }
    }
}
