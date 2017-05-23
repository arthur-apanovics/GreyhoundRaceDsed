using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GreyhoundDsed_Portable.Factory;
using GreyhoundDsed_Portable.Model;

namespace GreyhoundDsed_Portable.Data
{
    public class PunterData : INotifyPropertyChanged
    {
        public Punter[] AiPunters { get; set; }
        public Punter PlayerPunter { get; set; } = new Punter("Player", 100){Bet = 5};

        // Player property helpers. Work with xaml on gui side.
        // For some reason when a value in the Player property is changed the property changed event is not triggered
        #region PlayerPunter helper props

        //public int PlayerBetHelper
        //{
        //    get { return PlayerPunter.Bet; }
        //    set
        //    {
        //        PlayerPunter.Bet = value;
        //        AllPunters = GetAllPunters(AiPunters, PlayerPunter);
        //        OnPropertyChanged(nameof(PlayerPunter));
        //    }
        //}

        //public Turtle.TurtleColor PlayerBetOnHelper
        //{
        //    get { return PlayerPunter.BetOn; }
        //    set
        //    {
        //        PlayerPunter.BetOn = value;
        //        AllPunters = GetAllPunters(AiPunters, PlayerPunter);
        //        OnPropertyChanged(nameof(PlayerPunter));
        //    }
        //}

        #endregion

        public PunterData()
        {
            var factory = new PunterFactory();

            AiPunters = factory.GetAiPunters();
            factory.SetRandomBetAmount(AiPunters);
            factory.SetRandomBetOnTurtles(AiPunters);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Debug.WriteLine($"Property of {propertyName} updated on M:{DateTime.Now.Minute}/S:{DateTime.Now.Second}/MS:{DateTime.Now.Millisecond}");
        }
    }
}
