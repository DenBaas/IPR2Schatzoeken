﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation.Geofencing;
using Bing.Maps.Directions;
using Schatzoeken.Control;
using Windows.Devices.Geolocation;

namespace Schatzoeken.Model
{
    public class Monster : RouteObject
    {
        public readonly int HitPoints;

        public Monster(string newMonster,string newTitle, Geofence newGeo, int newHitPoints) 
            : base(newMonster,newTitle,newGeo, false)
        {
            if (newHitPoints > 0)
                this.HitPoints = -1 * newHitPoints;
            else
                this.HitPoints = newHitPoints;
            visited = false;
        }

        public override void Action()
        {
            visited = true;
            Controller.GetController().Person.AddScore(HitPoints);
        }
    }
}
