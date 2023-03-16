using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Knights.Models
{
    public abstract class ItemModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }

        public virtual void ItemDescription()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Cost: {Cost}");
        }
        public virtual void ItemDescriptionShort()
        {
            Console.WriteLine($"Name: {Name} | Description: {Description} | Cost: {Cost}");
        }
    }
}
