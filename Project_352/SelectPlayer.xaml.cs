/* Author: Hunter Reeves
 * Date: 10/24/2019
 * File: SelectPlayer.xaml.cs
 * Description: Code for SelectPlayer window
 */

using Project_352.Functionality;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

namespace Project_352
{
    /// <summary>
    /// Interaction logic for SelectPlayer.xaml
    /// </summary>
    public partial class SelectPlayer : Window
    {
        public SelectPlayer()
        {
            InitializeComponent();
        }
        // Creates the character for the user and moves to main game window
        private void CreateCharacter(object sender, RoutedEventArgs e)
        {
            // Passes all possible class choices to main window
            MainWindow main = new MainWindow(warrior, mage, rogue);
            main.Show();
            Close();
        }
        // Helper functions for selecting a name and class, probably a much better way to do this...
        private void SelectWarrior(object sender, RoutedEventArgs e)
        {
            _name = GetName.Text;
            _class = "Warrior";
            Warrior warrior = create.Warrior(_name, _class);
            this.warrior = warrior;
        }
        private void SelectMage(object sender, RoutedEventArgs e)
        {
            _name = GetName.Text;
            _class = "Mage";
            Mage mage = create.Mage(_name, _class);
            this.mage = mage;
        }
        private void SelectRogue(object sender, RoutedEventArgs e)
        {
            _name = GetName.Text;
            _class = "Rogue";
            Rogue rogue = create.Rogue(_name, _class);
            this.rogue = rogue;
        }

        private string _name;
        private string _class;
        public Warrior warrior;
        public Mage mage;
        public Rogue rogue;
        private PlayerCreation create = new PlayerCreation();
    }
}
