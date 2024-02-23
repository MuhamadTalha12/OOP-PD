using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalDuel
{
    internal class Stats
    {
        public string Name;
        public float Damage;
        public string Description;
        public float Penetration;
        public float Cost;
        public float Heal;

        public Stats(string Name, float Damage, string Description, float Penetration, float Cost, float Heal)
        {
            this.Name = Name;
            this.Damage = Damage;
            this.Description = Description;
            this.Penetration = Penetration;
            this.Cost = Cost;
            this.Heal = Heal;
        }
    }
}
