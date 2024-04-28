using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace client.Model
{
    public class Store
    {
        private int _id;
        private int _districtId;
        private string _name;

        public Store(int id, int districtId, string name)
        {
            Id = id;
            DistrictId = districtId;
            Name = name;
        }
        public int Id
        {
            get => _id; set
            {
                if (_id != value)
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
        public string Name
        {
            get => _name; set
            {
                if (_name != value) 
                {
                    _name = value;
                    RaisePropertyChanged("Name"); 
                }
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
