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
using PROG5_LeagueOfNinjas.View.Ninjas;
using PROG5_LeagueOfNinjas.ViewModel.Ninjas;

namespace PROG5_LeagueOfNinjas.ViewModel.Loadout
{
    public class LoadoutListViewModel : ViewModelBase
    {
        private Entities _database;
        private Data.Loadout _selectedLoadout;
        private LoadoutCreateView _createView;
        private LoadoutEditView _editView;
        private NinjaListViewModel _listView;

        public ICommand LoadoutAddCommand { get; set; }
        public ICommand LoadoutEditCommand { get; set; }
        public ICommand LoadoutDeleteCommand { get; set; }
        public ICommand LoadoutSelectCommand { get; set; }
        public ICommand saveCommand { get; set; }
        public ICommand cancelCommand { get; set; }

        public LoadoutListViewModel(Entities database, NinjaListViewModel listview)
        {
            _database = database;

            _listView = listview;

            LoadoutAddCommand = new RelayCommand(OpenCreateWindow);
            LoadoutEditCommand = new RelayCommand(EditLoadout);
            LoadoutDeleteCommand = new RelayCommand(DeleteLoadout);
            saveCommand = new RelayCommand(save);
            cancelCommand = new RelayCommand(cancel);
        }

        public ObservableCollection<Data.Loadout> Loadouts
        {
            get
            {
                ObservableCollection<Data.Loadout> collection = new ObservableCollection<Data.Loadout>(_database.Loadouts);
                    foreach (var loadOut in collection.ToList())
                    {
                        if (loadOut.Ninja != _listView.SelectedNinja.Id)
                        {
                            collection.Remove(loadOut);
                        }
                    }
                return collection;
            }
        }

        public bool IsNinjaSelected
        {
            get
            {
                return _listView.SelectedNinja != null;
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

        public Ninja getSelectedNinja()
        {
            return _listView.SelectedNinja;
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

        public void cancel()
        {
            _listView.CloseLoadOutWindow();
        }

        public void save()
        {
            // save changes to db
            _listView.CloseLoadOutWindow();
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
