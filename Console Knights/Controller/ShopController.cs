using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Console_Knights.Assets;
using Console_Knights.Utils.Presets;

namespace Console_Knights.Controller
{
    public class ShopController : MainController
    {
        private static ShopController instance = null;
        private static readonly object padlock = new object();

        public static ShopController Instance
        {
            get
            {
                lock (padlock)
                {

                    if (instance == null)
                        instance = new ShopController();
                    return instance;
                }
            }
        }
        public void OpenShop<T>()
        {
            var items = GetShopItems();
            Console.WriteLine("Tavern: ");
            foreach (var item in items)
            {
                if (typeof(T) == typeof(HealthPotion))
                {
                    var type = item as HealthPotion;
                    type.ItemDescriptionShort();
                }
                if (typeof(T) == typeof(Sword))
                {
                    var type = item as Sword;
                    type.GetWeaponInfoShort();
                }

            }
        }
        private List<HealthPotion> GetShopItems()
        {
            var potions = Presets.CreateShopItems<HealthPotion>();
            var sword = Presets.CreateShopItems<Sword>();
        }
    }
}
