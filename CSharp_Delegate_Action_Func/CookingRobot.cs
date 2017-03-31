using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Delegate_Action_Func
{
    class CookingRobot
    {
        public static Func<string, string> CookDinner { get; set; }
        public static Func<string, string> CookLunch { get; set; }
        public static Func<string, string> CookBreakfast { get; set; }
    }
}
