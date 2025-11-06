using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BindingCollections
{
    public class Count : INotifyPropertyChanged
    {

        private int _countDoctor = 0;
        public int CountDoctor
        {
            get => _countDoctor;
            set
            {
                if (_countDoctor != value)
                {
                    _countDoctor = value;
                    OnPropertyChanged();
                }
            }
        }
        private int _countPatient = 0;
        public int CountPatient
        {
            get => _countPatient;
            set
            {
                if (_countPatient != value)
                {
                    _countPatient = value;
                    OnPropertyChanged();
                }
            }
        }

        public void Refresh()
        {
            CountDoctor = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.json", SearchOption.TopDirectoryOnly)
                            .Where(file => Path.GetFileName(file).Contains("D_")).Count();
            CountPatient = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.json", SearchOption.TopDirectoryOnly)
                            .Where(file => Path.GetFileName(file).Contains("P_")).Count();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        

    }
}
