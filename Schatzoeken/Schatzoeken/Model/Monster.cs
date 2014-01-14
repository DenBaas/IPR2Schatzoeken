﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation.Geofencing;
using Bing.Maps.Directions;
using Schatzoeken.Control;

namespace Schatzoeken.Model
{
    public class Monster : RouteObject
    {
        public readonly int HitPoints;

        public Monster(string newMonster, Geofence newGeo, int newHitPoints, Waypoint waypoint) : base(newMonster,newGeo, waypoint)
        {
            this.HitPoints = newHitPoints;
        }



        public override void Action()
        {
            Controller.GetController().Person.AddScore(HitPoints);
        }
    }
}
