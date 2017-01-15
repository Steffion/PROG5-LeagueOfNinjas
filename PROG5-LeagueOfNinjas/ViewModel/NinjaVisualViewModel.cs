using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using PROG5_LeagueOfNinjas.Data;
using System.Collections.ObjectModel;

namespace PROG5_LeagueOfNinjas.ViewModel
{
    public class NinjaVisualViewModel : ViewModelBase
    {
        private Entities _database;
        private Ninja _ninja;
        private Data.Equipment _noItem;
        private Data.Loadout _selectedLoadout;

        public NinjaVisualViewModel(Entities database)
        {
            _database = database;
            _ninja = MainViewModel.CurrentNinja;

            Loadouts = _database.Loadouts.Where(e => e.Ninja == _ninja.Id).ToList();
            SelectedLoadout = Loadouts.First();

            _noItem = new Data.Equipment();
            _noItem.Name = "No Item Found";
        }

        public List<Data.Loadout> Loadouts { get; set; }
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
                RaisePropertyChanged("Head");
                RaisePropertyChanged("Shoulders");
                RaisePropertyChanged("Chest");
                RaisePropertyChanged("Belt");
                RaisePropertyChanged("Legs");
                RaisePropertyChanged("Boots");

                RaisePropertyChanged("TotalStrength");
                RaisePropertyChanged("TotalIntelligence");
                RaisePropertyChanged("TotalAgility");
                RaisePropertyChanged("TotalCost");
            }
        }

        public string TotalStrength
        {
            get
            {
                int? value = 0;

                foreach (Data.LoadoutItem item in SelectedLoadout.LoadoutItems)
                {
                    if (item.Equipment1.Strength == null) continue;

                    value += item.Equipment1.Strength;
                }

                return value + "";
            }
        }

        public string TotalIntelligence
        {
            get
            {
                int? value = 0;

                foreach (Data.LoadoutItem item in SelectedLoadout.LoadoutItems)
                {
                    if (item.Equipment1.Intelligence == null) continue;

                    value += item.Equipment1.Intelligence;
                }

                return value + "";
            }
        }

        public string TotalAgility
        {
            get
            {
                int? value = 0;

                foreach (Data.LoadoutItem item in SelectedLoadout.LoadoutItems)
                {
                    if (item.Equipment1.Agility == null) continue;
                    
                    value += item.Equipment1.Agility;
                }

                return value + "";
            }
        }

        public string TotalValue
        {
            get
            {
                int? value = 0;
                SelectedLoadout.LoadoutItems.ToList().ForEach(e => value += e.Equipment1.Value);
                return value + "";
            }
        }

        public Data.Equipment Head
        {
            get
            {
                try
                {
                    return SelectedLoadout.LoadoutItems.Where(e => e.Equipment1.Type == "Head").ToList().First().Equipment1;
                }
                catch (Exception)
                {
                    return _noItem;
                }
            }
        }

        public Data.Equipment Shoulders
        {
            get
            {
                try
                {
                    return SelectedLoadout.LoadoutItems.Where(e => e.Equipment1.Type == "Shoulders").ToList().First().Equipment1;
                }
                catch (Exception)
                {
                    return _noItem;
                }
            }
        }

        public Data.Equipment Chest
        {
            get
            {
                try
                {
                    return SelectedLoadout.LoadoutItems.Where(e => e.Equipment1.Type == "Chest").ToList().First().Equipment1;
                }
                catch (Exception)
                {
                    return _noItem;
                }
            }
        }

        public Data.Equipment Belt
        {
            get
            {
                try
                {
                    return SelectedLoadout.LoadoutItems.Where(e => e.Equipment1.Type == "Belt").ToList().First().Equipment1;
                }
                catch (Exception)
                {
                    return _noItem;
                }
            }
        }

        public Data.Equipment Legs
        {
            get
            {
                try
                {
                    return SelectedLoadout.LoadoutItems.Where(e => e.Equipment1.Type == "Legs").ToList().First().Equipment1;
                }
                catch (Exception)
                {
                    return _noItem;
                }
            }
        }

        public Data.Equipment Boots
        {
            get
            {
                try
                {
                    return SelectedLoadout.LoadoutItems.Where(e => e.Equipment1.Type == "Boots").ToList().First().Equipment1;
                }
                catch (Exception)
                {
                    return _noItem;
                }
            }
        }
    }
}
