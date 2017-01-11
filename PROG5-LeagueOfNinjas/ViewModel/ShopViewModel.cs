using GalaSoft.MvvmLight;
using PROG5_LeagueOfNinjas.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PROG5_LeagueOfNinjas.ViewModel
{
    public class ShopViewModel : ViewModelBase
    {
        private LeagueOfNinjasDatabaseEntities _database;
        private Category _selectedCategory;
        private Data.Equipment _selectedEquipment;

        public ShopViewModel(LeagueOfNinjasDatabaseEntities database)
        {
            _database = database;

            Categories = new List<Category>(_database.Categories);
        }

        public List<Category> Categories { get; set; }

        public ObservableCollection<Data.Equipment> Equipment { get; set; }

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
            }
        }

        public void UpdateEquipment()
        {
            Equipment = new ObservableCollection<Data.Equipment>(SelectedCategory.Equipments);
            RaisePropertyChanged("Equipment");
        }
    }
}