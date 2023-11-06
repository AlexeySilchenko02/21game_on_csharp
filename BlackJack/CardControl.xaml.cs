using BlackJackLibrary;
using System.Windows;
using System.Windows.Controls;


namespace BlackJack
{
    /// <summary>
    /// Логика взаимодействия для CardControl.xaml
    /// </summary>
    public partial class CardControl : UserControl
    {
        public static readonly DependencyProperty CurrentCardProperty;

        static CardControl()
        {
            CurrentCardProperty = DependencyProperty.Register("CurrentCard", typeof(Card), typeof(CardControl));
        }

        public Card CurrentCard
        {
            get
            {
                return (Card)GetValue(CurrentCardProperty);
            }

            set
            {
                SetValue(CurrentCardProperty, value);
            }
        }

        public CardControl()
        {
            InitializeComponent();
        }
    }
}
