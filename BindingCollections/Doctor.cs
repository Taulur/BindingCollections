using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BindingCollections
{
    public class Doctor : INotifyPropertyChanged
    {
        private int _id = 0;
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _name = "";
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _lastname = "";
        public string LastName
        {
            get => _lastname;
            set
            {
                if (_lastname != value)
                {
                    _lastname = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _middlename = "";
        public string MiddleName
        {
            get => _middlename;
            set
            {
                if (_middlename != value)
                {
                    _middlename = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _specialisation = "";
        public string Specialisation
        {
            get => _specialisation;
            set
            {
                if (_specialisation != value)
                {
                    _specialisation = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _password = "";
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public Doctor()
        {
        }

        public Doctor(int id,string name, string lastname, string middlename, string specialisation, string password)
        {
            Id = id;
            Name = name;
            LastName = lastname;
            MiddleName = middlename;
            Specialisation = specialisation;
            Password = password;
        }

    }
}
