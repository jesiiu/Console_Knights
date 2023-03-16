using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Knights.Utils.Exceptions;

namespace Console_Knights.Controller
{
    public class InitialzeController : MainController
    {
        private HeroController heroController = HeroController.Instance;
        private MenuController menuController = MenuController.Instance;

        private static InitialzeController instance = null;
        private static readonly object padlock = new object();
        public static InitialzeController Instance
        {
            get
            {
                lock (padlock)
                {

                    if (instance == null)
                        instance = new InitialzeController();
                    return instance;
                }
            }
        }
        public void InitializeApplication()
        {
            Console.WriteLine("Welcome in Console Knights");
            try
            {
                heroController.CreateKnight();
                menuController.MainMenu();
            }
            catch
            {
                throw new NotInitializedException("Game was not initialized correctly.");
            }
        }
    }
}
