/* Author: Hunter Reeves
 * Date: 11/30/2019
 * File: Enemies.cs
 * Description: The three enemy types you can fight in the game!
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_352
{
    // Rat class, weakest enemy, gives the lowest amount of exp
    public class Rat
    {
        public Rat()
        {
            stats.health = 25;
            stats.totalHealth = 25;
        }
        public double DoDamage()
        {
            return rand.Next(1, 3);
        }
        public int Exp()
        {
            return rand.Next(5, 10);
        }
        public int Gold()
        {
            return rand.Next(5, 10);
        }
        public string AppearedMessage()
        {
            return "A wild rat appeared!\n";
        }
        public string DamageMessage()
        {
            return "Rat did " + DoDamage() + " damage.\n";
        }
        public string DeathMessage()
        {
            return "\nYou killed the rat!\n";
        }

        // Icon for the Rat
        string icon = "🐀";
        public E_Stats stats;
        public Random rand = new Random();
    }
    // Goblin class, moderate enemy, moderate exp
    public class Goblin
    {
        public Goblin()
        {
            stats.health = 100;
            stats.totalHealth = 100;
        }
        public double DoDamage()
        {
            return rand.Next(5, 10);
        }
        public int Exp()
        {
            return rand.Next(15, 20); 
        }
        public int Gold()
        {
            return rand.Next(10, 15);
        }
        public string AppearedMessage()
        {
            return "A wild goblin appeared!\n";
        }
        public string DamageMessage()
        {
            return "Goblin did " + DoDamage() + " damage.\n";
        }
        public string DeathMessage()
        {
            return "You killed the goblin!\n";
        }

        // Icon for the Goblin
        string icon = "👺";
        public E_Stats stats;
        public Random rand = new Random();
    }
    // Ogre class, hardest enemy and the most exp
    public class Ogre
    {
        public Ogre()
        {
            stats.health = 200;
            stats.totalHealth = 200;
        }
        public double DoDamage()
        {
            return rand.Next(15, 20);
        }
        public int Exp()
        {
            return rand.Next(50, 75);
        }
        public int Gold()
        {
            return rand.Next(20, 30);
        }
        public string AppearedMessage()
        {
            return "A wild ogre appeared!\n";
        }
        public string DamageMessage()
        {
            return "Ogre did " + DoDamage() + " damage.\n";
        }
        public string DeathMessage()
        {
            return "You killed the ogre!\n";
        }

        // Icon for the Ogre
        string icon = "👹";
        public E_Stats stats;
        public Random rand = new Random();
    }
    // Dragon class, the final boss
    public class Dragon
    {
        public Dragon()
        {
            stats.health = 500;
            stats.totalHealth = 500;
        }
        public double DoDamage()
        {
            return rand.Next(25, 35);
        }
        public int Exp()
        {
            return rand.Next(1000, 1250);
        }
        public int Gold()
        {
            return rand.Next(250, 500);
        }
        public string AppearedMessage()
        {
            return "The dragon appeared!\n";
        }
        public string DamageMessage()
        {
            return "Dragon did " + DoDamage() + " damage.\n";
        }
        public string DeathMessage()
        {
            return " killed the dragon!\n";
        }

        // Icon for the Ogre
        string icon = "🐉";
        public E_Stats stats;
        public Random rand = new Random();
    }
}
