using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Knights.Controller
{
    public class ShopController : MainController
    {
        private static ShopController instance = null;
        private static readonly object padlock = new object();

        public static ShopController Instance
        {
            get
            {
                lock (padlock)
                {

                    if (instance == null)
                        instance = new ShopController();
                    return instance;
                }
            }
        }
    }
}
