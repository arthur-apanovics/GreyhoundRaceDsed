using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreyhoundDsed_Portable.Model;

namespace GreyhoundDsed_Portable
{
    public class RaceFunc : ICheckPositions
    {
        public int CrawlIncrement { get; set; } = 25; // max random number to increment by
        public int CrawlSpeed { get; set; } = 50; // thread update time in milliseconds
        public double Divider { get; set; } = 1.5d; // used to determine the wining line that a turtle needs to pass to win

        // Interface prop
        public double PageHeight { get; set; }

        public RaceFunc(double pageHeight)
        {
            PageHeight = pageHeight;
        }

        // Interface methods
        public bool CheckIfCenter(double turtleHeight)
        {
            return turtleHeight >= PageHeight / 2;
        }

        public bool CheckIfLimit(double turtleHeight)
        {
            return turtleHeight >= PageHeight / Divider;
        }

        public double[] MoveTurtles()
        {
            double[] newPos = new double[4];

            var rnd = new Random();

            for (int i = 0; i < newPos.Length; i++)
            {
                newPos[i] = rnd.Next(0, CrawlIncrement);
            }

            return newPos;
        }

        public string GetWinnerName(string canvasName)
        {
            // assign Red as default since enum is non-nullable
            Turtle.TurtleColor winner = Turtle.TurtleColor.Red;

            switch (canvasName)
            {
                case "canTurtleRed":
                    winner = Turtle.TurtleColor.Red;
                    break;
                case "canTurtleGreen":
                    winner = Turtle.TurtleColor.Green;
                    break;
                case "canTurtleBlue":
                    winner = Turtle.TurtleColor.Blue;
                    break;
                case "canTurtlePurple":
                    winner = Turtle.TurtleColor.Purple;
                    break;
            }

            return winner.ToString();
        }

    }
}
