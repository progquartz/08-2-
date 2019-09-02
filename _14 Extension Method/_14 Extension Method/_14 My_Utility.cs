using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Extension_Method
{
    public static class _14_My_Utility
    {
        public static bool IsEven(int a) // 이 클래스를 여러 c# 클래스들이 사용한다 가정하고, 이를 myutility 클래스로 옮기고 public으로 둠.
        {
            return a % 2 == 0;
        }

        // class 확장메서드
        public static string DashAppend(this string s, string text)
        {
            return s + "-" + text;
        }
    }
}
