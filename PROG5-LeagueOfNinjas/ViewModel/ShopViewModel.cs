using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PROG5_LeagueOfNinjas.Data;
using PROG5_LeagueOfNinjas.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PROG5_LeagueOfNinjas.ViewModel
{
    public class ShopViewModel : ViewModelBase
    {
        private Entities _database;
        private Ninja _currentNinja;
        private Category _selectedCategory;
        private Data.Equipment _selectedEquipment;

        public ShopViewModel(Entities database)
        {
            _database = database;
            _currentNinja = MainViewModel.CurrentNinja;

            Categories = new ObservableCollection<Category>(_database.Categories);

            BuyCommand = new RelayCommand(Buy);
        }

        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Data.Equipment> Equipment { get; set; }
        public ICommand BuyCommand { get; set; }
        public ICommand RefreshCommand { get; set; }

        public Category SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }

            set
            {
                _selectedCategory = value;
                UpdateEquipment();
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
                RaisePropertyChanged("SelectedEquipment");

                if (_selectedEquipment != null && _selectedEquipment.Image != null)
                {
                    SelectedEquipmentImage = _selectedEquipment.Image;
                }
                else
                {
                    SelectedEquipmentImage = null;
                }

                RaisePropertyChanged("SelectedEquipmentImage");
                RaisePropertyChanged("IsEquipmentSelected");
            }
        }

        public byte[] SelectedEquipmentImage { get; set; }

        public bool IsEquipmentSelected
        {
            get
            {
                return _selectedEquipment != null;
            }
        }

        public void UpdateEquipment()
        {
            if (_currentNinja == null)
            {
                Equipment = new ObservableCollection<Data.Equipment>();
                RaisePropertyChanged("Equipment");
                return;
            }

            Equipment = new ObservableCollection<Data.Equipment>();

            foreach (var equipment in _database.Equipments)
            {
                if (!equipment.Type.Equals(SelectedCategory.Type)) continue;

                bool bought = false;

                foreach (var purchasedItem in _currentNinja.PurchasedItems)
                {
                    if (equipment.Id == purchasedItem.Equipment)
                    {
                        bought = true;
                        break;
                    }
                }

                if (bought) continue;

                Equipment.Add(equipment);
            }

            RaisePropertyChanged("Equipment");
        }

        public void Buy()
        {
            if (_currentNinja.Gold < SelectedEquipment.Value)
            {
                MessageBox.Show("You don't have that much money!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            PurchasedItem item = new PurchasedItem();
            item.Ninja = _currentNinja.Id;
            item.Equipment = SelectedEquipment.Id;
            _database.PurchasedItems.Add(item);

            _currentNinja.Gold -= SelectedEquipment.Value;

            _database.SaveChanges();

            UpdateEquipment();
        }
    }
}