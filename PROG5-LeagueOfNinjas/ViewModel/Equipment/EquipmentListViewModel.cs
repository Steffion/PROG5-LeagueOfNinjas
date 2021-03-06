﻿using System;
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
    public class EquipmentListViewModel : ViewModelBase
    {
        private Entities _database;
        private Data.Equipment _selectedEquipment;
        private EquipmentEditView _editView;
        private EquipmentCreateView _createView;

        public ICommand EquipmentEditCommand { get; set; }
        public ICommand EquipmentCreateCommand { get; set; }
        public ICommand EquipmentDeleteCommand { get; set; }

        public EquipmentListViewModel(Entities database)
        {
            _database = database;

            EquipmentEditCommand = new RelayCommand(OpenEditEquipment);
            EquipmentCreateCommand = new RelayCommand(OpenCreateEquipment);
            EquipmentDeleteCommand = new RelayCommand(DeleteEquipment);

        }

        public ObservableCollection<Data.Equipment> Equipment
        {
            get
            {
                return new ObservableCollection<Data.Equipment>(_database.Equipments);
            }
        }

        public bool IsEquipmentSelected
        {
            get
            {
                return _selectedEquipment != null;
            }
        }

        public Data.Equipment SelectedEquipment
        {
            get
            {
                return _selectedEquipment;
            }

            set
            {
                _selectedEquipment = value;
                RaisePropertyChanged("SelectedEquipMent");
                RaisePropertyChanged("IsEquipmentSelected");
            }
        }

        public void OpenEditEquipment()
        {
            _editView = new EquipmentEditView();
            _editView.ShowDialog();
        }

        public void CloseEditEquipment()
        {
            _editView.Close();
            RaisePropertyChanged("Equipment");
        }

        public void OpenCreateEquipment()
        {
            _createView = new EquipmentCreateView();
            _createView.ShowDialog();
        }

        public void CloseCreateEquipment()
        {
            _createView.Close();
            RaisePropertyChanged("Equipment");
        }

        public void DeleteEquipment()
        {
            _database.Equipments.Remove(_selectedEquipment);
            _database.SaveChanges();
            RaisePropertyChanged("Equipment");
        }
    }
}
