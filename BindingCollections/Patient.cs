using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BindingCollections
{
    public class Patient : INotifyPropertyChanged
    {
        private string _id = string.Empty;
        public string Id
        {
            get => _id;
            set => _id = value;
        }
        private string _name = string.Empty;
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
        private string _lastname = string.Empty;
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
        private string _middlename = string.Empty;
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
        private string _birthday = string.Empty;
        public string Birthday
        {
            get => _birthday;
            set
            {
                if (_birthday != value)
                {
                    _birthday = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _number = string.Empty;
        public string Number
        {
            get => _number;
            set
            {
                if (_number != value)
                {
                    _number = value;
                    OnPropertyChanged();
                }
            }
        }
        private ObservableCollection<AppointmentStory> _lastAppointments = new ObservableCollection<AppointmentStory>();
        public ObservableCollection<AppointmentStory> LastAppointment
        {
            get => _lastAppointments;
            set
            {
                if (_lastAppointments != value)
                {
                    _lastAppointments = value;
                    OnPropertyChanged();
                }
            }
        }
        

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public Patient()
        {

        }

        public Patient(string name, string lastname, string middlename, string birthday, string number, ObservableCollection<AppointmentStory> lastAppointment)
        {
            Number = number;
            Name = name;
            LastName = lastname;
            MiddleName = middlename;
            Birthday = birthday;
            Number = number;
            LastAppointment = lastAppointment;
        }

    }
}
