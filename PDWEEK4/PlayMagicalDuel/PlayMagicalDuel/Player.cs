using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayMagicalDuel
{
    internal class Player
    {
        public string name;
        public double hp;
        public double maxHp;
        public double energy;
        public double maxEnergy;
        public double armor;
        private Stats skillStatistics;
        public double Health;
        public double Energy;
        public double Armor;


        public Player(string name, double health, double energy, double armor)
        {
            this.name = name;
            this.hp = health;
            this.maxHp = health;
            this.energy = energy;
            this.maxEnergy = energy;
            this.armor = armor;
        }

        public void updateHealth(double amount)
        {
            hp += amount;
            if (hp < 0)
                hp = 0;
            else if (hp > maxHp)
                hp = maxHp;
        }

        public void updateEnergy(double amount)
        {
            energy += amount;
            if (energy < 0)
                energy = 0;
            else if (energy > maxEnergy)
                energy = maxEnergy;
        }

        public void updateArmor(double amount)
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

            if (energy < skillStatistics.cost)
            {
                return $"{name} attempted to use {skillStatistics.name}, but didn't have enough energy!";
            }

            energy -= skillStatistics.cost;

            double effectiveArmor = Math.Max(0, target.armor - skillStatistics.penetration);
            double calculatedDamage = skillStatistics.damage * ((100 - effectiveArmor) / 100);

            target.updateHealth(-calculatedDamage);
            updateHealth(skillStatistics.heal);

            string result = $"{name} used {skillStatistics.name}, {skillStatistics.description}, against {target.name}, doing {calculatedDamage} damage!";

            if (skillStatistics.heal > 0)
            {
                result += $" {name} healed for {skillStatistics.heal} health!";
            }

            if (target.hp <= 0)
            {
                result += $" {target.name} died.";
            }
            else
            {
                double targetHpPercentage = (target.hp / target.maxHp) * 100;
                result += $" {target.name} is at {targetHpPercentage:F2}% health.";
            }

            return result;
        }
    }
}
