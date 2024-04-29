using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Salesman
    {
        // Naming forced by Dapper to map sql object
        public Salesman(int id, string first_name, string middle_Name, string last_name)
        {
            Id = id;
            FirstName = first_name;
            MiddleName = middle_Name;
            LastName = last_name;
        }
        public int Id { get;}

        public string FirstName { get;}
        public string MiddleName { get;} 
        public string LastName { get;}
    }
}
