/* Name: Hunter Reeves, Billy Gibson
 * Date: 11/25/2019
 * File: MainWindow.xaml.cs
 * Description: Main window for the game!
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Project_352
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Initializing the game window
        public MainWindow(Warrior w, Mage m, Rogue r)
        {
            InitializeComponent();

            _warrior = w;
            _mage = m;
            _rogue = r;
        }
        // Shows information to the user of their player
        private void ShowPlayerInfo(object sender, EventArgs e)
        {
            // For the Warrior
            if (_mage == null && _rogue == null)
            {
                name.Content = "Name: " + _warrior.name;
                gold.Content = "Gold: " + _warrior.info.gold;
                level.Content = "Level: " + _warrior.info.level;
                exp.Content = "EXP: " + _warrior.info.exp + "/" + _warrior.info.totalExp;
                cls.Content = "Class: " + _warrior.classification;
                health.Content = "Health: " + _warrior.stats.health + "/" + _warrior.stats.totalHealth;
                mana.Content = "Mana: " + _warrior.stats.mana + "/" + _warrior.stats.totalMana;
                mana.Content = "Mana: " + _warrior.stats.mana + "/" + _warrior.stats.totalMana;
                stamina.Content = "Stamina: " + _warrior.stats.stamina + "/" + _warrior.stats.totalStamina;
                strength.Content = "Strength: " + _warrior.attr.strength;
                endurance.Content = "Endurance: " + _warrior.attr.endurance;
                intelligence.Content = "Intelligence: " + _warrior.attr.intelligence;
                dexterity.Content = "Dexterity: " + _warrior.attr.dexterity;
                damage.Content = "Player Damage: " + _warrior.DoDamage();
            }
            // For the Mage
            if (_warrior == null && _rogue == null)
            {
                name.Content = "Name: " + _mage.name;
                gold.Content = "Gold: " + _mage.info.gold;
                level.Content = "Level: " + _mage.info.level;
                exp.Content = "EXP: " + _mage.info.exp + "/" + _mage.info.totalExp;
                cls.Content = "Class: " + _mage.classification;
                health.Content = "Health: " + _mage.stats.health + "/" + _mage.stats.totalHealth;
                mana.Content = "Mana: " + _mage.stats.mana + "/" + _mage.stats.totalMana;
                mana.Content = "Mana: " + _mage.stats.mana + "/" + _mage.stats.totalMana;
                stamina.Content = "Stamina: " + _mage.stats.stamina + "/" + _mage.stats.totalStamina;
                strength.Content = "Strength: " + _mage.attr.strength;
                endurance.Content = "Endurance: " + _mage.attr.endurance;
                intelligence.Content = "Intelligence: " + _mage.attr.intelligence;
                dexterity.Content = "Dexterity: " + _mage.attr.dexterity;
                damage.Content = "Player Damage: " + _mage.DoDamage();
            }
            // For the Rogue
            if (_warrior == null && _mage == null)
            {
                name.Content = "Name: " + _rogue.name;
                gold.Content = "Gold: " + _rogue.info.gold;
                level.Content = "Level: " + _rogue.info.level;
                exp.Content = "EXP: " + _rogue.info.exp + "/" + _rogue.info.totalExp;
                cls.Content = "Class: " + _rogue.classification;
                health.Content = "Health: " + _rogue.stats.health + "/" + _rogue.stats.totalHealth;
                mana.Content = "Mana: " + _rogue.stats.mana + "/" + _rogue.stats.totalMana;
                mana.Content = "Mana: " + _rogue.stats.mana + "/" + _rogue.stats.totalMana;
                stamina.Content = "Stamina: " + _rogue.stats.stamina + "/" + _rogue.stats.totalStamina;
                strength.Content = "Strength: " + _rogue.attr.strength;
                endurance.Content = "Endurance: " + _rogue.attr.endurance;
                intelligence.Content = "Intelligence: " + _rogue.attr.intelligence;
                dexterity.Content = "Dexterity: " + _rogue.attr.dexterity;
                damage.Content = "Player Damage: " + _rogue.DoDamage();
            }
        }
        // Levels System for the Player (subject to be tweaked in the future)
        private void LevelUp(object sender, EventArgs e)
        {
            // For the Warrior
            if (_mage == null && _rogue == null)
            {
                if (_warrior.info.exp >= _warrior.info.totalExp)
                {
                    // Level 20 is the Max Level
                    if (_warrior.info.level < 20)
                    {
                        _warrior.info.level += 1;
                        _warrior.info.exp = 0;
                        _warrior.info.totalExp = (int)Math.Pow(_warrior.info.totalExp, 1.035);
                        _warrior.stats.health += 10;
                        _warrior.stats.totalHealth += 10;
                        _warrior.stats.stamina += 5;
                        _warrior.stats.totalStamina += 5;
                        _warrior.stats.mana += 5;
                        _warrior.stats.totalMana += 5;
                        _warrior.attr.strength += 3;
                        _warrior.attr.endurance += 2;
                        _warrior.attr.dexterity += 1;
                        _warrior.attr.intelligence += 1;

                        ShowPlayerInfo(sender, e);
                    }
                    else
                    {
                        _warrior.info.exp = _warrior.info.totalExp;
                    }
                }
            }
            // For the Mage
            if (_warrior == null && _rogue == null)
            {
                if (_mage.info.exp >= _mage.info.totalExp)
                {
                    // Level 20 is the Max Level
                    if (_mage.info.level < 20)
                    {
                        _mage.info.level += 1;
                        _mage.info.exp = 0;
                        _mage.info.totalExp = (int)Math.Pow(_mage.info.totalExp, 1.035);
                        _mage.stats.health += 5;
                        _mage.stats.totalHealth += 5;
                        _mage.stats.stamina += 5;
                        _mage.stats.totalStamina += 5;
                        _mage.stats.mana += 10;
                        _mage.stats.totalMana += 10;
                        _mage.attr.strength += 2;
                        _mage.attr.endurance += 1;
                        _mage.attr.dexterity += 1;
                        _mage.attr.intelligence += 3;

                        ShowPlayerInfo(sender, e);
                    }
                    else
                    {
                        _mage.info.exp = _mage.info.totalExp;
                    }
                }
            }
            // For the Rogue
            if (_warrior == null && _mage == null)
            {
                if (_rogue.info.exp >= _rogue.info.totalExp)
                {
                    // Level 20 is the Max Level
                    if (_rogue.info.level < 20)
                    {
                        _rogue.info.level += 1;
                        _rogue.info.exp = 0;
                        _rogue.info.totalExp = (int)Math.Pow(_rogue.info.totalExp, 1.035);
                        _rogue.stats.health += 5;
                        _rogue.stats.totalHealth += 5;
                        _rogue.stats.stamina += 10;
                        _rogue.stats.totalStamina += 10;
                        _rogue.stats.mana += 5;
                        _rogue.stats.totalMana += 5;
                        _rogue.attr.strength += 2;
                        _rogue.attr.endurance += 1;
                        _rogue.attr.dexterity += 3;
                        _rogue.attr.intelligence += 1;

                        ShowPlayerInfo(sender, e);
                    }
                    else
                    {
                        _rogue.info.exp = _rogue.info.totalExp;
                    }
                }
            }
        }
        // For debugging/testing player level up on exp gain
        private void KillRat(object sender, EventArgs e)
        {
            // New rat to kill
            Rat rat = new Rat();

            // For the Warrior
            if (_mage == null && _rogue == null)
            {
                _warrior.info.exp += rat.Exp();
                LevelUp(sender, e);
                ShowPlayerInfo(sender, e);
            }
            // For the Mage
            if (_warrior == null && _rogue == null)
            {
                _mage.info.exp += rat.Exp();
                LevelUp(sender, e);
                ShowPlayerInfo(sender, e);
            }
            // For the Rogue
            if (_warrior == null && _mage == null)
            {
                _rogue.info.exp += rat.Exp();
                LevelUp(sender, e);
                ShowPlayerInfo(sender, e);
            }
        }
        private void KillGoblin(object sender, EventArgs e)
        {
            // New goblin to kill
            Goblin goblin = new Goblin();

            // For the Warrior
            if (_mage == null && _rogue == null)
            {
                _warrior.info.exp += goblin.Exp();
                LevelUp(sender, e);
                ShowPlayerInfo(sender, e);
            }
            // For the Mage
            if (_warrior == null && _rogue == null)
            {
                _mage.info.exp += goblin.Exp();
                LevelUp(sender, e);
                ShowPlayerInfo(sender, e);
            }
            // For the Rogue
            if (_warrior == null && _mage == null)
            {
                _rogue.info.exp += goblin.Exp();
                LevelUp(sender, e);
                ShowPlayerInfo(sender, e);
            }
        }
        private void KillOgre(object sender, EventArgs e)
        {
            // New ogre to kill
            Ogre ogre = new Ogre();

            // For the Warrior
            if (_mage == null && _rogue == null)
            {
                _warrior.info.exp += ogre.Exp();
                LevelUp(sender, e);
                ShowPlayerInfo(sender, e);
            }
            // For the Mage
            if (_warrior == null && _rogue == null)
            {
                _mage.info.exp += ogre.Exp();
                LevelUp(sender, e);
                ShowPlayerInfo(sender, e);
            }
            // For the Rogue
            if (_warrior == null && _mage == null)
            {
                _rogue.info.exp += ogre.Exp();
                LevelUp(sender, e);
                ShowPlayerInfo(sender, e);
            }
        }
        // Gain random amount of gold (for debugging)
        private void GainGold(object sender, EventArgs e)
        {
            Random rand = new Random();
            int gold = rand.Next(3, 12);

            // For the Warrior
            if (_mage == null && _rogue == null)
            {
                _warrior.info.gold += gold;
                ShowPlayerInfo(sender, e);
            }
            // For the Mage
            if (_warrior == null && _rogue == null)
            {
                _mage.info.gold += gold;
                ShowPlayerInfo(sender, e);
            }
            // For the Rogue
            if (_warrior == null && _mage == null)
            {
                _rogue.info.gold += gold;
                ShowPlayerInfo(sender, e);
            }
        }
        // A cheat code for getting tons of exp (for debugging)
        private void TonsOfEXP(object sender, EventArgs e)
        {
            // For the Warrior
            if (_mage == null && _rogue == null)
            {
                _warrior.info.exp += 1000;
                LevelUp(sender, e);
                ShowPlayerInfo(sender, e);
            }
            // For the Mage
            if (_warrior == null && _rogue == null)
            {
                _mage.info.exp += 1000;
                LevelUp(sender, e);
                ShowPlayerInfo(sender, e);
            }
            // For the Rogue
            if (_warrior == null && _mage == null)
            {
                _rogue.info.exp += 1000;
                LevelUp(sender, e);
                ShowPlayerInfo(sender, e);
            }
        }
        // Press ESC to close the window
        private void CloseWindow(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private Warrior _warrior;
        private Mage _mage;
        private Rogue _rogue;
    }
}