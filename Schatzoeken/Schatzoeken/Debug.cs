using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schatzoeken
{
    public class Debug
    {
        public static void Print(object printObject)
        {
            System.Diagnostics.Debug.WriteLine(printObject);
        }
    }
}
