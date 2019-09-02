using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_static
{
    class Mycalc
    {
        // static method
        public static int Sum(int [] numbers)
        {
            int sum = 0;
            foreach(var n in numbers)
            {
                sum += n;
            }
            return sum;
        }

        public static double Avg(int[] numbers) // 만약 Sum이 static이 아니라면, 에러가 날것이다.static에는 static메소드밖게 있을수 없으니까 말이다.
        {
            double Avg = (double)(Sum(numbers) / numbers.Count());
            return Avg;
        }

        private static int counter;

        // static field는 field 앞에 static 을 붙힌다. 
        private static object objLock = new object();
        public static int NextCount
        {
            get
            {
                return Interlocked.Increment(ref counter);


            }
        }

    }
}
