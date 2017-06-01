using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GreyhoundDsed_Portable.Factory;
using GreyhoundDsed_Portable.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GreyhoundDsed_Windows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BetPage : Page
    {
        public static Punter[] AiPunters { get; set; }
        public static Punter PlayerPunter { get; set; } = new Punter("Player", 100) { Bet = 5 };

        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (AiPunters == null)
            {
                AiPunters = new Punter[3];
                PopulatePunters(AiPunters);
            }

            if (e.Parameter != null)
                RaceOutcome(e, AiPunters, PlayerPunter);

            AssignRandomBetsToAi(AiPunters);
        }

        private void CheckForBust(Punter punter)
        {
            if (punter.Money <= 0)
                punter.isBust = true;
        }

        private void RaceOutcome(NavigationEventArgs e, Punter[] aiPunters, Punter player)
        {
            var winner = WinnerToTurtleColor(e.Parameter.ToString());
            var message = new StringBuilder();

            for (int i = 0; i < AiPunters.Length; i++)
            {
                if (aiPunters[i].BetOn == winner && !aiPunters[i].isBust)
                {
                    aiPunters[i].Money += aiPunters[i].Bet;
                    message.Append($"\n{aiPunters[i].Name} has WON ${aiPunters[i].Bet}");
                }

                else if (!aiPunters[i].isBust)
                {
                    aiPunters[i].Money -= aiPunters[i].Bet;
                    message.Append($"\n{aiPunters[i].Name} has LOST ${aiPunters[i].Bet}");
                    CheckForBust(aiPunters[i]);
                }
            }

            if (player.BetOn == winner)
            {
                player.Money += player.Bet;
                message.Append($"\nPlayer has WON ${PlayerPunter.Bet}");
            }
            else
            {
                player.Money -= player.Bet;
                message.Append($"\nPlayer has LOST ${PlayerPunter.Bet}");
            }

            ShowDialog(message);

            if (player.Money <= 0)
            {
                GameOver();
            }
        }

        private async void ShowDialog(StringBuilder message)
        {
            var dialog = new MessageDialog(message.ToString());
            await dialog.ShowAsync();
        }

        private async void GameOver()
        {
            var dialog = new MessageDialog("You lost! Bye, bye!");
            await dialog.ShowAsync();
            Application.Current.Exit();
        }

        private Turtle.TurtleColor WinnerToTurtleColor(string winner)
        {
            switch (winner)
            {
                case "Red":
                    return Turtle.TurtleColor.Red;
                case "Green":
                    return Turtle.TurtleColor.Green;
                case "Blue":
                    return Turtle.TurtleColor.Blue;
                case "Purple":
                    return Turtle.TurtleColor.Purple;
                // not nullable enum, so return red as a default
                default:
                    return Turtle.TurtleColor.Red;
            }
        }

        public BetPage()
        {
            this.InitializeComponent();
        }

        private void btnRace_Click(object sender, RoutedEventArgs e)
        {
            if (gridTurtles.SelectedIndex < 0)
            {
                SelectionNotify.Begin();
                return;
            }
            this.Frame.Navigate(typeof(RacePage));
        }

        private void AssignRandomBetsToAi(Punter[] punters)
        {
            var factory = new PunterFactory();

            factory.SetRandomBetAmount(punters);
            factory.SetRandomBetOnTurtles(punters);
        }

        private void PopulatePunters(Punter[] punters)
        {
            var factory = new PunterFactory();

            for (int i = 0; i < punters.Length; i++)
            {
                punters[i] = factory.GetNewAiPunter(i);
            }
        }
    }
}
