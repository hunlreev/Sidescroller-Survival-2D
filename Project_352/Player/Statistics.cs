/* Author: Hunter Reeves
 * Date: 10/24/2019
 * File: Statistics.cs
 * Description: All information needed for the Player
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_352
{
    // Contains Level, Gold, EXP, and TotalEXP
    public struct Information
    {
        public int level;    // level of player, level cap at 15
        public int gold;     // currency for player, buy and sell items
        public int exp;      // current amount of experience
        public int totalExp; // experience needed to reach next level
    }
    // Contains health, mana, and stamina
    public struct Stats
    {
        public int health;  // player dies when this reaches 0 
        public int mana;    // player cannot cast any more magic attacks when this reaches 0
        public int stamina; // player cannot move to another tile when this reaches 0
    }
    // Contains attributes for the player
    public struct Attributes
    {
        public int strength;     // effects amount of physical damage done
        public int endurance;    // effects amount of health player has
        public int intelligence; // effects amount of magical damage done, amount of mana player has
        public int dexterity;    // effects how often attacks are missed, attack bonus to rogues, amount of stamina player has
    }
}
