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
        public Turtle[] TurtlesAndroid { get; set; }

        public Turtle[] GetTurtlesAndroid()
        {
            var turtles = new Turtle[]
            {
                new Turtle(Turtle.TurtleColor.Red,      @"@drawable\shells\red.png"),
                new Turtle(Turtle.TurtleColor.Green,    @"@drawable\shells\green.png\"),
                new Turtle(Turtle.TurtleColor.Blue,     @"@drawable\shells\blue.png\"),
                new Turtle(Turtle.TurtleColor.Purple,   @"@drawable\shells\purple.png\") 
            };

            return turtles;
        }

        public TurtleFactory()
        {
            TurtlesWindows = GetTurtlesWindows();
            TurtlesAndroid = GetTurtlesAndroid();
        }
    }
}
