/* Author: Hunter Reeves
 * Date: 11/22/2019
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
        public double DoDamage()
        {
            return 5.25;
        }
        public int Exp()
        {
            return 10;
        }

        // Icon for the Rat
        string icon = "🐀";
    }
    // Goblin class, moderate enemy, moderate exp
    public class Goblin
    {
        public double DoDamage()
        {
            return 10.5;
        }
        public int Exp()
        {
            return 25;
        }

        // Icon for the Goblin
        string icon = "👺";
    }
    // Ogre class, hardest enemy and the most exp
    public class Ogre
    {
        public double DoDamage()
        {
            return 17.75;
        }
        public int Exp()
        {
            return 50;
        }

        // Icon for the Ogre
        string icon = "👹";
    }
}
