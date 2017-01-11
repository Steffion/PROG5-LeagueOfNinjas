using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PROG5_LeagueOfNinjas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PROG5_LeagueOfNinjas.ViewModel.Equipment
{
    public class EquipmentEditViewModel : ViewModelBase
    {
        private Data.Equipment _equipmentItem;
        private EquipmentListViewModel _listViewModel;
        private Entities _database;
        private EquipmentListViewModel equipmentListViewModel;

        private string _equipmentName;
        private int _equipmentCost;

        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public EquipmentEditViewModel(EquipmentListViewModel equipmentListViewModel, Entities database)
        {
            _listViewModel = equipmentListViewModel;
            _equipmentItem = _listViewModel.SelectedEquipment;
            _database = database;
            _equipmentName = _equipmentItem.Name;
            _equipmentCost = _equipmentItem.Value;
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
        }

        public Data.Equipment Equipment
        {
            get
            {
                return _equipmentItem;
            }

            set
            {
                _equipmentItem = value;
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
                return _equipmentCost;
            }

            set
            {
                _equipmentCost = value;
                RaisePropertyChanged("EquipmentValue");
            }
        }

        public void Cancel()
        {
            _listViewModel.closeEditEquipment();
        }

        public void Save()
        {
            _equipmentItem.Name = EquipmentName;
            _equipmentItem.Value = EquipmentValue;
            _database.SaveChanges();
            _listViewModel.closeEditEquipment();
        }
    }
}
