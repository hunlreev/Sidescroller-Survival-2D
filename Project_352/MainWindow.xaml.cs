/* Name: Hunter Reeves, Billy Gibson
 * Date: 10/24/2019
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
        public MainWindow()
        {
            InitializeComponent();

            // Testing the new player
            Player player = new Player();
            player.GetInfo();
            Trace.WriteLine("");

            // Testing a Warrior
            Warrior warrior = new Warrior();
            warrior.GetInfo();
            Trace.WriteLine("");

            // Testing a Mage
            Mage mage = new Mage();
            mage.GetInfo();
            Trace.WriteLine("");

            // Testing a Rogue
            Rogue rogue = new Rogue();
            rogue.GetInfo();
        }
        // Press ESC to close the window
        private void CloseWindow(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
