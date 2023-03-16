using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Knights.Models;

namespace Console_Knights.Assets
{
    public class Sword : WeaponModel
    {
        public Sword(string weaponName, int weaponMinDamage, int weaponMaxDamage)
        {
            Name = weaponName;
            minDamage = weaponMinDamage;
            maxDamage = weaponMaxDamage;
        }

        public override void Attack()
        {
            var attack = base.DamageDealt();
            Console.WriteLine($"Attack for {attack} with {Name}");
        }
        public override void GetWeaponInfo()
        {
            base.GetWeaponInfo();
        }
    }
}
