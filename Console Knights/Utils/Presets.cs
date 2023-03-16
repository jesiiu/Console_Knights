using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Console_Knights.Assets;
using Console_Knights.Models;

namespace Console_Knights.Utils.Presets
{
    public abstract class Presets
    {
        private static List<string> oponentsNames = new List<string>() { "Michel", "Papric", "Lujka", "Kapcer", "Mamtyna", "Nyna" };
        private static List<WeaponModel> weapons = new List<WeaponModel>() { new Sword("Small", 1, 2), new Sword("Big", 2, 4), new Sword("Mid", 2, 3) };
        private static List<string> weaponNames = new List<string>() { "A", "B", "C", "D" };
        private static Dictionary<int, int> weaponDamages = new Dictionary<int, int>() { { 1, 2 }, { 1, 3 }, { 3, 4 }, { 2, 5 } };
        private static Random rand = new Random();

        public static Hero CreateOponent() => 
            new Hero(heroName: oponentsNames[rand.Next(0, oponentsNames.Count - 1)], weaponModel: weapons[rand.Next(0, weapons.Count - 1)]);
        public static List<T> CreateTavernItems<T>() where T : new()
        {
            var items = new List<T>();
            for (int i = 2; i > 0; i--)
            {
                items.Add(new T());
            }
            return items;
        }
        public static List<Sword> CreateTavernSwords()
        {
            var swords = new List<Sword>();
            for (int i = 2; i > 0; i--)
            {
                var damage = weaponDamages.Select(x => x).ElementAt(rand.Next(0, weaponDamages.Count - 1));
                swords.Add(new Sword(weaponNames[rand.Next(0, weaponNames.Count - 1)], damage.Key, damage.Value));
            }
            return swords;
        }
    }
}
