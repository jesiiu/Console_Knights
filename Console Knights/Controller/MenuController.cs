using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Knights.Controller
{
    public class MenuController : MainController
    {
        private static HeroController heroController = HeroController.Instance;
        private static FightController fightController = FightController.Instance;
        private static MenuController instance = null;
        private static readonly object padlock = new object();

        public static MenuController Instance
        {
            get
            {
                lock (padlock)
                {

                    if (instance == null)
                        instance = new MenuController();
                    return instance;
                }
            }
        }
        public void InitializeApplication()
        {
            Console.WriteLine("Welcome in Console Knights");
            heroController.CreateKnight();
            MainMenu();
        }
        private void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Select your next move: ");
                Console.WriteLine("Fight: 1");
                Console.WriteLine("Your hero informations: 2");
                Console.WriteLine("Shop: 3");
                Console.WriteLine("Save game: 4");
                Console.WriteLine("Exit game: 5");
                var choose = Console.ReadLine();

                switch (choose)
                {
                    case "1":
                        fightController.Fight();
                        break;
                    case "2":
                        heroController.HeroInformations();
                        break;
                    case "3":
                        break;
                    case "4":
                        //SaveGame();
                        throw new NotImplementedException();
                        break;
                    default:
                        Console.WriteLine("Bye bye :(");
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
