using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Command;
using PROG5_LeagueOfNinjas.Data;
using PROG5_LeagueOfNinjas.ViewModel.Ninjas;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using Microsoft.Win32;
using PROG5_LeagueOfNinjas.Model;

namespace PROG5_LeagueOfNinjas.ViewModel.Equipment
{
    public class EquipmentCreateViewModel : ViewModelBase
    {
        private Data.Equipment _equipment;
        private string _equipmentName;
        private int _equipmentValue;
        private int _equipmentStr;
        private int _equipmentInt;
        private int _equipmentAgl;
        private byte[] _equipmentImage;
        private EquipmentListViewModel _listViewModel;
        private Entities _database;

        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand openFileCommand { get; set; }

        public EquipmentCreateViewModel(EquipmentListViewModel listViewModel, Entities database)
        {
            _equipment = new Data.Equipment();
            _equipmentName = "New Item";
            _equipmentValue = 500;
            _equipmentStr = 10;
            _equipmentInt = 10;
            _equipmentAgl = 10;
            _listViewModel = listViewModel;
            _database = database;

            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
            openFileCommand = new RelayCommand(openFile);
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

        public int EquipmentStr
        {
            get
            {
                return _equipmentStr;
            }

            set
            {
                _equipmentStr = value;
                RaisePropertyChanged("EquipmentStr");
            }
        }

        public int EquipmentInt
        {
            get
            {
                return _equipmentInt;
            }

            set
            {
                _equipmentInt = value;
                RaisePropertyChanged("EquipmentInt");
            }
        }

        public int EquipmentAgl
        {
            get
            {
                return _equipmentAgl;
            }

            set
            {
                _equipmentAgl = value;
                RaisePropertyChanged("EquipmentAgl");
            }
        }

        public bool isImageEmpty
        {
            get
            {
                if (_equipmentImage != null)
                {
                    return false;
                }
                return true;
            }
        }

        public void openFile()
        {
            System.Windows.Forms.OpenFileDialog fileDialog = new System.Windows.Forms.OpenFileDialog();
            fileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _equipmentImage = ImageHandler.ConvertToByteArray(fileDialog.OpenFile());
                RaisePropertyChanged("isImageEmpty");
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
            _equipment.Strength = EquipmentStr;
            _equipment.Intelligence = EquipmentInt;
            _equipment.Agility = EquipmentAgl;
            _equipment.Image = _equipmentImage;
            _database.Equipments.Add(_equipment);
            _database.SaveChanges();
            _listViewModel.CloseCreateEquipment();
        }
    }
}
