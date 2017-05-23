using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreyhoundDsed_Portable.Model;

namespace GreyhoundDsed_Portable.Model
{
    public class Punter : IBet
    {
        public string Name { get; set; }
        public int Money { get; set; }

        // IBet interface properties
        public int Bet { get; set; }
        public Turtle.TurtleColor BetOn { get; set; }

        public Punter(string name, int money)
        {
            Name = name;
            Money = money;
        }


    }
}
