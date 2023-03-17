using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Knights.Assets;

namespace Console_Knights.Models
{
    public abstract class PlayerModel
    {
        public string Name {  get; set; }
        public int maxHealth { get; set; } = 10;
        public int currentHealth { get; set; } = 10;
        public int Defence { get; set; } = 0;
        public int Level { get; set; } = 1;
        public int Money { get; set; } = 22;
        public WeaponModel Weapon { get; set; } = new Sword("Long-Sword", 4, 6);
        public List<ItemModel> Equipment = new List<ItemModel>();

        public virtual void GetPlayerInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {currentHealth}/{maxHealth}");
            Console.WriteLine($"Defence: {Defence}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Money: {Money}");
            foreach (var item in Equipment)
            {
                Console.WriteLine($"Item: {item.Name} | {item.Description}");
            }
        }
    }
}
