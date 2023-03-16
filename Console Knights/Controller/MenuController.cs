using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Knights.Controller
{
    public class MenuController : MainController
    {
        private static MenuController instance = null;
        private static readonly object padlock = new object();

        public static MenuController Instance
        {
            get
            {
                lock (padlock)
                {

                    if (instance == null)
                        instance = new MenuController();
                    return instance;
                }
            }
        }
    }
}
