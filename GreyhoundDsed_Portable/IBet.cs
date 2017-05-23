using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreyhoundDsed_Portable.Model;

namespace GreyhoundDsed_Portable
{
    interface IBet
    {
        int Bet { get; set; }
        // set enum to a nullable type for xaml data binding fallback feature
        Turtle.TurtleColor BetOn { get; set; }
    }
}
