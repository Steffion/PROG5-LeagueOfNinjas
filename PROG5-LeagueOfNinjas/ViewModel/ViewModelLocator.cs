/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:PROG5_LeagueOfNinjas"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PROG5_LeagueOfNinjas.Data;
using PROG5_LeagueOfNinjas.ViewModel.Ninjas;
using PROG5_LeagueOfNinjas.ViewModel.Equipment;
using PROG5_LeagueOfNinjas.ViewModel.Loadout;

namespace PROG5_LeagueOfNinjas.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ShopViewModel>();
            SimpleIoc.Default.Register<Entities>();
            SimpleIoc.Default.Register<NinjaListViewModel>();
            SimpleIoc.Default.Register<EquipmentListViewModel>();
            SimpleIoc.Default.Register<LoadoutListViewModel>();
        }

        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public ShopViewModel ShopViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ShopViewModel>();
            }
        }

        public Entities Database
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Entities>();
            }
        }

        public NinjaVisualViewModel NinjaVisualViewModel
        {
            get
            {
                return new NinjaVisualViewModel(Database);
            }
        }

        #region Equipment CRUD
        public EquipmentListViewModel EquipmentListViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EquipmentListViewModel>();
            }
        }

        public EquipmentEditViewModel EquipmentEditViewModel
        {
            get
            {
                return new EquipmentEditViewModel(EquipmentListViewModel, Database);
            }
        }

        public EquipmentCreateViewModel EquipmentCreateViewModel
        {
            get
            {
                return new EquipmentCreateViewModel(EquipmentListViewModel, Database);
            }
        }
        #endregion

        #region Ninja CRUD
        public NinjaListViewModel NinjaListViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NinjaListViewModel>();
            }
        }

        public NinjaCreateViewModel NinjaCreateViewModel
        {
            get
            {
                return new NinjaCreateViewModel(NinjaListViewModel, Database);
            }
        }

        public NinjaEditViewModel NinjaEditViewModel
        {
            get
            {
                return new NinjaEditViewModel(NinjaListViewModel, Database);
            }
        }
        #endregion

        #region Loadout CRUD
        public LoadoutListViewModel LoadoutListViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoadoutListViewModel>();
            }
        }

        public LoadoutCreateViewModel LoadoutCreateViewModel
        {
            get
            {
                return new LoadoutCreateViewModel(LoadoutListViewModel, Database);
            }
        }

        public LoadoutEditViewModel LoadoutEditViewModel
        {
            get
            {
                return new LoadoutEditViewModel(LoadoutListViewModel, Database);
            }
        }
        #endregion

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}