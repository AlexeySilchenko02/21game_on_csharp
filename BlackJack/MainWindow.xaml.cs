using BlackJackLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Dealer Dealer { get; set; } = new Dealer();
        public HumanPlayer Player { get; set; } = new HumanPlayer("Abobus", 1000);
        private GameStage stage = GameStage.BetWaiting;

        public MainWindow(Window owner)
        {
            Owner = owner;
            InitializeComponent();
        }


        private void CardRequest_Click(object sender, RoutedEventArgs e)
        {
            if (stage == GameStage.PlayersTurn)
            {
                Player.PickCard(Dealer.GiveCard());
                try
                {
                    CheckWinner(Player, Dealer);
                }
                catch (RoundEndException ex)
                {
                    Pay(ex.IsDealerWin);
                    MessageBox.Show(ex.Message);
                    IsGameOver();
                    PrepareToNewRound();

                }
            }
        }


        private void Enough_Click(object sender, RoutedEventArgs e)
        {
            if (stage == GameStage.PlayersTurn)
            {
                stage = GameStage.DealersTurn;
                try
                {
                    while (true)
                    {
                        Dealer.MakeAutoMove(Player.Score);
                        CheckWinner(Player, Dealer);
                    }
                }
                catch (RoundEndException ex)
                {
                    Pay(ex.IsDealerWin);
                    MessageBox.Show(ex.Message);
                    IsGameOver();
                    PrepareToNewRound();
                }
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Show();
        }

        private void Bet_Click(object sender, MouseButtonEventArgs e)
        {
            if (stage == GameStage.BetWaiting)
            {
                stage = GameStage.PlayersTurn;
                Player.MakeBet(int.Parse(((Image)sender).Tag.ToString()));
                StartRound();
            }
        }
        private void PrepareToNewRound()
        {
            Player.DiscardSet();
            Player.Bet = 0;
            stage = GameStage.BetWaiting;
            Dealer.DiscardSet();

        }
        private void StartRound()
        {
            try { 
            Dealer.ShuffleCards();
            Player.PickCard(Dealer.GiveCard());
            Player.PickCard(Dealer.GiveCard());
            Dealer.PickCard(Dealer.GiveCard());
            CheckWinner(Player, Dealer);
            }
            catch (RoundEndException e)
            {
                Pay(e.IsDealerWin);
                MessageBox.Show(e.Message);
                IsGameOver();
                PrepareToNewRound();
            }

        }
        private void IsGameOver()
        {
            if (Dealer.Money <= 0)
            {
                MessageBox.Show("У дилера закончились монетки! Вы победили!");
                Close();
            }
            else if (Player.Money <= 0)
            {
                MessageBox.Show("У вас закончились монетки! Вы проиграли!");
                Close();
            }
        }
        private void CheckWinner(Player player, Player dealer)
        {
            if (player.Score == 21)
                throw new RoundEndException(player);
            else if (dealer.Score == 21)
                throw new RoundEndException(dealer);
            else if (player.Score > 21)
                throw new RoundEndException(dealer);
            else if (dealer.Score > 21)
                throw new RoundEndException(player);
            else if (stage == GameStage.DealersTurn && dealer.Score >= player.Score && dealer.Score < 22)
                throw new RoundEndException(dealer);
            else
                return;
        }
        private void Pay(bool isDealerWin)
        {
            if (isDealerWin)
                Dealer.Money += Player.Bet;
            else
            {
                if (Player.Score == 21 && Player.CardSet.Count == 2)
                {
                    Player.Money += (int)(Player.Bet * 2.5);
                    Dealer.Money -= (int)(Player.Bet * 1.5);
                }
                else
                {
                    Player.Money += Player.Bet * 2;
                    Dealer.Money -= Player.Bet;
                }
            }
        }
        
    }
}
