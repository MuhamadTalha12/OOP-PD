using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MagicalDuel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player Talha = new Player("Talha", 110, 50, 10);
            Player Salman = new Player("Salman", 100, 60, 20);

            Stats fireball = new Stats("fireball", 25, "a fiery magical attack", 2.2F, 10, 4);
            Talha.learnSkill(fireball);
            Console.WriteLine(Talha.attack(Salman));

            Stats superbeam = new Stats("superbeam", 20, "an overpowered attack, pls nerf",60.0F, 40, 65);
            Salman.learnSkill(superbeam);
            Console.WriteLine(Salman.attack(Talha));

            Console.ReadKey();
        }
    }
}
