    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Extension_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 124;
            bool b = _14_My_Utility.IsEven(a); // iseven이라는 메소드는 정수에 적용되는 메소드라고 할 수 있다. 만약 iseven이 int라고 하는 구조체에 소속되어있는
                                               //메소드라면 더욱 직관적으로 사용할 수 있을것이다. 만약 integar 타입 안에 iseven메소드를 넣으면 이렇게 쓸수 있다

            bool b = a.IsEven();
            b = 100.IsEven(); // 확장 메서드의 첫번째 파라미터는 그 메서드를 호출한 객체를 의미한다. 그래서 100이라고 하는 정수 객체를 이 메소드의 첫 파라미터로 사용한다.
                              //그래서 확장메서드에서 this는 그 객체를 의미한것이고 이것이 파라메터에서 이동되어 사용되는것이다. 
                              // 

            string s1 = "asd";
            string s2 = s1.DashAppend("DEF");
        }

    }
}
