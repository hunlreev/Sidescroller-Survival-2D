/* Author: Hunter Reeves
 * Date: 10/27/2019
 * File: PlayerCreation.cs
 * Description: Handles player creation
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_352.Functionality
{
    class PlayerCreation
    {
        public Warrior Warrior(string name, string classification)
        {
            return new Warrior(name, classification);
        }
        public Mage Mage(string name, string classification)
        {
            return new Mage(name, classification);
        }
        public Rogue Rogue(string name, string classification)
        {
            return new Rogue(name, classification);
        }
    }
}
