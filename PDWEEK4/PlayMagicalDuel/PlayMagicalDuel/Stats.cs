using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayMagicalDuel
{
    internal class Stats
    {
        public string name;
        public float damage;
        public string description;
        public float penetration;
        public float cost;
        public float heal;

        public Stats(string name, float damage, float penetration, float heal, float cost, string description)
        {
            this.name = name;
            this.damage = damage;
            this.penetration = penetration;
            this.heal = heal;
            this.cost = cost;
            this.description = description;
        }
    }
}
