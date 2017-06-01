using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyhoundDsed_Portable
{
    interface ICheckPositions
    {
        double PageHeight { get; set; }

        bool CheckIfCenter(double turtleHeight);
        bool CheckIfLimit(double turtleHeight);
    }
}
