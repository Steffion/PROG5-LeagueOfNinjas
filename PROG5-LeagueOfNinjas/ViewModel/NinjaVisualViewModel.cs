using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using PROG5_LeagueOfNinjas.Data;

namespace PROG5_LeagueOfNinjas.ViewModel
{
    public class NinjaVisualViewModel : ViewModelBase
    {
        private Entities _database;
        private Bitmap _headImage;
        private MainViewModel _mainView;
        private Ninja _ninja;

        public NinjaVisualViewModel(Entities database, MainViewModel mainView)
        {
            _database = database;
            _mainView = mainView;

            _ninja = mainView.SelectedNinja;

            
        }

        public Bitmap headImage
        {
            get
            {
                return _headImage;
            }
        }
    }
}
