using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanNavigation
{
    internal class Angle
    {
        public int degrees;
        public float minutes;
        public char direction;
        public Angle(int degrees, float minutes, char direction)
        {
            this.degrees = degrees;
            this.minutes = minutes;
            this.direction = direction;
        }
        public void changeAngle(int Degree, float Minutes, char Direction)
        {
            degrees = Degree;
            minutes = Minutes;
            direction = Direction;
        }
        public string displayAngle()
        {
            return $"{degrees}\u00b0{minutes}\'{direction}";

        }
    }
}
