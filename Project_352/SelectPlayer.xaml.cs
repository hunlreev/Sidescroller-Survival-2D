/* Author: Hunter Reeves
 * Date: 10/24/2019
 * File: SelectPlayer.xaml.cs
 * Description: Code for SelectPlayer window
 */

using System;
using System.Collections.Generic;
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
        private void CreateCharacter(object sender, RoutedEventArgs e)
        {
            // TODO - Create character with PlayerCreation

            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
