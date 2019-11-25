/* Author: Hunter Reeves
 * Date: 11/22/2019
 * File: Player.cs
 * Description: Interface for a Generic Player
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_352
{
    public interface IPlayer
    {
        string name { get; }
        string classification { get; }
        Information info { get; }
        Stats stats { get; }
        Attributes attr { get; }
    }
}
