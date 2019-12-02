using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_352
{
    // Contains health, mana, and stamina
    public struct E_Stats
    {
        public int health; // health of enemy, gives exp to player once this reaches 0
        public int totalHealth; // total health of an enemy
    }
}
