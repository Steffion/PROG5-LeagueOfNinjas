using PROG5_LeagueOfNinjas.View;
using PROG5_LeagueOfNinjas.View.Equipment;
using PROG5_LeagueOfNinjas.View.Ninjas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PROG5_LeagueOfNinjas.Model
{
    public class ViewFactory
    {
        private IDictionary<string, UserControl> _views;

        public ViewFactory()
        {
            _views = new Dictionary<string, UserControl>();

            _views["ninja"] = new NinjaListView();
            _views["shop"] = new ShopView();
            _views["equipment"] = new EquipmentListView();
        }

        public UserControl GetView(string name)
        {
            return _views[name];
        }
    }
}
