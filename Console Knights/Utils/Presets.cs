using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Knights.Assets;
using Console_Knights.Models;

namespace Console_Knights.Utils
{
    public abstract class Presets
    {
        private static List<string> oponentsNames = new List<string>() { "Michel", "Papric", "Lujka", "Kapcer", "Mamtyna", "Nyna"};
        private static List<WeaponModel> weapons = new List<WeaponModel>() { new Sword("Small", 1,2), new Sword("Big", 2,4), new Sword("Mid", 2,3) };
        private static Random rand = new Random();

        public static Hero CreateOponent() => 
            new Hero(heroName: oponentsNames[rand.Next(0, oponentsNames.Count - 1)], weaponModel: weapons[rand.Next(0, weapons.Count - 1)]);
    }
}
