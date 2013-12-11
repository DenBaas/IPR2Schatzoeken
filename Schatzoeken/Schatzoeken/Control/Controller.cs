using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schatzoeken.Model;

namespace Schatzoeken.Control
{
    public class Controller
    {
        private Route route = null;

        public Controller(MainPage mainpage)
        {
            read();
               
        }

        public void read()
        {
            //inladen

            if(route == null)
            {
                route = Route.GETSTANDARDROUTE(); 
                save();
            }
        }

        public void save()
        {

        }

    }
}
