using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace client.Model
{
    public class Salesman : INotifyPropertyChanged
    {
        private int _id;
        private int _districtId;
        private string? _firstName;
        private string? _middleName;
        private string? _lastName;

        public Salesman(int id, int districtId, string firstName, string middleName, string lastName)
        {
            Id = id;
            DistrictId = districtId;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public int Id { get => _id; set
            {
                if (_id!= value)
                {
                    _id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }

        public int DistrictId
        {
            get => _districtId; set
            {
                if (_districtId != value)
                {
                    _districtId = value;
                    RaisePropertyChanged("DistrictId");
                }
            }
        }

        public string FirstName { get => _firstName; set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    RaisePropertyChanged("FirstName");
                    RaisePropertyChanged("FullName");
                }
            }
        }
        public string MiddleName {
            get => _middleName; set
            {
                if (_middleName != value)
                {
                    _middleName = value;
                    RaisePropertyChanged("MiddleName");
                    RaisePropertyChanged("FullName");
                }
            }
        }
        public string LastName {
            get => _lastName; set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    RaisePropertyChanged("LastName");
                    RaisePropertyChanged("FullName");
                }
            }
        }

        public string FullName
        {
            get
            {
                if (MiddleName == null) { return FirstName + " " + LastName; }
                else { return FirstName + " " + MiddleName + " " + LastName; }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
