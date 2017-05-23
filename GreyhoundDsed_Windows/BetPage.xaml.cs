using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
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
        public BetPage()
        {
            this.InitializeComponent();
        }

        private void btnRace_Click(object sender, RoutedEventArgs e)
        {
            CollectBetData();
            this.Frame.Navigate(typeof(RacePage));
        }

        private void CollectBetData()
        {

        }
    }

    // 
    class Punters
    {
        public Punter[] AiPunters { get; set; } = new Punter[3];

        public Punters()
        {
            PopulatePunters(AiPunters);
            AssignRandomBetsToAi(AiPunters);
        }

        #region Assignment specific stuff

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

        #endregion
    }
}
