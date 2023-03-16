using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Knights.Models
{
    public abstract class WeaponModel
    {
        protected string Name { get; set; }
        protected int minDamage { get; set; }  
        protected int maxDamage { get; set; }

        public virtual void Attack()
        {
            return;
        }
        public virtual int DamageDealt()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            var attack = random.Next(minDamage, maxDamage);
            return attack;
        }
        public virtual void GetWeaponInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Min Damage: {minDamage}");
            Console.WriteLine($"Max Damage: {maxDamage}");
        }
        public virtual void GetWeaponInfoShort()
        {
            Console.WriteLine($@"Name: {Name} | Min Damage: {minDamage} | Max Damage: {maxDamage}");
        }
    }
}
