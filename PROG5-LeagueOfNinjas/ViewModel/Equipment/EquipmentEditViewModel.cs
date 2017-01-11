using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PROG5_LeagueOfNinjas.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using PROG5_LeagueOfNinjas.Model;

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
        private int _equipmentStr;
        private int _equipmentInt;
        private int _equipmentAgl;
        private byte[] _equipmentImage;

        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand openFileCommand { get; set; }

        public EquipmentEditViewModel(EquipmentListViewModel equipmentListViewModel, Entities database)
        {
            _listViewModel = equipmentListViewModel;
            _equipmentItem = _listViewModel.SelectedEquipment;
            _database = database;
            _equipmentName = _equipmentItem.Name;
            _equipmentCost = _equipmentItem.Value;
            _equipmentImage = _equipmentItem.Image;
            if (_equipmentItem.Strength != null)
            {
                _equipmentStr = (int)_equipmentItem.Strength;
            }
            if (_equipmentItem.Intelligence != null)
            {
                _equipmentInt = (int)_equipmentItem.Intelligence;
            }
            if (_equipmentItem.Agility != null)
            {
                _equipmentAgl = (int)_equipmentItem.Agility;
            }
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
            openFileCommand = new RelayCommand(openFile);
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

        public void Cancel()
        {
            _listViewModel.closeEditEquipment();
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

        public void Save()
        {
            _equipmentItem.Name = EquipmentName;
            _equipmentItem.Value = EquipmentValue;
            _equipmentItem.Image = _equipmentImage;
            _equipmentItem.Strength = EquipmentStr;
            _equipmentItem.Intelligence = EquipmentInt;
            _equipmentItem.Agility = EquipmentAgl;
            _database.SaveChanges();
            _listViewModel.closeEditEquipment();
        }
    }
}
