using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyhoundDsed_Portable.Factory
{
    public class PositionFactory
    {
        public double GetRandomPostitionIncrement()
        {
            var rnd = new Random();

            int rndNum = rnd.Next(-10, 31);
            return rndNum;
        }
    }
}
