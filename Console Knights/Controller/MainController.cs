using Console_Knights.Memory;
using Console_Knights.Utils;
using Console_Knights.Assets;
using Console_Knights.Save;

namespace Console_Knights.Controller
{
    public abstract class MainController
    {
        private AppMemory appMemory = AppMemory.Instance;

        public void InitializeApplication()
        {
            Console.WriteLine("Welcome in Console Knights");
            CreateKnight();
            MainMenu();
        }
        private void CreateKnight()
        {
            string name = null;
            Console.WriteLine("Create your Knight");
            while (string.IsNullOrEmpty(name) || name.Length < 4)
            {
                Console.WriteLine("Insert your Knight name (more than 4 lenght): ");
                name = Console.ReadLine();
                if(string.IsNullOrEmpty(name) || name == "" || name.Length < 4)
                    Console.WriteLine("Please insert valid name for you Knight !");
            }
            var mainHero = new Hero(name);
            appMemory.mainHero = mainHero;
            Console.WriteLine($"Welcome to the Console Knight's World {name} !");
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
                        Fight();
                        break;
                    case "2":
                        HeroInformations();
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
        private void Fight()
        {
            Console.Clear();
            var nextRound = true;
            var oponent = Presets.CreateOponent();
            var fighters = new List<Hero>() { appMemory.mainHero, oponent };
            while (nextRound)
            {
                foreach(var fighter in fighters)
                {
                    var fighterFirst = fighter;
                    var fighterSecond = fighters.Where(x => x != fighter).FirstOrDefault();
                    if (fighterFirst.Health <= 0 || fighterSecond.Health <= 0)
                    {
                        CheckWinner(fighters);
                        nextRound = false;
                        break;
                    }
                    HeroAttack(fighterFirst, fighterSecond);
                }
            }
        }
        private void HeroAttack(Hero fistHero, Hero secondHero)
        {
            Console.WriteLine($"Attack: {fistHero.Name}");
            var damage = fistHero.Weapon.DamageDealt();
            secondHero.currentHealth -= damage;
            Console.WriteLine($"{fistHero.Name} dealt {damage} to {secondHero.Name} | {secondHero.Name} health {secondHero.currentHealth} left");
        }
        private void CheckWinner(List<Hero> fighters)
        {
            var winner = fighters.Where(x => x.Health > 0).FirstOrDefault();
            Console.WriteLine($"{winner.Name} won");
            if (winner != appMemory.mainHero)
            {
                Console.WriteLine("You died !");
                Console.WriteLine("Game end");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine($"You win figth !");
                Console.WriteLine("Press any key to continue game...");
                Console.ReadLine();
            }
        }
        private void HeroInformations()
        {
            Console.Clear();
            appMemory.mainHero.GetPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Press any key for back to main menu...");
            Console.ReadLine();
        }
        private void SaveGame()
        {
            saveController.CreateSave(appMemory);
        }
        private void Shop()
        {
            Console.Clear();
            Console.WriteLine("Shop");
            Console.WriteLine($"Your money: ");
        }
    }
}