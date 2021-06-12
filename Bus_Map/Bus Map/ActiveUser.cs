using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Map
{
   static class ActiveUser
    {
        public static int sValue
        {
            get { return svalue; }
            set { svalue = value; if (SomeEvent != null) SomeEvent(null, EventArgs.Empty); }
        }

        static int svalue;

        public static event EventHandler SomeEvent;

        //зміна для імені користувача
        public static string Name { get; set; }
    }
}
