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
            SimpleIoc.Default.Register<LeagueOfNinjasDatabaseEntities>();
            SimpleIoc.Default.Register<NinjaListViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public LeagueOfNinjasDatabaseEntities Database
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LeagueOfNinjasDatabaseEntities>();
            }
        }

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
        #endregion

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}