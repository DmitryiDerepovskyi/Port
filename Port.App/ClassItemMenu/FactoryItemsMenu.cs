using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Port.App.ClassItemMenu
{
    static class FactoryItemsMenu
    {
        static public ItemMenu CreateItemMenu(int itemMenuId)
        {
            ItemMenu item;
            switch (itemMenuId)
            {
                case (int)EnumItemsMenu.Captain:
                    item = new CaptainItem();
                    break;
                case (int)EnumItemsMenu.Ship:
                    item = new ShipItem();
                    break;
                case (int)EnumItemsMenu.Port:
                    item = new PortItem();
                    break;
                case (int)EnumItemsMenu.City:
                    item = new CityItem();
                    break;
                case (int)EnumItemsMenu.Trip:
                    item = new TripItem();
                    break;
                case (int)EnumItemsMenu.Cargo:
                    item = new CargoItem();
                    break;
                case (int)EnumItemsMenu.CargoType:
                    item = new TypeCargoItem();
                    break;
                default:
                    item = null;
                    break;
            }
            return item;
        }
    }
}
