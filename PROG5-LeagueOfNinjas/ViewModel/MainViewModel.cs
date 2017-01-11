using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PROG5_LeagueOfNinjas.Data;
using PROG5_LeagueOfNinjas.Model;
using PROG5_LeagueOfNinjas.View.Equipment;
using PROG5_LeagueOfNinjas.View.Ninjas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Input;

namespace PROG5_LeagueOfNinjas.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private Entities _database;
        private Ninja _selectedNinja;
        private UserControl _currentView;
        private ViewFactory _viewFactory;

        public static Ninja CurrentNinja { get; set; }

        public MainViewModel(Entities database)
        {
            _database = database;
            _viewFactory = new ViewFactory();
            OpenNinjas();

            Ninjas = new ObservableCollection<Ninja>(_database.Ninjas);

            OpenNinjasCommand = new RelayCommand(OpenNinjas);
            OpenShopCommand = new RelayCommand(OpenShop);
            OpenLoadoutCommand = new RelayCommand(OpenLoadout);
            OpenEquipmentCommand = new RelayCommand(OpenEquipment);
            RefreshCommand = new RelayCommand(Refresh);
        }

        public ObservableCollection<Ninja> Ninjas { get; set; }
        
        public ICommand OpenNinjasCommand { get; set; }
        public ICommand OpenShopCommand { get; set; }
        public ICommand OpenLoadoutCommand { get; set; }
        public ICommand OpenEquipmentCommand { get; set; }
        public ICommand RefreshCommand { get; set; }

        public Ninja SelectedNinja
        {
            get
            {
                return _selectedNinja;
            }

            set
            {
                _selectedNinja = value;
                CurrentNinja = value;
                RaisePropertyChanged("SelectedNinja");
            }
        }

        public UserControl CurrentView
        {
            get
            {
                return _currentView;
            }

            set
            {
                _currentView = value;
                RaisePropertyChanged("CurrentView");
            }
        }

        public void OpenNinjas()
        {
            CurrentView = _viewFactory.GetView("ninja");
        }

        public void OpenShop()
        {
            CurrentView = _viewFactory.GetView("shop");
        }

        public void OpenLoadout()
        {
            CurrentView = _viewFactory.GetView("loadout");
        }

        public void OpenEquipment()
        {
            CurrentView = _viewFactory.GetView("equipment");
        }

        public void Refresh()
        {
            Ninjas = new ObservableCollection<Ninja>(_database.Ninjas);
            RaisePropertyChanged("Ninjas");
        }
    }
}
