using Console_Knights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Knights.Assets
{
    public class HealthPotion : ItemModel
    {
        private int regenerateValue = 2;
        public HealthPotion() { Name = "Health potion"; Description = $"Regenerate {regenerateValue}"; Cost = 10; }

        public override void ItemDescription()
        {
            base.ItemDescription();
        }
        public override void ItemDescriptionShort()
        {
            base.ItemDescriptionShort();
        }
    }
}
