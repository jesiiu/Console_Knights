using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Knights.Controller
{
    public class FightController : MainController
    {
        private static FightController instance = null;
        private static readonly object padlock = new object();

        public static FightController Instance
        {
            get
            {
                lock (padlock)
                {

                    if (instance == null)
                        instance = new FightController();
                    return instance;
                }
            }
        }
    }
}
