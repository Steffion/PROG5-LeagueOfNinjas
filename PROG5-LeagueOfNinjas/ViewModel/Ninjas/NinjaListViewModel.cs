using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using PROG5_LeagueOfNinjas.Data;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace PROG5_LeagueOfNinjas.ViewModel.Ninjas
{
    public class NinjaListViewModel : ViewModelBase
    {
        private LeagueOfNinjasDatabaseEntities _database;
        private Ninja _selectedNinja;

        public ICommand NinjaAddCommand { get; set; }
        public ICommand NinjaEditCommand { get; set; }
        public ICommand NinjaDeleteCommand { get; set; }

        public NinjaListViewModel(LeagueOfNinjasDatabaseEntities database)
        {
            _database = database;

            NinjaAddCommand = new RelayCommand(AddNinja);
            NinjaEditCommand = new RelayCommand(EditNinja);
            NinjaDeleteCommand = new RelayCommand(DeleteNinja);
        }

        public ObservableCollection<Ninja> Ninjas
        {
            get
            {
                return new ObservableCollection<Ninja>(_database.Ninjas);
            }
        }

        public bool IsNinjaSelected
        {
            get {
                return _selectedNinja != null;
            }
        }

        public Ninja SelectedNinja
        {
            get
            {
                return _selectedNinja;
            }

            set
            {
                _selectedNinja = value;
                RaisePropertyChanged("SelectedNinja");
                RaisePropertyChanged("IsNinjaSelected");
            }
        }

        public void AddNinja()
        {

        }

        public void EditNinja()
        {

        }

        public void DeleteNinja()
        {

        }
    }
}
