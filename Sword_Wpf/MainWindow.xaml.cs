using System;
using System.Diagnostics;
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

namespace Sword_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        SwordDamage swordDamage ;


        public MainWindow()
        {
            InitializeComponent();
            swordDamage = new SwordDamage(random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7));
            DisplayDamege();
            
        }

        public void RollDice()
        {
            swordDamage = new SwordDamage(random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7));
            DisplayDamege();
        }

        public void DisplayDamege()
        {
            damage.Content = " Rolled " + swordDamage.Roll + " for " + swordDamage.Damage + " HP ";
        }
        private void flaming_Checked(object sender, RoutedEventArgs e)
        {
            swordDamage.Flaming = true;
            DisplayDamege();
        }

        private void magic_Checked(object sender, RoutedEventArgs e)
        {
            swordDamage.SetMagic = true;
            DisplayDamege();
               
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RollDice();
        }

        private void flaming_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDamage.Flaming = false;
            DisplayDamege();
        }

        private void magic_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDamage.SetMagic = false;
            DisplayDamege();
        }
    }
}
