﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schatzoeken.Model;

namespace Schatzoeken.Control
{
    public class Controller
    {
        public Route route;
        public Person Person = new Person();
        public int score = 0;
        //singleton
        private static Controller controller = null;

        private Controller()
        {
            route = new Route();
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

        public void Save()
        {
            DataReader.GetDataReader().SavePerson(Person);
        }
    }
}
