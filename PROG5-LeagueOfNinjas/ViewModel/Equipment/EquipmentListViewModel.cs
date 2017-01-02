using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PROG5_LeagueOfNinjas.Data;
using PROG5_LeagueOfNinjas.View.Equipment;

namespace PROG5_LeagueOfNinjas.ViewModel.Equipment
{
    class EquipmentListViewModel : ViewModelBase
    {
        private LeagueOfNinjasDatabaseEntities _database;
        private Ninja _selectedNinja;
        private EquipmentEditView _editView;

        public ICommand EquipementEditCommand { get; set; }

        public EquipmentListViewModel(LeagueOfNinjasDatabaseEntities database)
        {
            _database = database;

            EquipementEditCommand = new RelayCommand(editEquipment);
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
            get
            {
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

        public void editEquipment()
        {
            _editView = new EquipmentEditView();
            _editView.ShowDialog();
        }
    }
}
