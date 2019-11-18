/* Name: Hunter Reeves, Billy Gibson
 * Date: 11/06/2019
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
        public MainWindow(Warrior warrior)
        {
            InitializeComponent();

            _warrior = warrior;
        }
        // Press ESC to close the window
        private void CloseWindow(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
        // Shows information to the user of their player
        private void ShowPlayerInfo(object sender, EventArgs e)
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
        }

        private Warrior _warrior;
    }
}