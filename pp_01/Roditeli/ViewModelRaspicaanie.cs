using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace pp_01.Roditeli
{
    public class ViewModelRaspicaanie:Notify
    {
        public ObservableCollection<Raspicanie> _ListRaspicanie;
        public ObservableCollection<Raspicanie> ListRaspicanie
        {
            get => _ListRaspicanie ?? (_ListRaspicanie = new ObservableCollection<Raspicanie>());
            set
            {
                _ListRaspicanie = value;
                OnPropertyChanged();
            }
        }

        public ICommand
            _command_load;

        public ICommand CommandLoad => _command_load ?? (_command_load = new MyCommand(LoadRod));

        private void LoadRod()
        {
            ListRaspicanie.Clear();

            foreach (Raspicanie t in Connection.DB.Raspicanie.ToList())
            {
                ListRaspicanie.Add(t);
            }
        }

        public ViewModelRaspicaanie()
        {
            LoadRod();
        }
    }
}
 