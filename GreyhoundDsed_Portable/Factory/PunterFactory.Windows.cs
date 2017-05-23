using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GreyhoundDsed_Portable.Model;

namespace GreyhoundDsed_Portable.Factory
{
    public class PunterFactory
    {

        #region Old ai punter method. Does not comply with assignment goals

        public Punter[] GetAiPunters()
        {
            var punters = new Punter[]
            {
                new Punter("Bixby", 150),
                new Punter("Sergey", 60),
                new Punter("Joe", 45)
            };

            return punters;
        }

        #endregion

        // assignment friendly punter factory method.
        public Punter GetNewAiPunter(int id)
        {
            Punter punter = null;

            switch (id)
            {
                case 0:
                    punter = new Punter("Bixby", 150);
                    break;
                case 1:
                    punter = new Punter("Igor", 60);
                    break;
                case 2:
                    punter = new Punter("Gary", 45);
                    break;
            }

            return punter;
        }

        public Punter[] SetRandomBetAmount(Punter[] aiPunters)
        {
            var rnd = new Random();

            for (int i = 0; i < aiPunters.Length; i++)
            {
                // get a random number and round it to the nearest 5
                var randomBet = 5 * (int)Math.Round(rnd.Next(10, aiPunters[i].Money) / 5.0);
                aiPunters[i].Bet = randomBet;
            }

            return aiPunters;
        }

        public Punter[] SetRandomBetOnTurtles(Punter[] aiPunters)
        {
            var rnd = new Random();

            // create and randomly sort int array to set random turtle colors
            var rndIntArr = new int[] { 0, 1, 2, 3 }
            .OrderBy(x => rnd.Next())
            .ToArray();

            for (int i = 0; i < aiPunters.Length; i++)
            {
                aiPunters[i].BetOn = (Turtle.TurtleColor)Enum.Parse(typeof(Turtle.TurtleColor), rndIntArr[i].ToString());
            }

            return aiPunters;
        }

        public List<Punter> GetAllPunters(Punter[] aiPunters, Punter player)
        {
            List<Punter> allPunters = new List<Punter>();

            foreach (Punter aiPunter in aiPunters)
            {
                allPunters.Add(aiPunter);
            }
            allPunters.Add(player);

            return allPunters;
        }
    }
}
