using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanNavigation
{
    internal class Ship
    {
        public string shipNumber;
        public Angle Latitude;
        public Angle Longitude;
        public Ship(string shipNumber, Angle Latitude, Angle Longitude)
        {
            this.shipNumber = shipNumber;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }
        public string printPosition()
        {
            return $"Ship is at position {Latitude.displayAngle()} and {Longitude.displayAngle()}";
        }
        public string printSerialNumber()
        {
            return $"Ship's number: {shipNumber}";
        }
    }

}
