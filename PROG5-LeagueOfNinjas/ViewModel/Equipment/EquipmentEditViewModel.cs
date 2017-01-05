using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using PROG5_LeagueOfNinjas.Data;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace PROG5_LeagueOfNinjas.ViewModel.Equipment
{
    public class EquipmentEditViewModel
    {
        private Ninja _ninja;
        private EquipmentListViewModel _listViewModel;
        private LeagueOfNinjasDatabaseEntities _database;

        private LeagueOfNinjasDatabaseEntities database;
        private EquipmentListViewModel equipmentListViewModel;

        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public EquipmentEditViewModel(EquipmentListViewModel equipmentListViewModel, LeagueOfNinjasDatabaseEntities database)
        {
            _listViewModel = equipmentListViewModel;
            _ninja = _listViewModel.SelectedNinja;
            _database = database;

            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
        }

        public Ninja Ninja
        {
            get
            {
                return _ninja;
            }

            set
            {
                _ninja = value;
                //RaisePropertyChanged("Ninja");
            }
        }


        public ObservableCollection<Data.Equipment> Equipment
        {
            get
            {
                return new ObservableCollection<Data.Equipment>(_database.Equipments);
            }
        }

        private void Save()
        {
            _listViewModel.closeEditEquipment();
        }

        private void Cancel()
        {
            //TODO implement saving
            _listViewModel.closeEditEquipment();
        }
    }
}
