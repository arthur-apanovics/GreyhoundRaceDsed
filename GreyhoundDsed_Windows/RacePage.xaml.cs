using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GreyhoundDsed_Portable.Factory;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GreyhoundDsed_Windows
{
    public sealed partial class RacePage : Page
    {
        public int RaceSpeed { get; set; } //update time in milliseconds

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            WaterAnimation.Begin();
        }

        public RacePage()
        {
            this.InitializeComponent();
            RaceSpeed = 100;
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            TurtleRunAnimation.Begin();

            RaceTurtles();
        }

        private async void RaceTurtles()
        {
            Canvas[] turtles = new Canvas[] { canTurtleRed, canTurtleGreen, canTurtleBlue, canTurtlePurple };

            for (int i = 0; i <= page.ActualHeight / 3; i++)
            {
                for (int j = 0; j < turtles.Length; j++)
                {
                    var rnd = new Random();
                    var rndNum = rnd.Next(1, 20);

                    turtles[j].Height = turtles[j].ActualHeight + rndNum;

                    await Task.Delay(TimeSpan.FromMilliseconds(RaceSpeed));
                }
            }
        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            RaceSpeed = RaceSpeed == 100 ? 10 : 100;
        }

        //DEBUG STUFF. DELETE AFTERWARDS
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Canvas[] turtles = new Canvas[] { canTurtleRed, canTurtleGreen, canTurtleBlue, canTurtlePurple };

            for (int j = 0; j < turtles.Length; j++)
            {
                turtles[j].Height = 70;
            }
        }
    }
}
