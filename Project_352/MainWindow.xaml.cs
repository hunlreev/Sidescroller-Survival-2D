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
using System.Threading;

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

            // Check to see if player is a mage
            if (_warrior == null && _rogue == null)
            {
                Flames.IsEnabled = true;
            }

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
                    Player_Color = new SolidColorBrush(Colors.Red);
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
                    Player_Color = new SolidColorBrush(Colors.Purple);
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
                    Player_Color = new SolidColorBrush(Colors.Blue);
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
        // For debugging/testing player level up on exp gain
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
                dialog.Text += "You received " + experience + " exp and " + gold + " gold!\n";
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
                dialog.Text += "You received " + experience + " exp and " + gold + " gold!\n";
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
                dialog.Text += "You received " + experience + " exp and " + gold + " gold!\n";
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
                    int experience = goblin.Exp();
                    int gold = goblin.Gold();
                    _warrior.info.exp += experience;
                    _warrior.info.gold += gold;
                    LevelUp(sender, e);
                    ShowPlayerInfo(sender, e);
                    dialog.Text += "You recieved " + experience + " exp and " + gold + " gold!\n";
                }
            }
            // For the Mage
            if (_warrior == null && _rogue == null)
            {
                if (_mage.info.level >= 10)
                {
                    int experience = goblin.Exp();
                    int gold = goblin.Gold();
                    _mage.info.exp += experience;
                    _mage.info.gold += gold;
                    LevelUp(sender, e);
                    ShowPlayerInfo(sender, e);
                    dialog.Text += "You recieved " + experience + " exp and " + gold + " gold!\n";
                }
            }
            // For the Rogue
            if (_warrior == null && _mage == null)
            {
                if (_rogue.info.level >= 10)
                {
                    int experience = goblin.Exp();
                    int gold = goblin.Gold();
                    _rogue.info.exp += experience;
                    _rogue.info.gold += gold;
                    LevelUp(sender, e);
                    ShowPlayerInfo(sender, e);
                    dialog.Text += "You recieved " + experience + " exp and " + gold + " gold!\n";
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
                    int experience = ogre.Exp();
                    int gold = ogre.Gold();
                    _warrior.info.exp += experience;
                    _warrior.info.gold += gold;
                    LevelUp(sender, e);
                    ShowPlayerInfo(sender, e);
                    dialog.Text += "You recieved " + experience + " exp and " + gold + " gold!\n";
                }
            }
            // For the Mage
            if (_warrior == null && _rogue == null)
            {
                if (_mage.info.level >= 15)
                {
                    int experience = ogre.Exp();
                    int gold = ogre.Gold();
                    _mage.info.exp += experience;
                    _mage.info.gold += gold;
                    LevelUp(sender, e);
                    ShowPlayerInfo(sender, e);
                    dialog.Text += "You recieved " + experience + " exp and " + gold + " gold!\n";
                }
            }
            // For the Rogue
            if (_warrior == null && _mage == null)
            {
                if (_rogue.info.level >= 15)
                {
                    int experience = ogre.Exp();
                    int gold = ogre.Gold();
                    _rogue.info.exp += experience;
                    _rogue.info.gold += gold;
                    LevelUp(sender, e);
                    ShowPlayerInfo(sender, e);
                    dialog.Text += "You recieved " + experience + " exp and " + gold + " gold!\n";
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
        private Dragon dragon; 
        private Bear bear;
        private Kraken kraken;
        private Random rand = new Random();

        private int Player_Position = 39;//Player Map Details
        private int Player_Movement = 0;//Total Movements made by the Player

        private int Previous_Tile;//Variables for movement
        private int Next_Tile;

        private string Previous_Temp_Pos = "🌽";//Temporary Variables for movement
        private string Next_Temp_Pos;

        private string Player_Class;//Variable to monitor Player's Class
        private SolidColorBrush Player_Color;//Variable monitoring player's base color

        private SolidColorBrush Previous_Color = new SolidColorBrush(Colors.Yellow);//Starting color of the spot
        private Color Temp_Color;//To hold place and to convert from string to color
        private SolidColorBrush Next_Color;//Placeholder for the next spot's color. To be placed in previous after movement

        private double ratDamage;
        private double goblinDamage;
        private double ogreDamage;

        private bool Fighting = false;//Variable to monitor if in battle or not

        //Questing Variables
        private bool MetKingFirst = false;// Wake up in the field. Go find the King in the castle to your west. Gives Quest to find the 3 powers of the world
        private bool MetKingSecond = false;// Aquired the 3 powers of the world
        private bool Kraken = false;// Receive the Kraken Egg from the island
        private bool KrakenFight = false;//Fight the Kraken if not go to the island from the south
        private bool BearClaw = false;// Fight the Bears for the royal claw
        private bool Blessing = false;// Receive the Emperor Penguins Blessing
        private bool MeteorPower = false;// After meeting the king the second time with the three powers retrieve the Celestial power of the Meteor to get through the poison to fight the dragon 
        private bool Dragon = false;
        
       


        public void Up_Arrow_Click(object sender, RoutedEventArgs e)
        {
           // dialog.Text += Player_Position; // For Debugging and story lineup
            if (Player_Position % 8 > 0 && Player_Position < 256)
            {
                if (Fighting == false)
                {
                    if (_mage == null && _rogue == null)
                    {
                        if (_warrior.stats.stamina - 10 >= 0)
                        {
                            Previous_Tile = Player_Position;//Calculates movement
                            Next_Tile = Player_Position - 1;

                            Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));//Converts to map value
                            Temp_Color = (Color)ColorConverter.ConvertFromString(Convert.ToString(Map.Children[Next_Tile].GetValue(ForegroundProperty)));//Converts Grid Data to a string then to a color
                            Next_Color = new SolidColorBrush(Temp_Color);//sets the Solidcolorbrush to the next color previously converted


                            Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);//Moves the player
                            Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);//Replaces last tile
                            Map.Children[Next_Tile].SetValue(ForegroundProperty, Player_Color);//Changes color to player
                            Map.Children[Previous_Tile].SetValue(ForegroundProperty, Previous_Color);//Replaces last tile color


                            Previous_Temp_Pos = Next_Temp_Pos;//Sets the new values for next movement
                            Previous_Color = Next_Color;
                            Player_Position = Next_Tile;
                            Player_Movement++;

                            // Use stamina
                            _warrior.stats.stamina -= 10;
                            stamina.Content = "Stamina: " + _warrior.stats.stamina + "/" + _warrior.stats.totalStamina;
                        }
                    }
                    if (_warrior == null && _rogue == null)
                    {
                        if (_mage.stats.stamina - 10 >= 0)
                        {
                            Previous_Tile = Player_Position;//Calculates movement
                            Next_Tile = Player_Position - 1;

                            Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));//Converts to map value
                            Temp_Color = (Color)ColorConverter.ConvertFromString(Convert.ToString(Map.Children[Next_Tile].GetValue(ForegroundProperty)));//Converts Grid Data to a string then to a color
                            Next_Color = new SolidColorBrush(Temp_Color);//sets the Solidcolorbrush to the next color previously converted


                            Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);//Moves the player
                            Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);//Replaces last tile
                            Map.Children[Next_Tile].SetValue(ForegroundProperty, Player_Color);//Changes color to player
                            Map.Children[Previous_Tile].SetValue(ForegroundProperty, Previous_Color);//Replaces last tile color


                            Previous_Temp_Pos = Next_Temp_Pos;//Sets the new values for next movement
                            Previous_Color = Next_Color;
                            Player_Position = Next_Tile;
                            Player_Movement++;

                            // Use stamina
                            _mage.stats.stamina -= 10;
                            stamina.Content = "Stamina: " + _mage.stats.stamina + "/" + _mage.stats.totalStamina;
                        }
                    }
                    if (_warrior == null && _mage == null)
                    {
                        if (_rogue.stats.stamina - 10 >= 0)
                        {
                            Previous_Tile = Player_Position;//Calculates movement
                            Next_Tile = Player_Position - 1;

                            Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));//Converts to map value
                            Temp_Color = (Color)ColorConverter.ConvertFromString(Convert.ToString(Map.Children[Next_Tile].GetValue(ForegroundProperty)));//Converts Grid Data to a string then to a color
                            Next_Color = new SolidColorBrush(Temp_Color);//sets the Solidcolorbrush to the next color previously converted


                            Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);//Moves the player
                            Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);//Replaces last tile
                            Map.Children[Next_Tile].SetValue(ForegroundProperty, Player_Color);//Changes color to player
                            Map.Children[Previous_Tile].SetValue(ForegroundProperty, Previous_Color);//Replaces last tile color


                            Previous_Temp_Pos = Next_Temp_Pos;//Sets the new values for next movement
                            Previous_Color = Next_Color;
                            Player_Position = Next_Tile;
                            Player_Movement++;

                            // Use stamina
                            _rogue.stats.stamina -= 10;
                            stamina.Content = "Stamina: " + _rogue.stats.stamina + "/" + _rogue.stats.totalStamina;
                        }
                    }
                    NewEnemy(sender, e);
                }
            }
            if (Player_Position == 0 && Kraken == false)
            {
                dialog.Text += "You have obtained the Mighty Kraken's Egg!";
                Checkbox1.IsChecked = true;
            }//For Kraken Egg
            if (Player_Position == 8 && KrakenFight == false)
            {

            }//For the Kraken Fight Also in Left Arrow Click
            if (Player_Position == 131 || Player_Position == 132 && BearClaw == false)
            {
                dialog.Text += "Congratulations you defeated the mighty Bear and obtained his claw. The others coward in fear";
                BearClaw = true;
                Checkbox2.IsChecked = true; 
            }//For Bear Claw
            if (Player_Position == 153 && MetKingSecond == true)
            {
                dialog.Text += "*The Gods Smile Down Upon You. You Receive Their Celestial Powers In Order To Slay The Dragon*";
                MeteorPower = true;
                Checkbox4.IsChecked = true;
                Checkbox5.Content = "SLAY THE DRAGON";
                Checkbox5.Opacity = 100;
            }//Gain Celestial powers from the meteor
            if (Player_Position == 233 && MeteorPower == true)//Fight The Dragon
            {
                dialog.Text += "*As you approach the dragon you feel the power of the gods flowing through you*";
            }
        }

        private void Down_Arrow_Click(object sender, RoutedEventArgs e)
        {
           // dialog.Text += Player_Position; // For Debugging and story lineup
            if (Player_Position % 8 + 1 != 8 && Player_Position < 256)
            {
                if (Fighting == false)
                {
                    if (_mage == null && _rogue == null)
                    {
                        if (_warrior.stats.stamina - 10 >= 0)
                        {
                            Previous_Tile = Player_Position;//Calculates movement
                            Next_Tile = Player_Position + 1;

                            Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));//Converts to map value
                            Temp_Color = (Color)ColorConverter.ConvertFromString(Convert.ToString(Map.Children[Next_Tile].GetValue(ForegroundProperty)));//Converts Grid Data to a string then to a color
                            Next_Color = new SolidColorBrush(Temp_Color);//sets the Solidcolorbrush to the next color previously converted


                            Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);//Moves the player
                            Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);//Replaces last tile
                            Map.Children[Next_Tile].SetValue(ForegroundProperty, Player_Color);//Changes color to player
                            Map.Children[Previous_Tile].SetValue(ForegroundProperty, Previous_Color);//Replaces last tile color


                            Previous_Temp_Pos = Next_Temp_Pos;//Sets the new values for next movement
                            Previous_Color = Next_Color;
                            Player_Position = Next_Tile;
                            Player_Movement++;

                            // Use stamina
                            _warrior.stats.stamina -= 10;
                            stamina.Content = "Stamina: " + _warrior.stats.stamina + "/" + _warrior.stats.totalStamina;
                        }
                    }
                    if (_warrior == null && _rogue == null)
                    {
                        if (_mage.stats.stamina - 10 >= 0)
                        {
                            Previous_Tile = Player_Position;//Calculates movement
                            Next_Tile = Player_Position + 1;

                            Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));//Converts to map value
                            Temp_Color = (Color)ColorConverter.ConvertFromString(Convert.ToString(Map.Children[Next_Tile].GetValue(ForegroundProperty)));//Converts Grid Data to a string then to a color
                            Next_Color = new SolidColorBrush(Temp_Color);//sets the Solidcolorbrush to the next color previously converted


                            Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);//Moves the player
                            Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);//Replaces last tile
                            Map.Children[Next_Tile].SetValue(ForegroundProperty, Player_Color);//Changes color to player
                            Map.Children[Previous_Tile].SetValue(ForegroundProperty, Previous_Color);//Replaces last tile color


                            Previous_Temp_Pos = Next_Temp_Pos;//Sets the new values for next movement
                            Previous_Color = Next_Color;
                            Player_Position = Next_Tile;
                            Player_Movement++;

                            // Use stamina
                            _mage.stats.stamina -= 10;
                            stamina.Content = "Stamina: " + _mage.stats.stamina + "/" + _mage.stats.totalStamina;
                        }
                    }
                    if (_warrior == null && _mage == null)
                    {
                        if (_rogue.stats.stamina - 10 >= 0)
                        {
                            Previous_Tile = Player_Position;//Calculates movement
                            Next_Tile = Player_Position + 1;

                            Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));//Converts to map value
                            Temp_Color = (Color)ColorConverter.ConvertFromString(Convert.ToString(Map.Children[Next_Tile].GetValue(ForegroundProperty)));//Converts Grid Data to a string then to a color
                            Next_Color = new SolidColorBrush(Temp_Color);//sets the Solidcolorbrush to the next color previously converted


                            Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);//Moves the player
                            Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);//Replaces last tile
                            Map.Children[Next_Tile].SetValue(ForegroundProperty, Player_Color);//Changes color to player
                            Map.Children[Previous_Tile].SetValue(ForegroundProperty, Previous_Color);//Replaces last tile color


                            Previous_Temp_Pos = Next_Temp_Pos;//Sets the new values for next movement
                            Previous_Color = Next_Color;
                            Player_Position = Next_Tile;
                            Player_Movement++;

                            // Use stamina
                            _rogue.stats.stamina -= 10;
                            stamina.Content = "Stamina: " + _rogue.stats.stamina + "/" + _rogue.stats.totalStamina;
                        }
                    }
                    NewEnemy(sender, e);
                }
            }
            if ( Player_Position == 7)
            {
                if( MetKingFirst == false)
                {
                    dialog.Text += "\nKing: Welcome young traveler, It seems you are not from this world.\n" +
                        "King: Alas, I wish we could greet you better but our world is in grave turmoil.\n" +
                        "King: There be a dragon to the East over the mountains, she is a Fiery Best of Great Magnitude.\n" +
                        "King: If only we had a hero of legends to save us all. \n\nKing: WHAT!\nKing: You will try to be this world's savior?!\n" +
                        "King: Bless your soul, young Adventurer. Go see the court Wizard with how to defeat such a beast, he might know.\n\n\n\n\n" +
                        "Wizard: I see the king wasn't pulling my big toe.\nWizard: You truly are a man of great bravery to be going up against the mighty Fire Breather " +
                        "of the Eastern Mountains.\nWizard: Or you are a complete idiot and will surely die....\n Wizard: Alas, I've been ordered to give you knowledge" +
                        " of how to defeat such a might beast.\nWizard: First you must travel to the north and retrieve the Kraken's Egg. It lies on the island guarded " +
                        "by the tentacruel monster. If you come to the island from the south side you can avoid the monster.\n" +
                        "Wizard: Next retrieve the Might Bear Claw from the caves north east of here. Be Weary those bears are strong." +
                        "Wizard: Finally retrieve the Emperor Penguins' might blessing from the icy mountains of the west." +
                        "Wizard: Now go forth adventurer and try not to die as fast as the others that have come before you";
                    MetKingFirst = true;
                    Checkbox1.Content = "Retrieve the Kraken's Egg";
                    Checkbox1.Opacity = 100;
                    Checkbox2.Content = "Fight the Mighty Bears for one of their Claw's";
                    Checkbox2.Opacity = 100;
                    Checkbox3.Content = "Achieve the Mythical Penguin's Blessing";
                    Checkbox3.Opacity = 100;

                }
                if( Kraken == true && BearClaw == true && Blessing == true)
                {
                    dialog.Text += "\nKing: Welcome back young adventurer...What!" +
                        "\nKing: You received all the items. Go see the court wizard now you great Hero!" +
                        "\nWizard: Welcome back, I have been watching through the mystic pool." +
                        "\nWizard: Since you have received the mystical items, go forth and go to the celestial crater." +
                        "\nWizard: There you shall be blessed by the celestial gods and gain the power to kill the great Dragon.";
                    MetKingSecond = true;
                    Checkbox4.Content = "Obtain the Celestial Power from the Meteor Crater in the desert";
                    Checkbox4.Opacity = 100;
                }
            }//Meeting the king 1 and 2
            if (Player_Position == 131 || Player_Position == 132 && BearClaw == false)
            {
                dialog.Text += "Congratulations you defeated the mighty Bear and obtained his claw. The others coward in fear";
                BearClaw = true;
                Checkbox2.IsChecked = true;
            }//For Bear Claw
            if (Player_Position == 231 && Blessing == false)
            {
                dialog.Text += "\nEmperor Penguin: I have seen you coming from far away young lad. I admire your bravery and resilience in " +
                    "in these trying times.Here is my blessing.";
                Checkbox3.IsChecked = true;
                Blessing = true;
            }//For Penguin Blessing


        }

        private void Left_Arrow_Click(object sender, RoutedEventArgs e)
        {
            //dialog.Text += Player_Position; // For Debugging and story lineup
            if (Player_Position-8 > -1)
            {
                if (Fighting == false)
                {
                    if (_mage == null && _rogue == null)
                    {
                        if (_warrior.stats.stamina - 10 >= 0)
                        {
                            Previous_Tile = Player_Position;//Calculates movement
                            Next_Tile = Player_Position - 8;

                            Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));//Converts to map value
                            Temp_Color = (Color)ColorConverter.ConvertFromString(Convert.ToString(Map.Children[Next_Tile].GetValue(ForegroundProperty)));//Converts Grid Data to a string then to a color
                            Next_Color = new SolidColorBrush(Temp_Color);//sets the Solidcolorbrush to the next color previously converted


                            Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);//Moves the player
                            Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);//Replaces last tile
                            Map.Children[Next_Tile].SetValue(ForegroundProperty, Player_Color);//Changes color to player
                            Map.Children[Previous_Tile].SetValue(ForegroundProperty, Previous_Color);//Replaces last tile color


                            Previous_Temp_Pos = Next_Temp_Pos;//Sets the new values for next movement
                            Previous_Color = Next_Color;
                            Player_Position = Next_Tile;
                            Player_Movement++;

                            // Use stamina
                            _warrior.stats.stamina -= 10;
                            stamina.Content = "Stamina: " + _warrior.stats.stamina + "/" + _warrior.stats.totalStamina;
                        }
                    }
                    if (_warrior == null && _rogue == null)
                    {
                        if (_mage.stats.stamina - 10 >= 0)
                        {
                            Previous_Tile = Player_Position;//Calculates movement
                            Next_Tile = Player_Position - 8;

                            Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));//Converts to map value
                            Temp_Color = (Color)ColorConverter.ConvertFromString(Convert.ToString(Map.Children[Next_Tile].GetValue(ForegroundProperty)));//Converts Grid Data to a string then to a color
                            Next_Color = new SolidColorBrush(Temp_Color);//sets the Solidcolorbrush to the next color previously converted


                            Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);//Moves the player
                            Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);//Replaces last tile
                            Map.Children[Next_Tile].SetValue(ForegroundProperty, Player_Color);//Changes color to player
                            Map.Children[Previous_Tile].SetValue(ForegroundProperty, Previous_Color);//Replaces last tile color


                            Previous_Temp_Pos = Next_Temp_Pos;//Sets the new values for next movement
                            Previous_Color = Next_Color;
                            Player_Position = Next_Tile;
                            Player_Movement++;

                            // Use stamina
                            _mage.stats.stamina -= 10;
                            stamina.Content = "Stamina: " + _mage.stats.stamina + "/" + _mage.stats.totalStamina;
                        }
                    }
                    if (_warrior == null && _mage == null)
                    {
                        if (_rogue.stats.stamina - 10 >= 0)
                        {
                            Previous_Tile = Player_Position;//Calculates movement
                            Next_Tile = Player_Position - 8;

                            Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));//Converts to map value
                            Temp_Color = (Color)ColorConverter.ConvertFromString(Convert.ToString(Map.Children[Next_Tile].GetValue(ForegroundProperty)));//Converts Grid Data to a string then to a color
                            Next_Color = new SolidColorBrush(Temp_Color);//sets the Solidcolorbrush to the next color previously converted


                            Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);//Moves the player
                            Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);//Replaces last tile
                            Map.Children[Next_Tile].SetValue(ForegroundProperty, Player_Color);//Changes color to player
                            Map.Children[Previous_Tile].SetValue(ForegroundProperty, Previous_Color);//Replaces last tile color


                            Previous_Temp_Pos = Next_Temp_Pos;//Sets the new values for next movement
                            Previous_Color = Next_Color;
                            Player_Position = Next_Tile;
                            Player_Movement++;

                            // Use stamina
                            _rogue.stats.stamina -= 10;
                            stamina.Content = "Stamina: " + _rogue.stats.stamina + "/" + _rogue.stats.totalStamina;
                        }
                    }
                    NewEnemy(sender, e);
                }
            }
            if (Player_Position == 7)
            {
                if (MetKingFirst == false)
                {
                    dialog.Text += "\nKing: Welcome young traveler, It seems you are not from this world.\n" +
                        "King: Alas, I wish we could greet you better but our world is in grave turmoil.\n" +
                        "King: There be a dragon to the East over the mountains, she is a Fiery Best of Great Magnitude.\n" +
                        "King: If only we had a hero of legends to save us all. \n\nKing: WHAT!\nKing: You will try to be this world's savior?!\n" +
                        "King: Bless your soul, young Adventurer. Go see the court Wizard with how to defeat such a beast, he might know.\n\n\n\n\n" +
                        "Wizard: I see the king wasn't pulling my big toe.\nWizard: You truly are a man of great bravery to be going up against the mighty Fire Breather " +
                        "of the Eastern Mountains.\nWizard: Or you are a complete idiot and will surely die....\n Wizard: Alas, I've been ordered to give you knowledge" +
                        " of how to defeat such a might beast.\nWizard: First you must travel to the north and retrieve the Kraken's Egg. It lies on the island guarded " +
                        "by the tentacruel monster. If you come to the island from the south side you can avoid the monster.\n" +
                        "Wizard: Next retrieve the Might Bear Claw from the caves north east of here. Be Weary those bears are strong." +
                        "Wizard: Finally retrieve the Emperor Penguins' might blessing from the icy mountains of the west." +
                        "Wizard: Now go forth adventurer and try not to die as fast as the others that have come before you";
                    MetKingFirst = true;
                    Checkbox1.Content = "Retrieve the Kraken's Egg";
                    Checkbox1.Opacity = 100;
                    Checkbox2.Content = "Fight the Mighty Bears for one of their Claw's";
                    Checkbox2.Opacity = 100;
                    Checkbox3.Content = "Achieve the Mythical Penguin's Blessing";
                    Checkbox3.Opacity = 100;

                }
                if (Kraken == true && BearClaw == true && Blessing == true)
                {
                    dialog.Text += "\nKing: Welcome back young adventurer...What!" +
                        "\nKing: You received all the items. Go see the court wizard now you great Hero!" +
                        "\nWizard: Welcome back, I have been watching through the mystic pool." +
                        "\nWizard: Since you have received the mystical items, go forth and go to the celestial crater." +
                        "\nWizard: There you shall be blessed by the celestial gods and gain the power to kill the great Dragon.";
                    MetKingSecond = true;
                    Checkbox4.Content = "Obtain the Celestial Power from the Meteor Crater in the desert";
                    Checkbox4.Opacity = 100;
                }
            }//Meeting the king 1 and 2
            if (Player_Position == 0 && Kraken == false)
            {
                dialog.Text += "You have obtained the Mighty Kraken's Egg!";
                Checkbox1.IsChecked = true;
            }//For Kraken Egg
            if (Player_Position == 8 && KrakenFight == false)
            {

            }//For the Kraken Fight Also in Left Arrow Click
            if (Player_Position == 131 || Player_Position == 132 && BearClaw == false)
            {
                dialog.Text += "Congratulations you defeated the mighty Bear and obtained his claw. The others coward in fear";
                BearClaw = true;
                Checkbox2.IsChecked = true;
            }//For Bear Claw
            if (Player_Position == 231 && Blessing == false)
            {
                dialog.Text += "\nEmperor Penguin: I have seen you coming from far away young lad. I admire your bravery and resilience in " +
                    "in these trying times.Here is my blessing.";
                Checkbox3.IsChecked = true;
                Blessing = true;
            }//For Penguin Blessing
            if (Player_Position == 153 && MetKingSecond == true)
            {
                dialog.Text += "*The Gods Smile Down Upon You. You Receive Their Celestial Powers In Order To Slay The Dragon*";
                MeteorPower = true;
                Checkbox4.IsChecked = true;
                Checkbox5.Content = "SLAY THE DRAGON";
                Checkbox5.Opacity = 100;
            }//Gain Celestial powers from the meteor
        }

        private void Right_Arrow_Click(object sender, RoutedEventArgs e)
        {
            //dialog.Text += Player_Position; // For Debugging and story lineup
            if (Player_Position + 8 <256)
            {
                if (Fighting == false)
                {
                    if (_mage == null && _rogue == null)
                    {
                        if (_warrior.stats.stamina - 10 >= 0)
                        {
                            Previous_Tile = Player_Position;//Calculates movement
                            Next_Tile = Player_Position + 8;

                            Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));//Converts to map value
                            Temp_Color = (Color)ColorConverter.ConvertFromString(Convert.ToString(Map.Children[Next_Tile].GetValue(ForegroundProperty)));//Converts Grid Data to a string then to a color
                            Next_Color = new SolidColorBrush(Temp_Color);//sets the Solidcolorbrush to the next color previously converted


                            Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);//Moves the player
                            Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);//Replaces last tile
                            Map.Children[Next_Tile].SetValue(ForegroundProperty, Player_Color);//Changes color to player
                            Map.Children[Previous_Tile].SetValue(ForegroundProperty, Previous_Color);//Replaces last tile color


                            Previous_Temp_Pos = Next_Temp_Pos;//Sets the new values for next movement
                            Previous_Color = Next_Color;
                            Player_Position = Next_Tile;
                            Player_Movement++;

                            // Use stamina
                            _warrior.stats.stamina -= 10;
                            stamina.Content = "Stamina: " + _warrior.stats.stamina + "/" + _warrior.stats.totalStamina;
                        }
                    }
                    if (_warrior == null && _rogue == null)
                    {
                        if (_mage.stats.stamina - 10 >= 0)
                        {
                            Previous_Tile = Player_Position;//Calculates movement
                            Next_Tile = Player_Position + 8;

                            Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));//Converts to map value
                            Temp_Color = (Color)ColorConverter.ConvertFromString(Convert.ToString(Map.Children[Next_Tile].GetValue(ForegroundProperty)));//Converts Grid Data to a string then to a color
                            Next_Color = new SolidColorBrush(Temp_Color);//sets the Solidcolorbrush to the next color previously converted


                            Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);//Moves the player
                            Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);//Replaces last tile
                            Map.Children[Next_Tile].SetValue(ForegroundProperty, Player_Color);//Changes color to player
                            Map.Children[Previous_Tile].SetValue(ForegroundProperty, Previous_Color);//Replaces last tile color


                            Previous_Temp_Pos = Next_Temp_Pos;//Sets the new values for next movement
                            Previous_Color = Next_Color;
                            Player_Position = Next_Tile;
                            Player_Movement++;

                            // Use stamina
                            _mage.stats.stamina -= 10;
                            stamina.Content = "Stamina: " + _mage.stats.stamina + "/" + _mage.stats.totalStamina;
                        }
                    }
                    if (_warrior == null && _mage == null)
                    {
                        if (_rogue.stats.stamina - 10 >= 0)
                        {
                            Previous_Tile = Player_Position;//Calculates movement
                            Next_Tile = Player_Position + 8;

                            Next_Temp_Pos = Convert.ToString(Map.Children[Next_Tile].GetValue(ContentProperty));//Converts to map value
                            Temp_Color = (Color)ColorConverter.ConvertFromString(Convert.ToString(Map.Children[Next_Tile].GetValue(ForegroundProperty)));//Converts Grid Data to a string then to a color
                            Next_Color = new SolidColorBrush(Temp_Color);//sets the Solidcolorbrush to the next color previously converted


                            Map.Children[Next_Tile].SetValue(ContentProperty, Player_Class);//Moves the player
                            Map.Children[Previous_Tile].SetValue(ContentProperty, Previous_Temp_Pos);//Replaces last tile
                            Map.Children[Next_Tile].SetValue(ForegroundProperty, Player_Color);//Changes color to player
                            Map.Children[Previous_Tile].SetValue(ForegroundProperty, Previous_Color);//Replaces last tile color


                            Previous_Temp_Pos = Next_Temp_Pos;//Sets the new values for next movement
                            Previous_Color = Next_Color;
                            Player_Position = Next_Tile;
                            Player_Movement++;

                            // Use stamina
                            _rogue.stats.stamina -= 10;
                            stamina.Content = "Stamina: " + _rogue.stats.stamina + "/" + _rogue.stats.totalStamina;
                        }
                    }
                    NewEnemy(sender, e);
                }
            }
            if (Player_Position == 131 || Player_Position == 132 && BearClaw == false)
            {
                dialog.Text += "Congratulations you defeated the mighty Bear and obtained his claw. The others coward in fear";
                BearClaw = true;
                Checkbox2.IsChecked = true;
            }//For Bear Claw
            if ( Player_Position == 231 && Blessing == false)
            {
                dialog.Text += "\nEmperor Penguin: I have seen you coming from far away young lad. I admire your bravery and resilience in " +
                    "in these trying times.Here is my blessing.";
                Checkbox3.IsChecked = true;
                Blessing = true;
            }//For Penguin Blessing
            if (Player_Position == 153 && MetKingSecond == true)
            {
                dialog.Text += "*The Gods Smile Down Upon You. You Receive Their Celestial Powers In Order To Slay The Dragon*";
                MeteorPower = true;
                Checkbox4.IsChecked = true;
                Checkbox5.Content = "SLAY THE DRAGON";
                Checkbox5.Opacity = 100;
            }//Gain Celestial powers from the meteor
        }

        private void NewEnemy(object sender, RoutedEventArgs e)
        {
            // Enemy has 25% chance of appearing on any tile
            int chance = rand.Next(1, 4);

            // For the Warrior
            if (_mage == null && _rogue == null)
            {
                if (_warrior.info.level < 10 && _warrior.stats.stamina >= 10)
                {
                    if (chance == 1)
                    {
                        rat = new Rat();
                        Fighting = true;
                        dialog.Text += "\n" + rat.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                }
                if (_warrior.info.level >= 10 && _warrior.info.level < 15)
                {
                    if (chance == 1)
                    {
                        rat = new Rat();
                        Fighting = true;
                        dialog.Text += "\n" + rat.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                    if (chance == 2)
                    {
                        goblin = new Goblin();
                        Fighting = true;
                        dialog.Text += "\n" + goblin.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                }
                if (_warrior.info.level >= 15)
                {
                    if (chance == 1)
                    {
                        rat = new Rat();
                        Fighting = true;
                        dialog.Text += "\n" + rat.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                    if (chance == 2)
                    {
                        goblin = new Goblin();
                        Fighting = true;
                        dialog.Text += "\n" + goblin.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                    if (chance == 3)
                    {
                        ogre = new Ogre();
                        Fighting = true;
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
                        Fighting = true;
                        dialog.Text += "\n" + rat.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                }
                if (_mage.info.level >= 10 && _mage.info.level < 15)
                {
                    if (chance == 1)
                    {
                        rat = new Rat();
                        Fighting = true;
                        dialog.Text += "\n" + rat.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                    if (chance == 2)
                    {
                        goblin = new Goblin();
                        Fighting = true;
                        dialog.Text += "\n" + goblin.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                }
                if (_mage.info.level >= 15)
                {
                    if (chance == 1)
                    {
                        rat = new Rat();
                        Fighting = true;
                        dialog.Text += "\n" + rat.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                    if (chance == 2)
                    {
                        goblin = new Goblin();
                        Fighting = true;
                        dialog.Text += "\n" + goblin.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                    if (chance == 3)
                    {
                        ogre = new Ogre();
                        Fighting = true;
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
                        Fighting = true;
                        dialog.Text += "\n" + rat.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                }
                if (_rogue.info.level >= 10 && _rogue.info.level < 15)
                {
                    if (chance == 1)
                    {
                        rat = new Rat();
                        Fighting = true;
                        dialog.Text += "\n" + rat.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                    if (chance == 2)
                    {
                        goblin = new Goblin();
                        Fighting = true;
                        dialog.Text += "\n" + goblin.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                }
                if (_rogue.info.level >= 15)
                {
                    if (chance == 1)
                    {
                        rat = new Rat();
                        Fighting = true;
                        dialog.Text += "\n" + rat.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                    if (chance == 2)
                    {
                        goblin = new Goblin();
                        Fighting = true;
                        dialog.Text += "\n" + goblin.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                    if (chance == 3)
                    {
                        ogre = new Ogre();
                        Fighting = true;
                        dialog.Text += "\n" + ogre.AppearedMessage();
                        dialog.Text += "What would you like to do?\nAttack or Run\n\n";
                    }
                }
            }

            dialog.ScrollToEnd();
        }

        // Handles player attack depending on class and enemy that appears
        private void Player_Attack(object sender, RoutedEventArgs e)
        {
            if (rat == null && goblin == null && ogre == null)
            {
                dialog.Text += "There is nothing to attack.\n";
            }
            // For a rat
            else if (goblin == null && ogre == null)
            {
                // For warrior
                if (_mage == null && _rogue == null)
                {
                    double playerDamage = _warrior.DoDamage();

                    dialog.ScrollToEnd();

                    if (goblin == null && ogre == null)
                    {
                        if (rat.stats.health - playerDamage > 0)
                        {
                            ratDamage = rat.DoDamage();

                            dialog.Text += "You did " + playerDamage + " damage.\n";
                            rat.stats.health -= (int)playerDamage;
                            dialog.Text += "Rat: " + rat.stats.health + "/" + rat.stats.totalHealth + " HP\n";
                            dialog.Text += "The rat did " + ratDamage + " damage.\n";
                            _warrior.stats.health -= (int)ratDamage;

                            // Handles player death
                            if (_warrior.stats.health <= 0)
                            {
                                Close();
                            }

                            health.Content = "Health: " + _warrior.stats.health + "/" + _warrior.stats.totalHealth;
                        }
                        else
                        {
                            dialog.Text += rat.DeathMessage();
                            KillRat(sender, e);
                            Fighting = false;
                            rat = null;
                        }
                    }
                }
                // For mage
                if (_warrior == null && _rogue == null)
                {
                    double playerDamage = _mage.DoDamage();

                    dialog.ScrollToEnd();

                    if (goblin == null && ogre == null)
                    {
                        if (rat.stats.health - playerDamage > 0)
                        {
                            ratDamage = rat.DoDamage();

                            dialog.Text += "You did " + playerDamage + " damage.\n";
                            rat.stats.health -= (int)playerDamage;
                            dialog.Text += "Rat: " + rat.stats.health + "/" + rat.stats.totalHealth + " HP\n";
                            dialog.Text += "The rat did " + ratDamage + " damage.\n";
                            _mage.stats.health -= (int)ratDamage;

                            // Handles player death
                            if (_mage.stats.health <= 0)
                            {
                                Close();
                            }

                            health.Content = "Health: " + _mage.stats.health + "/" + _mage.stats.totalHealth;
                        }
                        else
                        {
                            dialog.Text += rat.DeathMessage();
                            KillRat(sender, e);
                            Fighting = false;
                            rat = null;
                        }
                    }
                }
                // For rogue
                if (_warrior == null && _mage == null)
                {
                    double playerDamage = _rogue.DoDamage();

                    dialog.ScrollToEnd();

                    if (goblin == null && ogre == null)
                    {
                        if (rat.stats.health - playerDamage > 0)
                        {
                            ratDamage = rat.DoDamage();

                            dialog.Text += "You did " + playerDamage + " damage.\n";
                            rat.stats.health -= (int)playerDamage;
                            dialog.Text += "Rat: " + rat.stats.health + "/" + rat.stats.totalHealth + " HP\n";
                            dialog.Text += "The rat did " + ratDamage + " damage.\n";
                            _rogue.stats.health -= (int)ratDamage;

                            // Handles player death
                            if (_rogue.stats.health <= 0)
                            {
                                Close();
                            }

                            health.Content = "Health: " + _rogue.stats.health + "/" + _rogue.stats.totalHealth;
                        }
                        else
                        {
                            dialog.Text += rat.DeathMessage();
                            KillRat(sender, e);
                            Fighting = false;
                            rat = null;
                        }
                    }
                }
            }
            // For a goblin
            else if (rat == null && ogre == null)
            {
                // For warrior
                if (_mage == null && _rogue == null)
                {
                    double playerDamage = _warrior.DoDamage();

                    dialog.ScrollToEnd();

                    if (rat == null && ogre == null)
                    {
                        if (goblin.stats.health - playerDamage > 0)
                        {
                            goblinDamage = goblin.DoDamage();

                            dialog.Text += "You did " + playerDamage + " damage.\n";
                            goblin.stats.health -= (int)playerDamage;
                            dialog.Text += "Goblin: " + goblin.stats.health + "/" + goblin.stats.totalHealth + " HP\n";
                            dialog.Text += "The goblin did " + goblinDamage + " damage.\n";
                            _warrior.stats.health -= (int)goblinDamage;

                            // Handles player death
                            if (_warrior.stats.health <= 0)
                            {
                                Close();
                            }

                            health.Content = "Health: " + _warrior.stats.health + "/" + _warrior.stats.totalHealth;
                        }
                        else
                        {
                            dialog.Text += goblin.DeathMessage();
                            KillGoblin(sender, e);
                            Fighting = false;
                            goblin = null;
                        }
                    }
                }
                // For mage
                if (_warrior == null && _rogue == null)
                {
                    double playerDamage = _mage.DoDamage();

                    dialog.ScrollToEnd();

                    if (rat == null && ogre == null)
                    {
                        if (goblin.stats.health - playerDamage > 0)
                        {
                            goblinDamage = goblin.DoDamage();

                            dialog.Text += "You did " + playerDamage + " damage.\n";
                            goblin.stats.health -= (int)playerDamage;
                            dialog.Text += "Goblin: " + goblin.stats.health + "/" + goblin.stats.totalHealth + " HP\n";
                            dialog.Text += "The goblin did " + goblinDamage + " damage.\n";
                            _mage.stats.health -= (int)goblinDamage;

                            // Handles player death
                            if (_mage.stats.health <= 0)
                            {
                                Close();
                            }

                            health.Content = "Health: " + _mage.stats.health + "/" + _mage.stats.totalHealth;
                        }
                        else
                        {
                            dialog.Text += goblin.DeathMessage();
                            KillGoblin(sender, e);
                            Fighting = false;
                            goblin = null;
                        }
                    }
                }
                // For rogue
                if (_warrior == null && _mage == null)
                {
                    double playerDamage = _rogue.DoDamage();

                    dialog.ScrollToEnd();

                    if (rat == null && ogre == null)
                    {
                        if (goblin.stats.health - playerDamage > 0)
                        {
                            goblinDamage = goblin.DoDamage();

                            dialog.Text += "You did " + playerDamage + " damage.\n";
                            goblin.stats.health -= (int)playerDamage;
                            dialog.Text += "Goblin: " + goblin.stats.health + "/" + goblin.stats.totalHealth + " HP\n";
                            dialog.Text += "The goblin did " + goblinDamage + " damage.\n";
                            _rogue.stats.health -= (int)goblinDamage;

                            // Handles player death
                            if (_rogue.stats.health <= 0)
                            {
                                Close();
                            }

                            health.Content = "Health: " + _rogue.stats.health + "/" + _rogue.stats.totalHealth;
                        }
                        else
                        {
                            dialog.Text += goblin.DeathMessage();
                            KillGoblin(sender, e);
                            Fighting = false;
                            goblin = null;
                        }
                    }
                }
            }
            // For a ogre
            else if (rat == null && goblin == null)
            {
                // For warrior
                if (_mage == null && _rogue == null)
                {
                    double playerDamage = _warrior.DoDamage();

                    dialog.ScrollToEnd();

                    if (ogre.stats.health - playerDamage > 0)
                    {
                        ogreDamage = ogre.DoDamage();

                        dialog.Text += "You did " + playerDamage + " damage.\n";
                        ogre.stats.health -= (int)playerDamage;
                        dialog.Text += "Ogre: " + ogre.stats.health + "/" + ogre.stats.totalHealth + " HP\n";
                        dialog.Text += "The ogre did " + ogreDamage + " damage.\n";
                        _warrior.stats.health -= (int)ogreDamage;

                        // Handles player death
                        if (_warrior.stats.health <= 0)
                        {
                            Close();
                        }

                        health.Content = "Health: " + _warrior.stats.health + "/" + _warrior.stats.totalHealth;
                    }
                    else
                    {
                        dialog.Text += ogre.DeathMessage();
                        KillOgre(sender, e);
                        Fighting = false;
                        ogre = null;
                    }
                }
                // For mage
                if (_warrior == null && _rogue == null)
                {
                    double playerDamage = _mage.DoDamage();

                    dialog.ScrollToEnd();

                    if (ogre.stats.health - playerDamage > 0)
                    {
                        ogreDamage = ogre.DoDamage();

                        dialog.Text += "You did " + playerDamage + " damage.\n";
                        ogre.stats.health -= (int)playerDamage;
                        dialog.Text += "Ogre: " + ogre.stats.health + "/" + ogre.stats.totalHealth + " HP\n";
                        dialog.Text += "The ogre did " + ogreDamage + " damage.\n";
                        _mage.stats.health -= (int)ogreDamage;

                        // Handles player death
                        if (_mage.stats.health <= 0)
                        {
                            Close();
                        }

                        health.Content = "Health: " + _mage.stats.health + "/" + _mage.stats.totalHealth;
                    }
                    else
                    {
                        dialog.Text += ogre.DeathMessage();
                        KillOgre(sender, e);
                        Fighting = false;
                        ogre = null;
                    }
                }
                // For rogue
                if (_warrior == null && _mage == null)
                {
                    double playerDamage = _rogue.DoDamage();

                    dialog.ScrollToEnd();

                    if (ogre.stats.health - playerDamage > 0)
                    {
                        ogreDamage = ogre.DoDamage();

                        dialog.Text += "You did " + playerDamage + " damage.\n";
                        ogre.stats.health -= (int)playerDamage;
                        dialog.Text += "Ogre: " + ogre.stats.health + "/" + ogre.stats.totalHealth + " HP\n";
                        dialog.Text += "The ogre did " + ogreDamage + " damage.\n";
                        _rogue.stats.health -= (int)ogreDamage;

                        // Handles player death
                        if (_rogue.stats.health <= 0)
                        {
                            Close();
                        }

                        health.Content = "Health: " + _rogue.stats.health + "/" + _rogue.stats.totalHealth;
                    }
                    else
                    {
                        dialog.Text += ogre.DeathMessage();
                        KillOgre(sender, e);
                        Fighting = false;
                        ogre = null;
                    }
                }
            }
        }

        // Allows player to run from enemy
        private void Player_Run(object sender, EventArgs e)
        {
            // 25% chance to run away from an enemy
            int chance = rand.Next(1, 4);

            dialog.ScrollToEnd();

            if (rat == null && goblin == null && ogre == null)
            {
                dialog.Text += "There is nothing to run from.\n";
            }
            // For a rat appearing
            else if (goblin == null && ogre == null)
            {
                // For warrior
                if (_mage == null && _rogue == null)
                {
                    if (chance == 1)
                    {
                        dialog.Text += "You successfully ran away from the rat!\n";
                        rat = null;
                        Fighting = false;
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
                    if (chance == 2)
                    {
                        dialog.Text += "You successfully ran away from the rat!\n";
                        rat = null;
                        Fighting = false;
                    }
                    else
                    {
                        dialog.Text += "You can't escape!\n";
                        ratDamage = rat.DoDamage();
                        dialog.Text += "The rat did " + ratDamage + " damage.\n";
                        _mage.stats.health -= (int)ratDamage;
                        health.Content = "Health: " + _mage.stats.health + "/" + _mage.stats.totalHealth;
                    }
                }
                // For rogue
                if (_warrior == null && _mage == null)
                {
                    if (chance == 3)
                    {
                        dialog.Text += "You successfully ran away from the rat!\n";
                        rat = null;
                        Fighting = false;
                    }
                    else
                    {
                        dialog.Text += "You can't escape!\n";
                        ratDamage = rat.DoDamage();
                        dialog.Text += "The rat did " + ratDamage + " damage.\n";
                        _rogue.stats.health -= (int)ratDamage;
                        health.Content = "Health: " + _rogue.stats.health + "/" + _rogue.stats.totalHealth;
                    }
                }
            }
            // For a goblin appearing
            else if (rat == null && ogre == null)
            {
                // For warrior
                if (_mage == null && _rogue == null)
                {
                    if (chance == 1)
                    {
                        dialog.Text += "You successfully ran away from the goblin!\n";
                        goblin = null;
                        Fighting = false;
                    }
                    else
                    {
                        dialog.Text += "You can't escape!\n";
                        goblinDamage = goblin.DoDamage();
                        dialog.Text += "The goblin did " + goblinDamage + " damage.\n";
                        _warrior.stats.health -= (int)goblinDamage;
                        health.Content = "Health: " + _warrior.stats.health + "/" + _warrior.stats.totalHealth;
                    }
                }
                // For mage
                if (_warrior == null && _rogue == null)
                {
                    if (chance == 2)
                    {
                        dialog.Text += "You successfully ran away from the goblin!\n";
                        goblin = null;
                        Fighting = false;
                    }
                    else
                    {
                        dialog.Text += "You can't escape!\n";
                        goblinDamage = goblin.DoDamage();
                        dialog.Text += "The goblin did " + goblinDamage + " damage.\n";
                        _mage.stats.health -= (int)goblinDamage;
                        health.Content = "Health: " + _mage.stats.health + "/" + _mage.stats.totalHealth;
                    }
                }
                // For rogue
                if (_warrior == null && _mage == null)
                {
                    if (chance == 3)
                    {
                        dialog.Text += "You successfully ran away from the goblin!\n";
                        goblin = null;
                        Fighting = false;
                    }
                    else
                    {
                        dialog.Text += "You can't escape!\n";
                        goblinDamage = goblin.DoDamage();
                        dialog.Text += "The goblin did " + goblinDamage + " damage.\n";
                        _rogue.stats.health -= (int)goblinDamage;
                        health.Content = "Health: " + _rogue.stats.health + "/" + _rogue.stats.totalHealth;
                    }
                }
            }
            // For a ogre appearing
            else if (rat == null && goblin == null)
            {
                // For warrior
                if (_mage == null && _rogue == null)
                {
                    if (chance == 1)
                    {
                        dialog.Text += "You successfully ran away from the ogre!\n";
                        ogre = null;
                        Fighting = false;
                    }
                    else
                    {
                        dialog.Text += "You can't escape!\n";
                        ogreDamage = ogre.DoDamage();
                        dialog.Text += "The ogre did " + ogreDamage + " damage.\n";
                        _warrior.stats.health -= (int)ogreDamage;
                        health.Content = "Health: " + _warrior.stats.health + "/" + _warrior.stats.totalHealth;
                    }
                }
                // For mage
                if (_warrior == null && _rogue == null)
                {
                    if (chance == 2)
                    {
                        dialog.Text += "You successfully ran away from the ogre!\n";
                        ogre = null;
                        Fighting = false;
                    }
                    else
                    {
                        dialog.Text += "You can't escape!\n";
                        ogreDamage = ogre.DoDamage();
                        dialog.Text += "The ogre did " + ogreDamage + " damage.\n";
                        _mage.stats.health -= (int)ogreDamage;
                        health.Content = "Health: " + _mage.stats.health + "/" + _mage.stats.totalHealth;
                    }
                }
                // For rogue
                if (_warrior == null && _mage == null)
                {
                    if (chance == 3)
                    {
                        dialog.Text += "You successfully ran away from the ogre!\n";
                        ogre = null;
                        Fighting = false;
                    }
                    else
                    {
                        dialog.Text += "You can't escape!\n";
                        ogreDamage = ogre.DoDamage();
                        dialog.Text += "The ogre did " + ogreDamage + " damage.\n";
                        _rogue.stats.health -= (int)ogreDamage;
                        health.Content = "Health: " + _rogue.stats.health + "/" + _rogue.stats.totalHealth;
                    }
                }
            }
        }

        // Allows player to rest and restore stamina
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

        // Spells for the Player the use
        private void Player_Heal(object sender, EventArgs e)
        {
            dialog.ScrollToEnd();

            if (_mage == null && _rogue == null)
            {
                if (_warrior.stats.mana - 10 > 0 && _warrior.stats.health < _warrior.stats.totalHealth - 10)
                {
                    dialog.Text += "You casted the heal spell.\n";
                    dialog.Text += "Replenished 10 HP!\n";
                    _warrior.stats.health += 10;
                    _warrior.stats.mana -= 10;
                    health.Content = "Health: " + _warrior.stats.health + "/" + _warrior.stats.totalHealth;
                    mana.Content = "Mana: " + _warrior.stats.mana + "/" + _warrior.stats.totalMana;
                }
                else
                {
                    dialog.Text += "Failed to cast heal.\n";
                }
            }
            if (_warrior == null && _rogue == null)
            {
                if (_mage.stats.mana - 10 > 0 && _mage.stats.health < _mage.stats.totalHealth - 10)
                {
                    dialog.Text += "You casted the heal spell.\n";
                    dialog.Text += "Replenished 10 HP!\n";
                    _mage.stats.health += 10;
                    _mage.stats.mana -= 10;
                    health.Content = "Health: " + _mage.stats.health + "/" + _mage.stats.totalHealth;
                    mana.Content = "Mana: " + _mage.stats.mana + "/" + _mage.stats.totalMana;
                }
                else
                {
                    dialog.Text += "Failed to cast heal.\n";
                }
            }
            if (_warrior == null && _mage == null)
            {
                if (_rogue.stats.mana - 10 > 0 && _rogue.stats.health < _rogue.stats.totalHealth - 10)
                {
                    dialog.Text += "You casted the heal spell.\n";
                    dialog.Text += "Replenished 10 HP!\n";
                    _rogue.stats.health += 10;
                    _rogue.stats.mana -= 10;
                    health.Content = "Health: " + _rogue.stats.health + "/" + _rogue.stats.totalHealth;
                    mana.Content = "Mana: " + _rogue.stats.mana + "/" + _rogue.stats.totalMana;
                }
                else
                {
                    dialog.Text += "Failed to cast heal.\n";
                }
            }
        }

        // Only available for the mage class
        private void Player_Flames(object sender, EventArgs e)
        {
            dialog.ScrollToEnd();

            if (rat == null && goblin == null && ogre == null)
            {
                dialog.Text += "There is nothing to attack.\n";
            }
            // For rat
            else if (goblin == null && ogre == null)
            {
                if (_warrior == null && _rogue == null)
                {
                    if (_mage.stats.mana - 10 > 0)
                    {
                        double playerDamage = _mage.Flames();

                        if (rat.stats.health - playerDamage > 0)
                        {
                            ratDamage = rat.DoDamage();

                            _mage.stats.mana -= 10;
                            dialog.Text += "Flames did " + playerDamage + " damage.\n";
                            rat.stats.health -= (int)playerDamage;
                            dialog.Text += "Rat: " + rat.stats.health + "/" + rat.stats.totalHealth + " HP\n";
                            dialog.Text += "The rat did " + ratDamage + " damage.\n";
                            _mage.stats.health -= (int)ratDamage;

                            // Handles player death
                            if (_mage.stats.health <= 0)
                            {
                                Close();
                            }

                            health.Content = "Health: " + _mage.stats.health + "/" + _mage.stats.totalHealth;
                            mana.Content = "Mana: " + _mage.stats.mana + "/" + _mage.stats.totalMana;
                        }
                        else
                        {
                            dialog.Text += rat.DeathMessage();
                            KillRat(sender, e);
                            Fighting = false;
                            rat = null;
                        }
                    }
                }
            }
            // For goblin
            else if (rat == null && ogre == null)
            {
                if (_warrior == null && _rogue == null)
                {
                    if (_mage.stats.mana - 10 > 0)
                    {
                        double playerDamage = _mage.Flames();

                        if (goblin.stats.health - playerDamage > 0)
                        {
                            goblinDamage = goblin.DoDamage();

                            _mage.stats.mana -= 10;
                            dialog.Text += "Flames did " + playerDamage + " damage.\n";
                            goblin.stats.health -= (int)playerDamage;
                            dialog.Text += "Goblin: " + goblin.stats.health + "/" + goblin.stats.totalHealth + " HP\n";
                            dialog.Text += "The goblin did " + goblinDamage + " damage.\n";
                            _mage.stats.health -= (int)goblinDamage;

                            // Handles player death
                            if (_mage.stats.health <= 0)
                            {
                                Close();
                            }

                            health.Content = "Health: " + _mage.stats.health + "/" + _mage.stats.totalHealth;
                            mana.Content = "Mana: " + _mage.stats.mana + "/" + _mage.stats.totalMana;
                        }
                        else
                        {
                            dialog.Text += goblin.DeathMessage();
                            KillGoblin(sender, e);
                            Fighting = false;
                            goblin = null;
                        }
                    }
                }
            }
            // For ogre
            else if (rat == null && goblin == null)
            {
                if (_warrior == null && _rogue == null)
                {
                    if (_mage.stats.mana - 10 > 0)
                    {
                        double playerDamage = _mage.Flames();

                        if (ogre.stats.health - playerDamage > 0)
                        {
                            ogreDamage = ogre.DoDamage();

                            _mage.stats.mana -= 10;
                            dialog.Text += "Flames did " + playerDamage + " damage.\n";
                            ogre.stats.health -= (int)playerDamage;
                            dialog.Text += "Ogre: " + ogre.stats.health + "/" + ogre.stats.totalHealth + " HP\n";
                            dialog.Text += "The ogre did " + ogreDamage + " damage.\n";
                            _mage.stats.health -= (int)ogreDamage;

                            // Handles player death
                            if (_mage.stats.health <= 0)
                            {
                                Close();
                            }

                            health.Content = "Health: " + _mage.stats.health + "/" + _mage.stats.totalHealth;
                            mana.Content = "Mana: " + _mage.stats.mana + "/" + _mage.stats.totalMana;
                        }
                        else
                        {
                            dialog.Text += ogre.DeathMessage();
                            KillOgre(sender, e);
                            Fighting = false;
                            ogre = null;
                        }
                    }
                }
            }
        }
    }
}