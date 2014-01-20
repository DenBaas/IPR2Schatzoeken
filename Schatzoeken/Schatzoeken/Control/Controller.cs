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
        public Route Route;
        public Person Person = new Person("baas");
        public bool GameEnded = false;
        //singleton
        private static Controller controller = null;

        private Controller()
        {
            Route = new Route();
        }

        public static Controller GetController()
        {
            if (controller == null)
                controller = new Controller();
            return controller;
        }

        public void EndGame()
        {
            DataReader.GetDataReader().SavePerson(Person);

            GameEnded = true;
        }
    }
}
