using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Knights.Controller
{
    public class SaveController
    {
        private static SaveController instance = null;
        private static readonly object padlock = new object();

        public static SaveController Instance
        {
            get
            {
                lock (padlock)
                {

                    if (instance == null)
                        instance = new SaveController();
                    return instance;
                }
            }
        }
    }
}
