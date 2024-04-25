using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Salesman
    {
        public Salesman(int id, string firstName, string middleName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }
        public int Id { get;}

        public string FirstName { get;}
        public string MiddleName { get;} 
        public string LastName { get;}
    }
}
