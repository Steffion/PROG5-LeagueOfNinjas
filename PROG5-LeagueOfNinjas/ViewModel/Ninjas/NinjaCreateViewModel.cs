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
    public class NinjaCreateViewModel : ViewModelBase
    {
        private Ninja _ninja;
        private NinjaListViewModel _listViewModel;
        private LeagueOfNinjasDatabaseEntities _database;

        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public NinjaCreateViewModel(NinjaListViewModel listViewModel, LeagueOfNinjasDatabaseEntities database)
        {
            _ninja = new Ninja();
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

        public void Cancel()
        {
            _listViewModel.CloseCreateWindow();
        }

        public void Save()
        {
            _database.Ninjas.Add(_ninja);
            _database.SaveChanges();
            _listViewModel.CloseCreateWindow();
        }
    }
}
