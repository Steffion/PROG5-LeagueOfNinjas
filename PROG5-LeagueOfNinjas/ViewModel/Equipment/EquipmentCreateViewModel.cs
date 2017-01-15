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
        private Entities _database;
        private EquipmentListViewModel _viewModel;

        public Data.Equipment Equipment { get; set; }
        public List<Category> EquipmentTypes { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand SelectImageCommand { get; set; }
        public byte[] EquipmentImage { get; set; }

        public EquipmentCreateViewModel(EquipmentListViewModel viewModel, Entities database)
        {
            _database = database;
            _viewModel = viewModel;

            Equipment = new Data.Equipment();
            EquipmentTypes = database.Categories.ToList();

            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
            SelectImageCommand = new RelayCommand(SelectImage);

            Equipment.Name = "New Item";
            Equipment.Category = EquipmentTypes.First();
            Equipment.Value = 1;
        }

        public void Save()
        {
            Equipment.Image = EquipmentImage;

            _database.Equipments.Add(Equipment);
            _database.SaveChanges();
            _viewModel.CloseCreateEquipment();
        }

        public void Cancel()
        {
            _viewModel.CloseCreateEquipment();
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
