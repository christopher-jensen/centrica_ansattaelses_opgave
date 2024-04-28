using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Model
{
    public class District : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private int _mainSmId;

        public District(string name, int mainSalesmanId, int id)
        {
            Id = id;
            Name = name; 
            MainSalesmanId = mainSalesmanId;
        }
        public string Name { get => _name; set {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            } 
        }

        public int MainSalesmanId { get => _mainSmId; set
            {
                if (_mainSmId != value)
                {
                    _mainSmId = value;
                    RaisePropertyChanged("MainSmId");
                }
            } 
        }

        public int Id { get => _id; set
            {
                if (value != _id)
                {
                    _id = value;
                    RaisePropertyChanged("Id");
                }
            } }

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
