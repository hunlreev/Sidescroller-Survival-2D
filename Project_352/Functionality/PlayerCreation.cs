/* Author: Hunter Reeves
 * Date: 10/24/2019
 * File: PlayerCreation.cs
 * Description: Allows user to enter a name and select a class for them to play as in the game
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_352.Functionality
{
    /// <summary>
    /// pre-conditions:
    ///     player needs a name and class to be represented in the game and in the GUI
    /// 
    /// user types in name in the SelectPlayer screen
    /// user chooses class
    /// character is created with the name and class chosen
    /// 
    /// post-conditions:
    ///     player has selected name and class, changes reflect that and stat spread shows this
    /// </summary>
    class PlayerCreation
    {
        // Default Constructor
        public PlayerCreation()
        {
            // Code goes here
        }

        private string _name;
        private string _class;
    }
}
