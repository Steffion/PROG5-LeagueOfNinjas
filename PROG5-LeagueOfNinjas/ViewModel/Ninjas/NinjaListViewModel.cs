using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using PROG5_LeagueOfNinjas.Data;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using PROG5_LeagueOfNinjas.View.Ninjas;
using System.Windows;

namespace PROG5_LeagueOfNinjas.ViewModel.Ninjas
{
    public class NinjaListViewModel : ViewModelBase
    {
        private LeagueOfNinjasEntities _database;
        private Ninja _selectedNinja;
        private NinjaCreateView _createView;
        private NinjaEditView _editView;

        public ICommand NinjaAddCommand { get; set; }
        public ICommand NinjaEditCommand { get; set; }
        public ICommand NinjaDeleteCommand { get; set; }
        public ICommand NinjaSelectCommand { get; set; }

        public NinjaListViewModel(LeagueOfNinjasEntities database)
        {
            _database = database;

            NinjaAddCommand = new RelayCommand(OpenCreateWindow);
            NinjaEditCommand = new RelayCommand(EditNinja);
            NinjaDeleteCommand = new RelayCommand(DeleteNinja);
        }

        public ObservableCollection<Ninja> Ninjas
        {
            get
            {
                return new ObservableCollection<Ninja>(_database.Ninjas);
            }
        }

        public bool IsNinjaSelected
        {
            get {
                return _selectedNinja != null;
            }
        }

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
                RaisePropertyChanged("IsNinjaSelected");
            }
        }

        public void OpenCreateWindow()
        {
            _createView = new NinjaCreateView();
            _createView.ShowDialog();
        }

        public void CloseCreateWindow()
        {
            _createView.Close();
            RaisePropertyChanged("Ninjas");
        }

        public void EditNinja()
        {
            _editView = new NinjaEditView();
            _editView.ShowDialog();
        }

        public void CloseEditWindow()
        {
            _editView.Close();
            RaisePropertyChanged("Ninjas");
        }

        public void DeleteNinja()
        {
            _database.Ninjas.Remove(_selectedNinja);
            _database.SaveChanges();
            RaisePropertyChanged("Ninjas");
        }
    }
}
