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

namespace PROG5_LeagueOfNinjas.ViewModel.Loadout
{
    public class LoadoutEditViewModel : ViewModelBase
    {
        private Data.Loadout _loadout;
        private string _loadoutName;
        private LoadoutListViewModel _listViewModel;
        private Entities _database;

        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public LoadoutEditViewModel(LoadoutListViewModel listViewModel, Entities database)
        {
            _loadout = listViewModel.SelectedLoadout;
            _loadoutName = _loadout.Name;
            _listViewModel = listViewModel;
            _database = database;

            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
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
            _listViewModel.CloseEditWindow();
        }

        public void Save()
        {
            _loadout.Name = LoadoutName;
            _database.SaveChanges();
            _listViewModel.CloseEditWindow();
        }
    }
}
