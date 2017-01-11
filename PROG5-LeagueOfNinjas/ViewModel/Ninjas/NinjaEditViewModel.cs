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

namespace PROG5_LeagueOfNinjas.ViewModel.Ninjas
{
    public class NinjaEditViewModel : ViewModelBase
    {
        private Ninja _loadout;
        private string _loadoutName;
        private int _loadoutGold;
        private NinjaListViewModel _listViewModel;
        private Entities _database;

        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public NinjaEditViewModel(NinjaListViewModel listViewModel, Entities database)
        {
            _loadout = listViewModel.SelectedNinja;
            _loadoutName = _loadout.Name;
            _loadoutGold = _loadout.Gold;
            _listViewModel = listViewModel;
            _database = database;

            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
        }

        public Ninja Ninja
        {
            get
            {
                return _loadout;
            }

            set
            {
                _loadout = value;
                RaisePropertyChanged("Ninja");
            }
        }

        public string NinjaName
        {
            get
            {
                return _loadoutName;
            }

            set
            {
                _loadoutName = value;
                RaisePropertyChanged("NinjaName");
            }
        }

        public int NinjaGold
        {
            get
            {
                return _loadoutGold;
            }

            set
            {
                _loadoutGold = value;
                RaisePropertyChanged("NinjaGold");
            }
        }

        public void Cancel()
        {
            _listViewModel.CloseEditWindow();
        }

        public void Save()
        {
            _loadout.Name = NinjaName;
            _loadout.Gold = NinjaGold;
            _database.SaveChanges();
            _listViewModel.CloseEditWindow();
        }
    }
}
