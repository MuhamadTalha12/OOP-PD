using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalDuel
{
    internal class Player
    {
        public string name;
        public float Health;
        private float hp;
        private float maxHp;
        private float energy;
        private float maxEnergy;
        private float armor;
        private Stats skillStatistics;

        public Player(string name, float Health, float energy, float armor)
        {
            this.name = name;
            this.Health = Health;
            this.energy = energy;
            this.armor = armor;
        }

        public void updateHealth(float amount)
        {
            hp += amount;
            if (hp < 0)
                hp = 0;
            else if (hp > maxHp)
                hp = maxHp;
        }

        public void updateEnergy(float amount)
        {
            energy += amount;
            if (energy < 0)
                energy = 0;
            else if (energy > maxEnergy)
                energy = maxEnergy;
        }

        public void updateArmor(float amount)
        {
            armor += amount;
            if (armor < 0)
                armor = 0;
        }

        public void learnSkill(Stats stats)
        {
            skillStatistics = stats;
        }

        public string attack(Player target)
        {
            if (skillStatistics == null)
            {
                return $"{name} attempted to attack, but hasn't learned any skill yet!";
            }

            if (energy < skillStatistics.Cost)
            {
                return $"{name} attempted to use {skillStatistics.Name}, but didn't have enough energy!";
            }

            energy -= skillStatistics.Cost;

            float effectiveArmor = Math.Max(0, target.armor - skillStatistics.Penetration);
            float calculatedDamage = skillStatistics.Damage * ((100 - effectiveArmor) / 100);

            target.updateHealth(-calculatedDamage);
            updateHealth(skillStatistics.Heal);

            string result = $"{name} used {skillStatistics.Name}, {skillStatistics.Description}, against {target.name}, doing {calculatedDamage} damage!";

            if (skillStatistics.Heal > 0)
            {
                result += $" {name} healed for {skillStatistics.Heal} health!";
            }

            if (target.hp <= 0)
            {
                result += $" {target.name} died.";
            }
            else
            {
                float targetHpPercentage = (target.hp / target.maxHp) * 100;
                result += $" {target.name} is at {targetHpPercentage:F2}% health.";
            }

            return result;
        }
    }
}
