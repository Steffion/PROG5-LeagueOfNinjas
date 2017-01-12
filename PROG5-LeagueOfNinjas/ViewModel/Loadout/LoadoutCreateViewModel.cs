using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PROG5_LeagueOfNinjas.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PROG5_LeagueOfNinjas.ViewModel.Loadout
{
    public class LoadoutCreateViewModel : ViewModelBase
    {
        private Data.Loadout _loadout;
        private string _loadoutName;
        private LoadoutListViewModel _listViewModel;
        private Entities _database;
        private Ninja _ninja;
        private Data.Equipment _selectedItem;
        private ICollection<Data.Equipment> _loCollection;
        private string itemName;
        private List<LoadoutItem> _loadOutList;
        private ICollection<LoadoutItem> _loadOutItems;
        private LoadoutItem _newItem;

        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand addItemCommand { get; set; }

        public LoadoutCreateViewModel(LoadoutListViewModel listViewModel, Entities database)
        {
            _loadout = new Data.Loadout();
            _loadoutName = "New Loadout";
            _listViewModel = listViewModel;
            _database = database;
            _ninja = _listViewModel.getSelectedNinja();
            _loadOutList = new List<LoadoutItem>();
            
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
            addItemCommand = new RelayCommand(addItem);
        }

        public void addItem()
        {
            _newItem = new LoadoutItem();
            _newItem.Equipment = selectedItem.Id;
            _loadOutList.Add(_newItem);

            RaisePropertyChanged("addItem");
            RaisePropertyChanged("isLoadOutNull");
        }

        public bool isItemSeleceted
        {
            get { return _selectedItem != null; }
        }

        public ObservableCollection<Data.Equipment> loCollection
        {
            get
            {
                ObservableCollection<Data.Equipment> purchasedItems =  new ObservableCollection<Data.Equipment>();
                foreach (var item in _ninja.PurchasedItems)
                {
                    purchasedItems.Add(item.Equipment1);
                }
                return purchasedItems;
            }
        }

        public bool isLoadOutNull
        {
            get { return _loadOutList != null; }
        }

        public Data.Equipment selectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged("selectedItem");
                RaisePropertyChanged("isItemSeleceted");
            }
        }

        public Data.Loadout Loadout
        {
            get
            {
                return _loadout;
            }

            set
            {
                _loadout = value;
                RaisePropertyChanged("Loadout");
            }
        }

        public string LoadoutName
        {
            get
            {
                return _loadoutName;
            }

            set
            {
                _loadoutName = value;
                RaisePropertyChanged("LoadoutName");
            }
        }

        public void Cancel()
        {
            _listViewModel.CloseCreateWindow();
        }

        public void Save()
        {
            _loadout.Name = LoadoutName;
            _loadOutItems = _loadOutList;
            _loadout.LoadoutItems = _loadOutItems;
            _loadout.Ninja = _ninja.Id;


            _database.Loadouts.Add(_loadout);
            _database.SaveChanges();
            _listViewModel.CloseCreateWindow();
        }
    }
}
