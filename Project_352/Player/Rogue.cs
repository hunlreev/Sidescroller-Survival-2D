/* Author: Hunter Reeves
 * Date: 11/06/2019
 * File: Rogue.cs
 * Description: Class for Rogue
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project_352
{
    public class Rogue
    {
        // Create a Rogue
        public Rogue(string name, string classification)
        {
            this.name = name;
            this.classification = classification;
            info.level = 1;
            info.gold = 0;
            info.exp = 0;
            info.totalExp = 50;
            stats.health = 70;
            stats.totalHealth = 70;
            stats.mana = 110;
            stats.totalMana = 110;
            stats.stamina = 120;
            stats.totalStamina = 120;
            attr.strength = 12;
            attr.endurance = 8;
            attr.intelligence = 6;
            attr.dexterity = 14;
        }
        // Base damage the player does, accounts for strength stat and weapon damage
        public new double DoDamage()
        {
            return 0.30 * (attr.strength + (attr.dexterity * 0.25));
        }

        public string name;
        public string classification;
        public Information info = new Information();
        public Stats stats = new Stats();
        public Attributes attr = new Attributes();
    }
}
