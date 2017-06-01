using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GreyhoundDsed_Portable;
using GreyhoundDsed_Portable.Factory;
using GreyhoundDsed_Portable.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GreyhoundDsed_Windows
{
    public sealed partial class RacePage : Page
    {
        //public int CrawlIncrement { get; set; } = 25; // max random number to increment by
        //public int CrawlSpeed { get; set; } = 50; // update time in milliseconds
        //public double Divider { get; set; } = 1.5d; // used to determine the wining line that a turtle needs to pass to win

        public RacePage()
        {
            this.InitializeComponent();
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            TurtleRunAnimation.Begin();
            WaterAnimation.Begin();
            RunRace();
        }

        private async void RunRace()
        {
            Canvas[] turtles = new Canvas[] { canTurtleRed, canTurtleGreen, canTurtleBlue, canTurtlePurple };
            RaceFunc race = new RaceFunc(page.ActualHeight);
            bool isAtCenter = false;
            bool isAtLimit = false;
            string winner = string.Empty;

            do
            {

                double[] newPositions = race.MoveTurtles();

                for (int i = 0; i < turtles.Length; i++)
                {
                    turtles[i].Height += newPositions[i];

                    if (race.CheckIfCenter(turtles[i].Height) && !isAtCenter)
                    {
                        isAtCenter = true;
                        ScrollTheView.Begin();
                    }
                    else if (race.CheckIfLimit(turtles[i].Height))
                    {
                        isAtLimit = true;
                        winner = race.GetWinnerName(turtles[i].Name);
                    }

                    await Task.Delay(TimeSpan.FromMilliseconds(race.CrawlSpeed));
                }

            } while (!isAtLimit);

            var dialog = new MessageDialog($"{winner} is the winner!");
            await dialog.ShowAsync();

            RaceDone(winner);
        }

        private void RaceDone(string winner)
        {
            this.Frame.Navigate(typeof(BetPage), winner);
        }

        #region Old Race Method

        //private async void RaceTurtles()
        //{
        //    Canvas[] turtles = new Canvas[] { canTurtleRed, canTurtleGreen, canTurtleBlue, canTurtlePurple };

        //    // used to determine when the turtles have reached center of screen to start animations
        //    int turtleCenter = Convert.ToInt32(page.ActualHeight / 2);

        //    // used for determining the winning turtle
        //    int turtleLimit = Convert.ToInt32(page.ActualHeight);

        //    bool isTurtleAtCenter = false;
        //    bool isTurtleAtLimit = false;

        //    var rnd = new Random();

        //    do
        //    {
        //        for (int j = 0; j < turtles.Length; j++)
        //        {
        //            turtles[j].Height = turtles[j].Height + rnd.Next(0, CrawlIncrement);

        //            if (turtles[j].Height >= turtleCenter && !isTurtleAtCenter)
        //            {
        //                isTurtleAtCenter = true;
        //                ScrollTheView.Begin();
        //            }
        //            else if (turtles[j].Height >= turtleLimit / Divider)
        //            {
        //                isTurtleAtLimit = true;
        //                await ShowWinner(turtles[j]);
        //                return;
        //            }

        //            await Task.Delay(TimeSpan.FromMilliseconds(CrawlSpeed));
        //        }
        //    } while (!isTurtleAtLimit);
        //}

        //private async Task<bool> ShowWinner(Canvas canTurtle)
        //{
        //    Turtle.TurtleColor winner = Turtle.TurtleColor.Red;

        //    switch (canTurtle.Name)
        //    {
        //        case "canTurtleRed":
        //            winner = Turtle.TurtleColor.Red;
        //            break;
        //        case "canTurtleGreen":
        //            winner = Turtle.TurtleColor.Green;
        //            break;
        //        case "canTurtleBlue":
        //            winner = Turtle.TurtleColor.Blue;
        //            break;
        //        case "canTurtlePurple":
        //            winner = Turtle.TurtleColor.Purple;
        //            break;
        //    }

        //    var dialog = new MessageDialog($"{winner} is the winner!");
        //    await dialog.ShowAsync();
        //    return true;
        //}

        #endregion

        //DEBUG STUFF.
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BetPage));
        }

        private void btnControlToggle_Click(object sender, RoutedEventArgs e)
        {
            btnControlToggle.Visibility = Visibility.Collapsed;
            controls.Visibility = Visibility.Visible;
        }
    }
}
