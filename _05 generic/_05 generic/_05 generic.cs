using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_generic
{
    class Program
    {
        static void Main(string[] args)
        {
            var icalc = new Caculator<int>();
            var x = icalc.Add(1, 2);

            var dcalc = new Caculator<double>();
            var y = dcalc.Divide(1.0, 3);
        }
    }
}
