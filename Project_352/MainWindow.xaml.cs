/* Name: Hunter Reeves, Billy Gibson
 * Date: 11/26/2019
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

            // Start up message
            dialog.Text = "Welcome to Text Adventure RPG, Player. " +
                          "You start off a confused adventure in the middle of a field. " +
                          "Choose your pathway and go forth to the castle to discover yourself and the role you play in these trying times. " +
                          "\n\nBegin your adventure now!";
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
                if (Player_Movement == 0)
                {
                    Player_Class = "🛡";
                    H4.Content = "🛡";
                }
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
                if (Player_Movement == 0)
                {
                    Player_Class = "🧙";
                    H4.Content = "🧙";
                }
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
                if (Player_Movement == 0) {
                    Player_Class = "🗡";
                    H4.Content = "🗡";
                }
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
                        _warrior.info.totalExp = (int)Math.Pow(_warrior.info.totalExp, 1.038);
                        _warrior.stats.health += (int)(_warrior.attr.endurance * 0.5);
                        _warrior.stats.totalHealth += (int)(_warrior.attr.endurance * 0.5);
                        _warrior.stats.stamina += (int)(_warrior.attr.dexterity * 0.5);
                        _warrior.stats.totalStamina += (int)(_warrior.attr.dexterity * 0.5);
                        _warrior.stats.mana += (int)(_warrior.attr.intelligence * 0.5);
                        _warrior.stats.totalMana += (int)(_warrior.attr.intelligence * 0.5);
                        _warrior.attr.strength += 3;
                        _warrior.attr.endurance += 2;
                        _warrior.attr.dexterity += 1;
                        _warrior.attr.intelligence += 1;

                        dialog.Text += _warrior.name + " leveled up! " + '\n';
                        _warrior.stats.health = _warrior.stats.totalHealth;
                        _warrior.stats.stamina = _warrior.stats.totalStamina;
                        _warrior.stats.mana = _warrior.stats.totalMana;

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
                        _mage.stats.health += (int)(_mage.attr.endurance * 0.5);
                        _mage.stats.totalHealth += (int)(_mage.attr.endurance * 0.5);
                        _mage.stats.stamina += (int)(_mage.attr.dexterity * 0.5);
                        _mage.stats.totalStamina += (int)(_mage.attr.dexterity * 0.5);
                        _mage.stats.mana += (int)(_mage.attr.intelligence * 0.5);
                        _mage.stats.totalMana += (int)(_mage.attr.intelligence * 0.5);
                        _mage.attr.strength += 2;
                        _mage.attr.endurance += 1;
                        _mage.attr.dexterity += 1;
                        _mage.attr.intelligence += 3;

                        dialog.Text += _mage.name + " leveled up! " + '\n';
                        _mage.stats.health = _mage.stats.totalHealth;
                        _mage.stats.stamina = _mage.stats.totalStamina;
                        _mage.stats.mana = _mage.stats.totalMana;

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
                        _rogue.info.totalExp = (int)Math.Pow(_rogue.info.totalExp, 1.0369);
                        _rogue.stats.health += (int)(_rogue.attr.endurance * 0.5);
                        _rogue.stats.totalHealth += (int)(_rogue.attr.endurance * 0.5);
                        _rogue.stats.stamina += (int)(_rogue.attr.dexterity * 0.5);
                        _rogue.stats.totalStamina += (int)(_rogue.attr.dexterity * 0.5);
                        _rogue.stats.mana += (int)(_rogue.attr.intelligence * 0.5);
                        _rogue.stats.totalMana += (int)(_rogue.attr.intelligence * 0.5);
                        _rogue.attr.strength += 2;
                        _rogue.attr.endurance += 1;
                        _rogue.attr.dexterity += 3;
                        _rogue.attr.intelligence += 1;

                        dialog.Text += _rogue.name + " leveled up! " + '\n';
                        _rogue.stats.health = _rogue.stats.totalHealth;
                        _rogue.stats.stamina = _rogue.stats.totalStamina;
                        _rogue.stats.mana = _rogue.stats.totalMana;

                        ShowPlayerInfo(sender, e);
                    }
                    else
                    {
                        _rogue.info.exp = _rogue.info.totalExp;
                    }
                }
            }
        }
        // For killing a rat
        private void KillRat(object sender, EventArgs e)
        {
            // For the Warrior
            if (_mage == null && _rogue == null)
            {
                int experience = rat.Exp();
                int gold = rat.Gold();
                _warrior.info.exp += experience;
                _warrior.info.gold += gold;
                LevelUp(sender, e);
                ShowPlayerInfo(sender, e);
                dialog.Text += "You recieved " + experience + " exp and " + gold + " gold!\n";
            }
            // For the Mage
            if (_warrior == null && _rogue == null)
            {
                int experience = rat.Exp();
                int gold = rat.Gold();
                _mage.info.exp += experience;
                _mage.info.gold += gold;
                LevelUp(sender, e);
                ShowPlayerInfo(sender, e);
                dialog.Text += "You recieved " + experience + " exp and " + gold + " gold!\n";
            }
            // For the Rogue
            if (_warrior == null && _mage == null)
            {
                int experience = rat.Exp();
                int gold = rat.Gold();
                _rogue.info.exp += experience;
                _rogue.info.gold += gold;
                LevelUp(sender, e);
                ShowPlayerInfo(sender, e);
                dialog.Text += "You recieved " + experience + " exp and " + gold + " gold!\n";
            }
        }
        // For killing a goblin, not finished
        private void KillGoblin(object sender, EventArgs e)
        {
            // For the Warrior
            if (_mage == null && _rogue == null)
            {
                if (_warrior.info.level >= 10)
                {
                    _warrior.info.exp += goblin.Exp();
                    _warrior.info.gold += goblin.Gold();
                    LevelUp(sender, e);
                    ShowPlayerInfo(sender, e);
                }
            }
            // For the Mage
            if (_warrior == null && _rogue == null)
            {
                if (_mage.info.level >= 10)
                {
                    _mage.info.exp += goblin.Exp();
                    _mage.info.gold += goblin.Gold();
                    LevelUp(sender, e);
                    ShowPlayerInfo(sender, e);
                }
            }
            // For the Rogue
            if (_warrior == null && _mage == null)
            {
                if (_rogue.info.level >= 10)
                {
                    _rogue.info.exp += goblin.Exp();
                    _rogue.info.gold += goblin.Gold();
                    LevelUp(sender, e);
                    ShowPlayerInfo(sender, e);
                }
            }
        }
        // For killing an ogre, not finished
        private void KillOgre(object sender, EventArgs e)
        {
            // For the Warrior
            if (_mage == null && _rogue == null)
            {
                if (_warrior.info.level >= 15)
                {
                    _warrior.info.exp += ogre.Exp();
                    _warrior.info.gold += ogre.Gold();
                    LevelUp(sender, e);
                    ShowPlayerInfo(sender, e);
                }
            }
            // For the Mage
            if (_warrior == null && _rogue == null)
            {
                if (_mage.info.level >= 15)
                {
                    _mage.info.exp += ogre.Exp();
                    _mage.info.gold += ogre.Gold();
                    LevelUp(sender, e);
                    ShowPlayerInfo(sender, e);
                }
            }
            // For the Rogue
            if (_warrior == null && _mage == null)
            {
                if (_rogue.info.level >= 15)
                {
                    _rogue.info.exp += ogre.Exp();
                    _rogue.info.gold += ogre.Gold();
                    LevelUp(sender, e);
                    ShowPlayerInfo(sender, e);
                }
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
        private Rat rat;
        private Goblin goblin;
        private Ogre ogre;
        private Random rand = new Random();

        private int Player_Position = 39;
        private int Player_Movement = 0;
        private int Previous_Tile;
        private int Next_Tile;
        private string Previous_Temp_Pos = "🌽";
        private string Player_Class;
        private string Next_Temp_Pos;
        private double ratDamage;

        public void Up_Arrow_Click(object sender, RoutedEventArgs e)
        {
           if( Player_Position%8 > 0 && Player_Position < 256 )
            {
                // Use stamina for every tile move
                if (_mage == null && _rogue == null)
                {
                   if (_warrior.stats.stamina - 10 >= 0)
                    {
                        Previous_Tile = Player_Position;
                        Next_Tile = Player_Position - 1;

                        Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));

                        Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);
                        Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);
                        Previous_Temp_Pos = Next_Temp_Pos;
                        Player_Position = Next_Tile;

                        // Use stamina
                        _warrior.stats.stamina -= 10;
                        stamina.Content = "Stamina: " + _warrior.stats.stamina + "/" + _warrior.stats.totalStamina;
                    }
                   else
                    {
                        Previous_Tile = Player_Position;
                    }
                }
                if (_warrior == null && _rogue == null)
                {
                    if (_mage.stats.stamina - 10 >= 0)
                    {
                        Previous_Tile = Player_Position;
                        Next_Tile = Player_Position - 1;

                        Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));

                        Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);
                        Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);
                        Previous_Temp_Pos = Next_Temp_Pos;
                        Player_Position = Next_Tile;

                        // Use stamina
                        _mage.stats.stamina -= 10;
                        stamina.Content = "Stamina: " + _mage.stats.stamina + "/" + _mage.stats.totalStamina;
                    }
                    else
                    {
                        Previous_Tile = Player_Position;
                    }
                }
                if (_warrior == null && _mage == null)
                {
                    if (_rogue.stats.stamina - 10 >= 0)
                    {
                        Previous_Tile = Player_Position;
                        Next_Tile = Player_Position - 1;

                        Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));

                        Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);
                        Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);
                        Previous_Temp_Pos = Next_Temp_Pos;
                        Player_Position = Next_Tile;

                        // Use stamina
                        _rogue.stats.stamina -= 10;
                        stamina.Content = "Stamina: " + _rogue.stats.stamina + "/" + _rogue.stats.totalStamina;
                    }
                    else
                    {
                        Previous_Tile = Player_Position;
                    }
                }

                NewEnemy(sender, e);
            }
        }
        private void Down_Arrow_Click(object sender, RoutedEventArgs e)
        {
            if (Player_Position%8 +1 != 8 && Player_Position < 256)
            {
                // Use stamina for every tile move
                if (_mage == null && _rogue == null)
                {
                    if (_warrior.stats.stamina - 10 >= 0)
                    {
                        Previous_Tile = Player_Position;
                        Next_Tile = Player_Position + 1;

                        Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));

                        Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);
                        Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);
                        Previous_Temp_Pos = Next_Temp_Pos;
                        Player_Position = Next_Tile;

                        // Use stamina
                        _warrior.stats.stamina -= 10;
                        stamina.Content = "Stamina: " + _warrior.stats.stamina + "/" + _warrior.stats.totalStamina;
                    }
                    else
                    {
                        Previous_Tile = Player_Position;
                    }
                }
                if (_warrior == null && _rogue == null)
                {
                    if (_mage.stats.stamina - 10 >= 0)
                    {
                        Previous_Tile = Player_Position;
                        Next_Tile = Player_Position + 1;

                        Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));

                        Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);
                        Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);
                        Previous_Temp_Pos = Next_Temp_Pos;
                        Player_Position = Next_Tile;

                        // Use stamina
                        _mage.stats.stamina -= 10;
                        stamina.Content = "Stamina: " + _mage.stats.stamina + "/" + _mage.stats.totalStamina;
                    }
                    else
                    {
                        Previous_Tile = Player_Position;
                    }
                }
                if (_warrior == null && _mage == null)
                {
                    if (_rogue.stats.stamina - 10 >= 0)
                    {
                        Previous_Tile = Player_Position;
                        Next_Tile = Player_Position + 1;

                        Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));

                        Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);
                        Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);
                        Previous_Temp_Pos = Next_Temp_Pos;
                        Player_Position = Next_Tile;

                        // Use stamina
                        _rogue.stats.stamina -= 10;
                        stamina.Content = "Stamina: " + _rogue.stats.stamina + "/" + _rogue.stats.totalStamina;
                    }
                    else
                    {
                        Previous_Tile = Player_Position;
                    }
                }

                NewEnemy(sender, e);
            }
        }
        private void Left_Arrow_Click(object sender, RoutedEventArgs e)
        {
            if (Player_Position-8 > 0)
            {
                // Use stamina for every tile move
                if (_mage == null && _rogue == null)
                {
                    if (_warrior.stats.stamina - 10 >= 0)
                    {
                        Previous_Tile = Player_Position;
                        Next_Tile = Player_Position - 8;

                        Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));

                        Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);
                        Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);
                        Previous_Temp_Pos = Next_Temp_Pos;
                        Player_Position = Next_Tile;

                        // Use stamina
                        _warrior.stats.stamina -= 10;
                        stamina.Content = "Stamina: " + _warrior.stats.stamina + "/" + _warrior.stats.totalStamina;
                    }
                    else
                    {
                        Previous_Tile = Player_Position;
                    }
                }
                if (_warrior == null && _rogue == null)
                {
                    if (_mage.stats.stamina - 10 >= 0)
                    {
                        Previous_Tile = Player_Position;
                        Next_Tile = Player_Position - 8;

                        Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));

                        Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);
                        Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);
                        Previous_Temp_Pos = Next_Temp_Pos;
                        Player_Position = Next_Tile;

                        // Use stamina
                        _mage.stats.stamina -= 10;
                        stamina.Content = "Stamina: " + _mage.stats.stamina + "/" + _mage.stats.totalStamina;
                    }
                    else
                    {
                        Previous_Tile = Player_Position;
                    }
                }
                if (_warrior == null && _mage == null)
                {
                    if (_rogue.stats.stamina - 10 >= 0)
                    {
                        Previous_Tile = Player_Position;
                        Next_Tile = Player_Position - 8;

                        Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));

                        Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);
                        Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);
                        Previous_Temp_Pos = Next_Temp_Pos;
                        Player_Position = Next_Tile;

                        // Use stamina
                        _rogue.stats.stamina -= 10;
                        stamina.Content = "Stamina: " + _rogue.stats.stamina + "/" + _rogue.stats.totalStamina;
                    }
                    else
                    {
                        Previous_Tile = Player_Position;
                    }
                }

                NewEnemy(sender, e);
            }
        }
        private void Right_Arrow_Click(object sender, RoutedEventArgs e)
        {
            if (Player_Position + 8 <256)
            {
                // Use stamina for every tile move
                if (_mage == null && _rogue == null)
                {
                    if (_warrior.stats.stamina - 10 >= 0)
                    {
                        Previous_Tile = Player_Position;
                        Next_Tile = Player_Position + 8;

                        Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));

                        Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);
                        Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);
                        Previous_Temp_Pos = Next_Temp_Pos;
                        Player_Position = Next_Tile;

                        // Use stamina
                        _warrior.stats.stamina -= 10;
                        stamina.Content = "Stamina: " + _warrior.stats.stamina + "/" + _warrior.stats.totalStamina;
                    }
                    else
                    {
                        Previous_Tile = Player_Position;
                    }
                }
                if (_warrior == null && _rogue == null)
                {
                    if (_mage.stats.stamina - 10 >= 0)
                    {
                        Previous_Tile = Player_Position;
                        Next_Tile = Player_Position + 8;

                        Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));

                        Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);
                        Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);
                        Previous_Temp_Pos = Next_Temp_Pos;
                        Player_Position = Next_Tile;

                        // Use stamina
                        _mage.stats.stamina -= 10;
                        stamina.Content = "Stamina: " + _mage.stats.stamina + "/" + _mage.stats.totalStamina;
                    }
                    else
                    {
                        Previous_Tile = Player_Position;
                    }
                }
                if (_warrior == null && _mage == null)
                {
                    if (_rogue.stats.stamina - 10 >= 0)
                    {
                        Previous_Tile = Player_Position;
                        Next_Tile = Player_Position + 8;

                        Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));

                        Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);
                        Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);
                        Previous_Temp_Pos = Next_Temp_Pos;
                        Player_Position = Next_Tile;

                        // Use stamina
                        _rogue.stats.stamina -= 10;
                        stamina.Content = "Stamina: " + _rogue.stats.stamina + "/" + _rogue.stats.totalStamina;
                    }
                    else
                    {
                        Previous_Tile = Player_Position;
                    }
                }

                NewEnemy(sender, e);
            }
        }
        // Handles enemy appearance in map and combat system
        private void NewEnemy(object sender, RoutedEventArgs e)
        {
            // Enemy has 10% chance of appearing on any tile
            int chance = rand.Next(1, 3);

            // For the Warrior
            if (_mage == null && _rogue == null)
            {
                if (_warrior.info.level < 10 && _warrior.stats.stamina >= 10)
                {
                    if (chance == 1)
                    {
                        rat = new Rat();
                        dialog.Text += "\n" + rat.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                }
                if (_warrior.info.level >= 10)
                {
                    if (chance == 1)
                    {
                        rat = new Rat();
                        dialog.Text += "\n" + rat.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                    if (chance == 2)
                    {
                        goblin = new Goblin();
                        dialog.Text += "\n" + goblin.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                }
                if (_warrior.info.level >= 15)
                {
                    if (chance == 1)
                    {
                        rat = new Rat();
                        dialog.Text += "\n" + rat.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                    if (chance == 2)
                    {
                        goblin = new Goblin();
                        dialog.Text += "\n" + goblin.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                    if (chance == 3)
                    {
                        ogre = new Ogre();
                        dialog.Text += "\n" + ogre.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                }
            }
            // For the Mage
            if (_warrior == null && _rogue == null)
            {
                if (_mage.info.level < 10 && _mage.stats.stamina >= 10)
                {
                    if (chance == 1)
                    {
                        rat = new Rat();
                        dialog.Text += "\n" + rat.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                }
                if (_mage.info.level >= 10)
                {
                    if (chance == 1)
                    {
                        rat = new Rat();
                        dialog.Text += "\n" + rat.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                    if (chance == 2)
                    {
                        goblin = new Goblin();
                        dialog.Text += "\n" + goblin.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                }
                if (_mage.info.level >= 15)
                {
                    if (chance == 1)
                    {
                        rat = new Rat();
                        dialog.Text += "\n" + rat.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                    if (chance == 2)
                    {
                        goblin = new Goblin();
                        dialog.Text += "\n" + goblin.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                    if (chance == 3)
                    {
                        ogre = new Ogre();
                        dialog.Text += "\n" + ogre.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                }
            }
            // For the Rogue
            if (_warrior == null && _mage == null)
            {
                if (_rogue.info.level < 10 && _rogue.stats.stamina >= 10)
                {
                    if (chance == 1)
                    {
                        rat = new Rat();
                        dialog.Text += "\n" + rat.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                }
                if (_rogue.info.level >= 10)
                {
                    if (chance == 1)
                    {
                        rat = new Rat();
                        dialog.Text += "\n" + rat.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                    if (chance == 2)
                    {
                        goblin = new Goblin();
                        dialog.Text += "\n" + goblin.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                }
                if (_rogue.info.level >= 15)
                {
                    if (chance == 1)
                    {
                        rat = new Rat();
                        dialog.Text += "\n" + rat.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                    if (chance == 2)
                    {
                        goblin = new Goblin();
                        dialog.Text += "\n" + goblin.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                    if (chance == 3)
                    {
                        ogre = new Ogre();
                        dialog.Text += "\n" + ogre.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                }
            }

            dialog.ScrollToEnd();
        }
        private void Player_Attack(object sender, RoutedEventArgs e)
        {
            if (goblin == null && ogre == null)
            {
                // For warrior
                if (_mage == null && _rogue == null)
                {
                    double playerDamage = _warrior.DoDamage();

                    dialog.ScrollToEnd();

                    if (rat == null)
                    {
                        dialog.Text += "There is nothing to attack.\n";
                    }
                    else if (rat.stats.health - playerDamage > 0)
                    {
                        ratDamage = rat.DoDamage();

                        dialog.Text += "You did " + playerDamage + " damage.\n";
                        rat.stats.health -= (int)playerDamage;
                        dialog.Text += "Rat: " + rat.stats.health + "/" + rat.stats.totalHealth + " HP\n";
                        dialog.Text += "The rat did " + ratDamage + " damage.\n";
                        _warrior.stats.health -= (int)ratDamage;
                        health.Content = "Health: " + _warrior.stats.health + "/" + _warrior.stats.totalHealth;
                    }
                    else
                    {
                        dialog.Text += rat.DeathMessage();
                        KillRat(sender, e);
                        rat = null;
                    }
                }
                // For mage
                if (_warrior == null && _rogue == null)
                {
                    double playerDamage = _mage.DoDamage();

                    dialog.ScrollToEnd();

                    if (rat == null)
                    {
                        dialog.Text += "There is nothing to attack.\n";
                    }
                    else if (rat.stats.health - playerDamage > 0)
                    {
                        ratDamage = rat.DoDamage();

                        dialog.Text += "You did " + playerDamage + " damage.\n";
                        rat.stats.health -= (int)playerDamage;
                        dialog.Text += "Rat: " + rat.stats.health + "/" + rat.stats.totalHealth + " HP\n";
                        dialog.Text += "The rat did " + ratDamage + " damage.\n";
                        _mage.stats.health -= (int)ratDamage;
                        health.Content = "Health: " + _mage.stats.health + "/" + _mage.stats.totalHealth;
                    }
                    else
                    {
                        dialog.Text += rat.DeathMessage();
                        KillRat(sender, e);
                        rat = null;
                    }
                }
                // For rogue
                if (_warrior == null && _mage == null)
                {
                    double playerDamage = _rogue.DoDamage();

                    dialog.ScrollToEnd();

                    if (rat == null)
                    {
                        dialog.Text += "There is nothing to attack.\n";
                    }
                    else if (rat.stats.health - playerDamage > 0)
                    {
                        ratDamage = rat.DoDamage();

                        dialog.Text += "You did " + playerDamage + " damage.\n";
                        rat.stats.health -= (int)playerDamage;
                        dialog.Text += "Rat: " + rat.stats.health + "/" + rat.stats.totalHealth + " HP\n";
                        dialog.Text += "The rat did " + ratDamage + " damage.\n";
                        _rogue.stats.health -= (int)ratDamage;
                        health.Content = "Health: " + _rogue.stats.health + "/" + _rogue.stats.totalHealth;
                    }
                    else
                    {
                        dialog.Text += rat.DeathMessage();
                        KillRat(sender, e);
                        rat = null;
                    }
                }
            }
        }
        private void Player_Run(object sender, EventArgs e)
        {
            // 25% chance to run away from an enemy
            int chance = rand.Next(1, 4);

            dialog.ScrollToEnd();

            // If there is a rat, you can run from it. If you run away, the rat disappears
            if (goblin == null && ogre == null)
            {
                // For warrior
                if (_mage == null && _rogue == null)
                {
                    if (rat == null)
                    {
                        dialog.Text += "There is nothing to run from.\n";
                    }
                    else if (chance == 1)
                    {
                        dialog.Text += rat.RanMessage();
                        rat = null;
                    }
                    else
                    {
                        dialog.Text += "You can't escape!\n";
                        ratDamage = rat.DoDamage();
                        dialog.Text += "The rat did " + ratDamage + " damage.\n";
                        _warrior.stats.health -= (int)ratDamage;
                        health.Content = "Health: " + _warrior.stats.health + "/" + _warrior.stats.totalHealth;
                    }
                }
                // For mage
                if (_warrior == null && _rogue == null)
                {

                }
                // For rogue
                if (_warrior == null && _mage == null)
                {

                }
            }
        }
        private void Player_Rest(object sender, EventArgs e)
        {
            dialog.ScrollToEnd();

            // For warrior
            if (_mage == null && _rogue == null)
            {
                if (rat != null)
                {
                    dialog.Text += "Now's not the time to rest!\n";
                }
                else if (_warrior.stats.stamina + 10 <= _warrior.stats.totalStamina)
                {
                    dialog.Text += "You regained some stamina by resting.\n";
                    _warrior.stats.stamina += 10;
                    stamina.Content = "Stamina: " + _warrior.stats.stamina + "/" + _warrior.stats.totalStamina;
                }
                else
                {
                    dialog.Text += "Resting now would be a waste of time...\n";
                }
            }
            // For mage
            if (_warrior == null && _rogue == null)
            {
                if (_mage.stats.stamina + 10 <= _mage.stats.totalStamina)
                {
                    dialog.Text += "You regained some stamina by resting.\n";
                    _mage.stats.stamina += 10;
                    stamina.Content = "Stamina: " + _mage.stats.stamina + "/" + _mage.stats.totalStamina;
                }
                else
                {
                    dialog.Text += "Resting now would be a waste of time...\n";
                }
            }
            // For rogue
            if (_warrior == null && _mage == null)
            {
                if (_rogue.stats.stamina + 10 <= _rogue.stats.totalStamina)
                {
                    dialog.Text += "You regained some stamina by resting.\n";
                    _rogue.stats.stamina += 10;
                    stamina.Content = "Stamina: " + _rogue.stats.stamina + "/" + _rogue.stats.totalStamina;
                }
                else
                {
                    dialog.Text += "Resting now would be a waste of time...\n";
                }
            }
        }
    }
}