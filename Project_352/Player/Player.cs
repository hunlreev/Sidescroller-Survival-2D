/* Author: Hunter Reeves
 * Date: 10/24/2019
 * File: Player.cs
 * Description: Base class for the player, contains all information and actions needed
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project_352
{
    class Player
    {
        // Create a Player, default constructor
        public Player(string name)
        {
            _name = name;
            _class = "No Class";
            info.level = 1;
            info.gold = 0;
            info.exp = 0;
            info.totalExp = 50;
            stats.health = 100;
            stats.mana = 100;
            stats.stamina = 100;
            attr.strength = 10;
            attr.endurance = 10;
            attr.intelligence = 10;
            attr.dexterity = 10;
        }

        // All information associated with a Player
        private string _name;
        private string _class;
        Information info = new Information();
        Stats stats = new Stats();
        Attributes attr = new Attributes();
    }
}
