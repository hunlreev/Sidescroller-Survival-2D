/* Author: Hunter Reeves
 * Date: 10/24/2019
 * File: Mage.cs
 * Description: Class for Mage
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project_352
{
    class Mage : Player
    {
        // Create a Mage
        public Mage(string name) : base(name)
        {
            _name = name;
            _class = "Mage";
            info.level = 1;
            info.gold = 0;
            info.exp = 0;
            info.totalExp = 50;
            stats.health = 100;
            stats.mana = 100;
            stats.stamina = 100;
            attr.strength = 6;
            attr.endurance = 8;
            attr.intelligence = 14;
            attr.dexterity = 12;
        }
        // TODO - Damage the player does, accounts for strength stat and weapon damage
        public double DoDamage()
        {
            double damage = 0.25 * (double)attr.intelligence;

            return damage;
        }

        private string _name;
        private string _class;
        Information info = new Information();
        Stats stats = new Stats();
        Attributes attr = new Attributes();
    }
}
