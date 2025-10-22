using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BindingCollections
{
    public class AppointmentStory : INotifyPropertyChanged
    {
        private string _date = "";
        public string Date
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged();
                }
            }
        }
        private Doctor _doctor;
        public Doctor Doctor
        {
            get => _doctor;
            set
            {
                if (_doctor != value)
                {
                    _doctor = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _diagnosis = "";
        public string Diagnosis
        {
            get => _diagnosis;
            set
            {
                if (_diagnosis != value)
                {
                    _diagnosis = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _recomendations = "";
        public string Recomendations
        {
            get => _recomendations;
            set
            {
                if (_recomendations != value)
                {
                    _recomendations = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public AppointmentStory()
        {

        }

       public AppointmentStory(string _date, Doctor _doctor, string _diagnosis, string _recomendations)
        {
            Date = _date;
            Doctor = _doctor;
            Diagnosis = _diagnosis;
            Recomendations = _recomendations;
        }



    }
}
