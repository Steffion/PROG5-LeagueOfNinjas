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
    public class LoadoutEditViewModel : ViewModelBase
    {
        private Data.Loadout _loadout;
        private string _loadoutName;
        private LoadoutListViewModel _listViewModel;
        private Entities _database;
        private LoadoutItem _loadoutItem;
        private LoadoutItem _newItem;
        private PurchasedItem _purchasedItem;
        private ICollection<LoadoutItem> _allLoadoutItems;
        private ICollection<LoadoutItem> _finalLoadOut;
        private List<LoadoutItem> _itemList;
        private List<LoadoutItem> _removedItemList;

        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand addCommand { get; set; }
        public ICommand removeCommand { get; set; }

        public LoadoutEditViewModel(LoadoutListViewModel listViewModel, Entities database)
        {
            _loadout = listViewModel.SelectedLoadout;
            _loadoutName = _loadout.Name;
            _listViewModel = listViewModel;
            _database = database;
            _allLoadoutItems = _loadout.LoadoutItems;
            _removedItemList = new List<LoadoutItem>();

            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
            addCommand = new RelayCommand(addItem);
            removeCommand = new RelayCommand(removeItem);
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

        public ObservableCollection<Data.LoadoutItem> loadOutItems {
            get
            {
                _itemList = new List<LoadoutItem>();
                ObservableCollection<Data.LoadoutItem> collection = new ObservableCollection<Data.LoadoutItem>();
                foreach (var item in _allLoadoutItems)
                {
                    collection.Add(item);
                    _itemList.Add(item);
                }
                return collection;
            }
        }

        public ICollection<Data.PurchasedItem> ownedItems {
            get {
                return _listViewModel.getSelectedNinja().PurchasedItems;
            }
        }

        public Data.PurchasedItem OwnedEquipment
        {
            get
            {
                return _purchasedItem;
            }
            set
            {
                _purchasedItem = value;
                _loadoutItem = null;
                RaisePropertyChanged("isOwnedSelected");
                RaisePropertyChanged("isDifferentCategory");
            }
        }

        public Data.LoadoutItem currentItemSelected
        {
            get
            {
                return _loadoutItem;
            }
            set
            {
                _loadoutItem = value;
                _purchasedItem = null;
                RaisePropertyChanged("isCurrentSelected");
                RaisePropertyChanged("isDifferentCategory");
            }
        }

        private void removeItem()
        {
            foreach (var item in _allLoadoutItems)
            {
                if (_loadoutItem.Id == item.Id)
                {
                    _allLoadoutItems.Remove(item);
                    _itemList.Remove(item);
                    _removedItemList.Add(item);
                    break;
                }
            }
            RaisePropertyChanged("loadOutItems");
        }

        private void addItem()
        {
            _newItem = new LoadoutItem();
            _newItem.Equipment = _purchasedItem.Equipment;
            _newItem.Equipment1 = _purchasedItem.Equipment1;
            _newItem.Loadout = _loadout.Id;
            _newItem.Loadout1 = _loadout;

            _allLoadoutItems.Add(_newItem);
            _itemList.Add(_newItem);
            RaisePropertyChanged("loadOutItems");
        }

        public bool isDifferentCategory
        {
            get
            {
                bool diffCategory = true;
                foreach (var item in _itemList)
                {
                    if (item.Equipment1.Category == _purchasedItem.Equipment1.Category)
                    {
                        diffCategory = false;
                    }
                }
                return diffCategory;
            }
        }

        public bool isOwnedSelected
        {
            get
            {
                return _purchasedItem != null;
            }
        }

        public bool isCurrentSelected
        {
            get
            {
                return _loadoutItem != null;
            }
        }

        public void Cancel()
        {
            _listViewModel.CloseEditWindow();
        }

        public void Save()
        {
            foreach (var removedItem in _removedItemList)
            {
                _database.LoadoutItems.Remove(removedItem);
            }
            _database.Loadouts.Remove(_loadout);
            _database.SaveChanges();
            _loadout.Name = LoadoutName;
            _loadout.LoadoutItems = _itemList;
            _database.Loadouts.Add(_loadout);
            _database.SaveChanges();
            _listViewModel.CloseEditWindow();
        }
    }
}
