using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Knights.Assets;

namespace Console_Knights.Models
{
    public abstract class SaveModel
    {
        public static readonly string savePath = "./Save";
        public static Hero Hero { get; set; }
    }
}
