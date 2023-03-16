using Console_Knights.Assets;
using Console_Knights.Memory;
using Console_Knights.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Knights.Controller
{
    public sealed class FightController : MainController
    {
        private static FightController instance = null;
        private static readonly object padlock = new object();

        public static FightController Instance
        {
            get
            {
                lock (padlock)
                {

                    if (instance == null)
                        instance = new FightController();
                    return instance;
                }
            }
        }
        public FightController() { }

        public void Fight()
        {
            Console.Clear();
            var nextRound = true;
            var oponent = Presets.CreateOponent();
            var fighters = new List<Hero>() { appMemory.mainHero, oponent };
            while (nextRound)
            {
                foreach (var fighter in fighters)
                {
                    var fighterFirst = fighter;
                    var fighterSecond = fighters.Where(x => x != fighter).FirstOrDefault();
                    if (fighterFirst.currentHealth <= 0 || fighterSecond.currentHealth <= 0)
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
            var winner = fighters.Where(x => x.currentHealth > 0).FirstOrDefault();
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
    }
}
