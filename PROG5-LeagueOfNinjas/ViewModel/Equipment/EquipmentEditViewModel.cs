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
    public class EquipmentEditViewModel : ViewModelBase
    {
        private Entities _database;
        private EquipmentListViewModel _viewModel;

        public Data.Equipment Equipment { get; set; }
        public List<Category> EquipmentTypes { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand SelectImageCommand { get; set; }
        public byte[] EquipmentImage { get; set; }

        public EquipmentEditViewModel(EquipmentListViewModel viewModel, Entities database)
        {
            _database = database;
            _viewModel = viewModel;

            Equipment = viewModel.SelectedEquipment;
            EquipmentImage = viewModel.SelectedEquipment.Image;
            EquipmentTypes = database.Categories.ToList();

            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
            SelectImageCommand = new RelayCommand(SelectImage);
        }

        public void Save()
        {
            Equipment.Image = EquipmentImage;

            _database.SaveChanges();
            _viewModel.CloseEditEquipment();
        }

        public void Cancel()
        {
            _viewModel.CloseEditEquipment();
        }

        public void SelectImage()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Image Files|*.jpeg;*.jpg;*.png;*.gif";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                EquipmentImage = ImageHandler.ConvertToByteArray(dlg.OpenFile());
                RaisePropertyChanged("EquipmentImage");
            }
        }
    }
}