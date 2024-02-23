using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayMagicalDuel
{
    internal class Program
    {
        static List<Player> players = new List<Player>();
        static List<Stats> skillStatistics = new List<Stats>();
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Player");
                Console.WriteLine("2. Add Skill Statistics");
                Console.WriteLine("3. Display Player Info");
                Console.WriteLine("4. Learn a Skill");
                Console.WriteLine("5. Attack");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    AddPlayer();
                }
                else if (choice == 2)
                {
                    AddSkillStatistics();
                }
                else if (choice == 3)
                {
                    DisplayPlayerInfo();
                }
                else if (choice == 4)
                {
                    LearnSkill();
                }
                else if (choice == 5)
                {
                    Attack();
                }
                else if (choice == 6)
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please choose again.");
                }

                Console.ReadKey();
            }
        }

        static void AddPlayer()
        {
            Console.Clear();
            Console.Write("Enter player name: ");
            string name = Console.ReadLine();
            Console.Write("Enter health: ");
            float health = float.Parse(Console.ReadLine());
            Console.Write("Enter max health: ");
            float maxHealth = float.Parse(Console.ReadLine());
            Console.Write("Enter energy: ");
            float energy = float.Parse(Console.ReadLine());
            Console.Write("Enter max energy: ");
            float maxEnergy = float.Parse(Console.ReadLine());
            Console.Write("Enter armor: ");
            float armor = float.Parse(Console.ReadLine());

            Player player = new Player(name, health, energy, armor);
            players.Add(player);
        }

        static void AddSkillStatistics()
        {
            Console.Clear();
            Console.Write("Enter skill name: ");
            string name = Console.ReadLine();
            Console.Write("Enter damage: ");
            float damage = float.Parse(Console.ReadLine());
            Console.Write("Enter penetration: ");
            float penetration = float.Parse(Console.ReadLine());
            Console.Write("Enter heal: ");
            float heal = float.Parse(Console.ReadLine());
            Console.Write("Enter cost: ");
            float cost = float.Parse(Console.ReadLine());
            Console.Write("Enter description: ");
            string description = Console.ReadLine();

            Stats stats = new Stats(name, damage, penetration, heal, cost, description);
            skillStatistics.Add(stats);
        }

        static void DisplayPlayerInfo()
        {
            Console.Clear();
            foreach (var player in players)
            {
                Console.WriteLine($"Player: {player.name}, Health: {player.Health}/{player.maxHp}, Energy: {player.Energy}/{player.maxEnergy}, Armor: {player.Armor}");
            }
        }

        static void LearnSkill()
        {
            Console.Clear();
            Console.Write("Enter player name: ");
            string playerName = Console.ReadLine();
            Console.Write("Enter skill name: ");
            string skillName = Console.ReadLine();

            Player player = players.Find(p => p.name == playerName);
            if (player == null)
            {
                Console.WriteLine("Player not found.");
                return;
            }

            Stats stats = skillStatistics.Find(s => s.name == skillName);
            if (stats == null)
            {
                Console.WriteLine("Skill not found.");
                return;
            }

            player.learnSkill(stats);
            Console.WriteLine($"{playerName} learned {skillName}.");
        }

        static void Attack()
        {
            Console.Clear();
            Console.WriteLine("Choose the attacking player:");
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {players[i].name}");
            }
            Console.Write("Enter choice: ");
            int attackerIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Choose the target player:");
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {players[i].name}");
            }
            Console.Write("Enter choice: ");
            int targetIndex = int.Parse(Console.ReadLine()) - 1;

            Player attacker = players[attackerIndex];
            Player target = players[targetIndex];

            Console.WriteLine(attacker.attack(target));
        }


    }
}

