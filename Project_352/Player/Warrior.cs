/* Author: Hunter Reeves
 * Date: 11/06/2019
 * File: Warrior.cs
 * Description: Class for Warrior
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project_352
{
    public class Warrior
    {
        // Create a Warrior
        public Warrior(string name, string classification)
        {
            this.name = name;
            this.classification = classification;
            info.level = 1;
            info.gold = 0;
            info.exp = 0;
            info.totalExp = 50;
            stats.health = 120;
            stats.totalHealth = 120;
            stats.mana = 70;
            stats.totalMana = 70;
            stats.stamina = 110;
            stats.totalStamina = 110;
            attr.strength = 14;
            attr.endurance = 12;
            attr.intelligence = 6;
            attr.dexterity = 8;
        }
        // Base damage the player does, accounts for strength stat and weapon damage
        public double DoDamage()
        {
            return 0.25 * attr.strength;
        }

        public string name;
        public string classification;
        public Information info = new Information();
        public Stats stats = new Stats();
        public Attributes attr = new Attributes();
    }
}
