using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Extension_Method
{
    public static class _14_ExtMth
    {
        public static bool IsEven(this int a) // int라고 하는 타입에 iseven을 추가해 사용하겠다는 의미이다.
        {
            return a % 2 == 0;
        }
    }
}
