using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreyhoundDsed_Portable.Factory;

namespace GreyhoundDsed_Portable.Model
{
    public class Turtle
    {
        public TurtleColor Color { get; set; }
        public string ShellFilePath { get; set; }

        public enum TurtleColor
        {
            Red,
            Green,
            Blue,
            Purple
        }

        public Turtle(TurtleColor color, string shellPath)
        {
            Color = color;
            ShellFilePath = shellPath;
        }
    }
}