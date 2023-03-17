using Console_Knights.Memory;
using Console_Knights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Knights.Assets
{
    public class Tavern : ShopModel
    {
        public List<ItemModel> Items { get; set; } = new List<ItemModel>();

        private static Tavern instance = null;
        private static readonly object padlock = new object();
        public static Tavern Instance
        {
            get
            {
                lock (padlock)
                {

                    if (instance == null)
                        instance = new Tavern();
                    return instance;
                }
            }
        }

    }
}
