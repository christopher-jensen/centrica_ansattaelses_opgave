using Ìnfrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly SqlConnection _conn;

        public StoreRepository(SqlConnection conn)
        {
            _conn = conn;
        }
    }
}
