using Console_Knights.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Knights.Memory
{
    public sealed class AppMemory
    {
        private static AppMemory instance = null;
        private static readonly object padlock = new object();
        public static AppMemory Instance
        {
            get
            {
                lock (padlock)
                {

                    if (instance == null)
                        instance = new AppMemory();
                    return instance;
                }
            }
        }
        public Hero mainHero { get; set; }
    }
}
