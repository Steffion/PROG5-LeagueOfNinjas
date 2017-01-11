using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using PROG5_LeagueOfNinjas.Data;
using PROG5_LeagueOfNinjas.ViewModel.Ninjas;
using System.Data.Entity;

namespace PROG5_LeagueOfNinjas.ViewModel.Equipment
{
    public class EquipmentCreateViewModel : ViewModelBase
    {
        private Data.Equipment _equipment;
        private string _equipmentName;
        private int _equipmentValue;
        private EquipmentListViewModel _listViewModel;
        private Entities _database;

        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public EquipmentCreateViewModel(EquipmentListViewModel listViewModel, Entities database)
        {
            _equipment = new Data.Equipment();
            _equipmentName = "New Item";
            _equipmentValue = 500;
            _listViewModel = listViewModel;
            _database = database;

            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
        }

        public Data.Equipment Equipment
        {
            get
            {
                return _equipment;
            }

            set
            {
                _equipment = value;
                RaisePropertyChanged("Equipment");
            }
        }

        public string EquipmentName
        {
            get
            {
                return _equipmentName;
            }

            set
            {
                _equipmentName = value;
                RaisePropertyChanged("EquipmentName");
            }
        }

        public int EquipmentValue
        {
            get
            {
                return _equipmentValue;
            }

            set
            {
                _equipmentValue = value;
                RaisePropertyChanged("EquipmentValue");
            }
        }

        public void Cancel()
        {
            _listViewModel.CloseCreateEquipment();
        }

        public void Save()
        {
            _equipment.Name = EquipmentName;
            _equipment.Value = EquipmentValue;
            _database.Equipments.Add(_equipment);
            _database.SaveChanges();
            _listViewModel.CloseCreateEquipment();
        }
    }
}
