using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using PROG5_LeagueOfNinjas.Data;
using PROG5_LeagueOfNinjas.View.Loadout;

namespace PROG5_LeagueOfNinjas.ViewModel.Loadout
{
    public class LoadoutListViewModel : ViewModelBase
    {
        private Entities _database;
        private Data.Loadout _selectedLoadout;
        private LoadoutCreateView _createView;
        private LoadoutEditView _editView;

        public ICommand LoadoutAddCommand { get; set; }
        public ICommand LoadoutEditCommand { get; set; }
        public ICommand LoadoutDeleteCommand { get; set; }
        public ICommand LoadoutSelectCommand { get; set; }

        public LoadoutListViewModel(Entities database)
        {
            _database = database;

            LoadoutAddCommand = new RelayCommand(OpenCreateWindow);
            LoadoutEditCommand = new RelayCommand(EditLoadout);
            LoadoutDeleteCommand = new RelayCommand(DeleteLoadout);
        }

        public ObservableCollection<Data.Loadout> Loadouts
        {
            get
            {
                return new ObservableCollection<Data.Loadout>(_database.Loadouts);
            }
        }

        public bool IsNinjaSelected
        {
            get
            {
                return MainViewModel.CurrentNinja != null;
            }
        }

        public bool IsLoadoutSelected
        {
            get {
                return _selectedLoadout != null;
            }
        }

        public Data.Loadout SelectedLoadout
        {
            get
            {
                return _selectedLoadout;
            }

            set
            {
                _selectedLoadout = value;
                RaisePropertyChanged("SelectedLoadout");
                RaisePropertyChanged("IsNinjaSelected");
                RaisePropertyChanged("IsLoadoutSelected");
            }
        }

        public void OpenCreateWindow()
        {
            _createView = new LoadoutCreateView();
            _createView.ShowDialog();
        }

        public void CloseCreateWindow()
        {
            _createView.Close();
            RaisePropertyChanged("Loadouts");
        }

        public void EditLoadout()
        {
            _editView = new LoadoutEditView();
            _editView.ShowDialog();
        }

        public void CloseEditWindow()
        {
            _editView.Close();
            RaisePropertyChanged("Loadouts");
        }

        public void DeleteLoadout()
        {
            _database.Loadouts.Remove(_selectedLoadout);
            _database.SaveChanges();
            RaisePropertyChanged("Loadouts");
        }
    }
}
