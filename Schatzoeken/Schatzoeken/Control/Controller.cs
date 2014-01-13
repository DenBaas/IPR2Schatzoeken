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
        public Person person;
        public int score;

        public Controller(MainPage mainpage)
        {
            Read();
               
        }

        public Route GetRoute()
        {
            return route;
        }

        public void Read()
        {
            //inladen

            if(route == null)
            {
                route = Route.GETSTANDARDROUTE(); 
                Save();
            }
        }

        public void Save()
        {

        }

    }
}
