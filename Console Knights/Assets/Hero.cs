using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Knights.Models;

namespace Console_Knights.Assets
{
    public class Hero : PlayerModel
    {
        public Hero(string heroName, WeaponModel weaponModel)
        {
            Name = heroName;
            Weapon = weaponModel;
        }
        public Hero(string heroName)
        {
            Name = heroName;
        }
        public override void GetPlayerInfo()
        {
            base.GetPlayerInfo();
            Weapon.GetWeaponInfo();
        }
    }
}
