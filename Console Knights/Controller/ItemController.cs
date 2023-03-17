using Console_Knights.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Knights.Controller
{
    public class ItemController : MainController
    {
        private static ItemController instance = null;
        private static readonly object padlock = new object();

        public static ItemController Instance
        {
            get
            {
                lock (padlock)
                {

                    if (instance == null)
                        instance = new ItemController();
                    return instance;
                }
            }
        }

        public void UseItemHealthPotion(HealthPotion potion)
        {
            var currentHealth = appMemory.mainHero.currentHealth;
            var regeneratePower = potion.regenerateValue;
            var control = currentHealth + regeneratePower;
            if (control > appMemory.mainHero.maxHealth)
            {
                appMemory.mainHero.currentHealth = appMemory.mainHero.maxHealth;
            }
            else
            {
                appMemory.mainHero.currentHealth += regeneratePower;
            }
        }
    }
}
