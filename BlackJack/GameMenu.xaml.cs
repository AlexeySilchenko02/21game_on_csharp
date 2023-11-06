using BlackJackLibrary;
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
using System.Windows.Shapes;

namespace BlackJack
{
    /// <summary>
    /// Логика взаимодействия для GameMenu.xaml
    /// </summary>
    public partial class GameMenu : Window
    {
        public GameMenu()
        {
            InitializeComponent();
        }

        private void StartGame_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new MainWindow(this).Show();
        }

        private void CloseGame_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
    }
}
