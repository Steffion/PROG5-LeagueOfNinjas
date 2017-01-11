﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PROG5_LeagueOfNinjas.Data;
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
        private LeagueOfNinjasDatabaseEntities _database;
        private Ninja _selectedNinja;
        private UserControl _currentView;

        public MainViewModel(LeagueOfNinjasDatabaseEntities database)
        {
            _database = database;
            CurrentView = new NinjaListView();

            OpenNinjasCommand = new RelayCommand(OpenNinjas);
            OpenShopCommand = new RelayCommand(OpenShop);
            OpenLoadoutCommand = new RelayCommand(OpenLoadout);
            OpenEquipmentCommand = new RelayCommand(OpenEquipment);
        }

        public ObservableCollection<Ninja> Ninjas
        {
            get
            {
                return new ObservableCollection<Ninja>(_database.Ninjas);
            }
        }
        public ICommand OpenNinjasCommand { get; set; }
        public ICommand OpenShopCommand { get; set; }
        public ICommand OpenLoadoutCommand { get; set; }
        public ICommand OpenEquipmentCommand { get; set; }

        public Ninja SelectedNinja
        {
            get
            {
                return _selectedNinja;
            }

            set
            {
                _selectedNinja = value;
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
            CurrentView = new NinjaListView();
        }

        public void OpenShop()
        {
            CurrentView = new ShopView();
        }

        public void OpenLoadout()
        {
            CurrentView = new NinjaListView();
        }

        public void OpenEquipment()
        {
            CurrentView = new NinjaListView();
        }
    }
}
