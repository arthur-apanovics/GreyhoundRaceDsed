using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyhoundDsed_Portable.Model
{
    abstract class Punter
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public int Bet { get; set; }

        public Punter(int money)
        {
            Money = money;
        }
    }
}
