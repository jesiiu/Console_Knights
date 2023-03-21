using Console_Knights.Assets;
using Console_Knights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Knights.Controller
{
    public class HeroController : MainController
    {
        private static HeroController instance = null;
        private static readonly object padlock = new object();

        public static HeroController Instance
        {
            get
            {
                lock (padlock)
                {

                    if (instance == null)
                        instance = new HeroController();
                    return instance;
                }
            }
        }

        public void CreateKnight()
        {
            string name = null;
            Console.WriteLine("Create your Knight");
            while (string.IsNullOrEmpty(name) || name.Length < 4)
            {
                Console.WriteLine("Insert your Knight name (more than 4 lenght): ");
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name) || name == "" || name.Length < 4)
                    Console.WriteLine("Please insert valid name for you Knight !");
            }
            var mainHero = new Hero(name);
            appMemory.mainHero = mainHero;
            Console.WriteLine($"Welcome to the Console Knight's World {name} !");
        }
        public void HeroInformations()
        {
            Console.Clear();
            appMemory.mainHero.GetPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Press any key for back to main menu...");
            Console.ReadLine();
        }
        public void HeroEquipment()
        {
            var itemToUse = new Dictionary<int, ItemModel>();
            var index = 0;
            foreach(var item in appMemory.mainHero.Equipment)
            {
                Console.WriteLine(item.Description);
                itemToUse.Add(index, item);
                index++;
            }
        }
    }
}
