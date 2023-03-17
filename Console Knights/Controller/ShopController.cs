using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Console_Knights.Assets;
using Console_Knights.Utils.Presets;
using Newtonsoft.Json.Bson;

namespace Console_Knights.Controller
{
    public class ShopController : MainController
    {
        private static Tavern Tavern = Tavern.Instance;

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
        public void OpenShop()
        {
            GetShopItems();
            ShopMenu();
        }
        private void GetShopItems()
        {
            Console.Clear();
            var items = Presets.CreateTavernItems<HealthPotion>();
            Console.WriteLine("Tavern: ");
            foreach (var item in items)
            {
                item.ItemDescriptionShort();
                /*                if (typeof(T) == typeof(HealthPotion))
                                {
                                    var type = item as HealthPotion;
                                    type.ItemDescriptionShort();
                                }*/
                //TODO - Sword item generate to tavern
                //Tavern capacity 4-6 
                Tavern.Items.Add(item);
            }
        }
        private void ShopMenu()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Choose item to buy: ");
                Console.WriteLine("Press any button to leave Tavern... ");
                var choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        BuyItem(1);
                        break;
                    case "2":
                        BuyItem(2);
                        break;
                    case "3":
                        BuyItem(3);
                        break;
                    case "4":
                        BuyItem(4);
                        break;
                    default:
                        LeaveTavern();
                        break;
                }
            }
        }
        private void BuyItem(int itemChoosen)
        {
            var item = Tavern.Items.ElementAt(itemChoosen - 1);
            if (appMemory.mainHero.Money >= item.Cost)
            {
                appMemory.mainHero.Money -= item.Cost;
                appMemory.mainHero.Equipment.Add(item);
                ShopMenu();
            }
            else
            {
                Console.WriteLine("You can't buy this item, not enought money ! .");
                ShopMenu();
            }
        }
        private void LeaveTavern()
        {
            var mainmenu = MenuController.Instance;
            mainmenu.MainMenu();
        }
    }
}
