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
        public Player()
        {
            name = "Player";
            classification = "No Class";
            level = 1;
            gold = 0;
            exp = 0;
            totalExp = 50;
            
            // Health, Mana, and Stamina set to 100
            for(int i = 0; i < TOTALSTATS; i++)
            {
                stats[i] = 100;
            }

            // Strength, Intelligence, and Dexterity set to 10;
            for(int i = 0; i < TOTALATTRIBUTES; i++)
            {
                attributes[i] = 10;
            }
        }
        // DELETEME - more for debugging
        public void GetInfo()
        {
            // Print out info to Output Window for testing
            Trace.WriteLine("Name: " + name);
            Trace.WriteLine("Class: " + classification);
            Trace.WriteLine("Level: " + Convert.ToString(level));
            Trace.WriteLine("Gold: " + Convert.ToString(gold));
            Trace.WriteLine("Exp: " + Convert.ToString(exp) + "/" + Convert.ToString(totalExp));
            Trace.WriteLine("Health: " + Convert.ToString(stats[0]) + " Mana: " + Convert.ToString(stats[1]) + " Stamina: " + Convert.ToString(stats[2])); // Hard coded because this code is temporary...
            Trace.WriteLine("Strength: " + Convert.ToString(attributes[0]) + " Intelligence: " + Convert.ToString(attributes[1]) + " Dexterity: " + Convert.ToString(attributes[2])); // Hard coded because this code is temporary...
        }

        // All information associated with a Player
        private string name;
        private string classification; // either Warrior, Mage, or Rogue
        private int level;
        private int gold;
        private int exp; // current amount of experience
        private int totalExp; // experience needed to reach next level
        private int[] attributes = new int[3]; // health, mana, stamina - in that order
        private int[] stats = new int[3]; // strength, intelligence, dexterity - in that order
        const int TOTALSTATS = 3;
        const int TOTALATTRIBUTES = 3;
    }
}
