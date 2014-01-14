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
        private static Controller controller = null;

        private Controller()
        {
            Read();
               
        }

        public static Controller GetController()
        {
            if (controller == null)
                controller = new Controller();
            return controller;
        }

        public void EndGame()
        {

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
            if (person == null)
            {
                person = new Person("asdfsdafsdf");
                person.addScore(400);
            }
            DataReader.GetDataReader().Save(person);
        }
    }
}
