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
        private Ninja _ninja;
        private string _ninjaName;
        private int _ninjaGold;
        private NinjaListViewModel _listViewModel;
        private LeagueOfNinjasEntities _database;

        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public NinjaEditViewModel(NinjaListViewModel listViewModel, LeagueOfNinjasEntities database)
        {
            _ninja = listViewModel.SelectedNinja;
            _ninjaName = _ninja.Name;
            _ninjaGold = _ninja.Gold;
            _listViewModel = listViewModel;
            _database = database;

            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
        }

        public Ninja Ninja
        {
            get
            {
                return _ninja;
            }

            set
            {
                _ninja = value;
                RaisePropertyChanged("Ninja");
            }
        }

        public string NinjaName
        {
            get
            {
                return _ninjaName;
            }

            set
            {
                _ninjaName = value;
                RaisePropertyChanged("NinjaName");
            }
        }

        public int NinjaGold
        {
            get
            {
                return _ninjaGold;
            }

            set
            {
                _ninjaGold = value;
                RaisePropertyChanged("NinjaGold");
            }
        }

        public void Cancel()
        {
            _listViewModel.CloseEditWindow();
        }

        public void Save()
        {
            _ninja.Name = NinjaName;
            _ninja.Gold = NinjaGold;
            _database.SaveChanges();
            _listViewModel.CloseEditWindow();
        }
    }
}
