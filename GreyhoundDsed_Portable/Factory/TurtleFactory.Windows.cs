using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreyhoundDsed_Portable.Model;

namespace GreyhoundDsed_Portable.Factory
{
    public partial class TurtleFactory
    {
        public Turtle[] TurtlesWindows { get; set; }

        public Turtle[] GetTurtlesWindows()
        {
            var turtles = new Turtle[]
            {
                new Turtle(Turtle.TurtleColor.Red,      @"/Assets/shells/red.png"),
                new Turtle(Turtle.TurtleColor.Green,    @"/Assets/shells/green.png"),
                new Turtle(Turtle.TurtleColor.Blue,     @"/Assets/shells/blue.png"),
                new Turtle(Turtle.TurtleColor.Purple,   @"/Assets/shells/purple.png")
            };

            return turtles;
        }

    }
}
