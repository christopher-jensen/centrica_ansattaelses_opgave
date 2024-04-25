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
    public class SalesmanRepository : ISalesmanRepository
    {
        private readonly SqlConnection _conn;

        public SalesmanRepository(SqlConnection conn)
        {
            _conn = conn;
        }
    }
}
