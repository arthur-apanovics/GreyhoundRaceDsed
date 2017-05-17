using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreyhoundDsed_Portable.Model;

namespace GreyhoundDsed_Portable.Factory
{
    public class TurtleFactory
    {
        public Turtle[] Turtles { get; set; }

        public Turtle[] GetTurtles()
        {
            var turtles = new Turtle[]
            {
                new Turtle(Turtle.TurtleColor.Red,      @"\Assets\shells\red.png"),
                new Turtle(Turtle.TurtleColor.Green,    @"\Assets\shells\green.png\"),
                new Turtle(Turtle.TurtleColor.Blue,     @"\Assets\shells\blue.png\"),
                new Turtle(Turtle.TurtleColor.Purple,   @"\Assets\shells\purple.png\") 
            };

            return turtles;
        }

        public TurtleFactory()
        {
            Turtles = GetTurtles();
        }
    }
}
