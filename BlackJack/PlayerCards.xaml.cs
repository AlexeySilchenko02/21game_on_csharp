using BlackJackLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BlackJack
{
    /// <summary>
    /// Логика взаимодействия для PlayerCards.xaml
    /// </summary>
    public partial class PlayerCards : UserControl
    {
        public static readonly DependencyProperty CardSetProperty;

        static PlayerCards()
        {
            CardSetProperty = DependencyProperty.Register("CardSet", typeof(ObservableCollection<Card>), typeof(PlayerCards));
        }

        public ObservableCollection<Card> CardSet
        {
            get
            {
                return (ObservableCollection<Card>)GetValue(CardSetProperty);
            }

            set
            {
                SetValue(CardSetProperty, value);
            }
        }

        public PlayerCards()
        {
            InitializeComponent();
        }
    }
}
