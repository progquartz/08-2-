using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            컴파일러에서 타입 체킹은 프로그램에서 각 타입들이 제대로 사용되고 있는지 체크하는 기능으로써, 각 타입에 올바른 값이 적용되는지, 각 타입의 메소드나 속성같은 타임 멤버들이 올바르게 사용되는지 체크하는 기능이다.
            만약 정수타입 a에 다른 데이타를 할당하면 컴파일러는 에러를 낸다.
            
            c#의 이러한 채킹은 버그를 잡는데 유용하다. c#은 항상 이렇게 매번 타입 체킹을 하는데, c# 4.0에서 이를 skip하도록 하는기능이 생김. 
             */
            dynamic a = false; // dynamic 변수는 타입체킹을 안해서 임의의 타입의 데이터가 들어갈 수 있다.
            a = 1;
            a = "ppap";
            // dynamic 타입은 컴파일시에 체크를 하지 않고 run시에 타입 판별을 한다.
            Console.WriteLine(a.GetType()); // System.String

            /*
             다이나믹 타입은 중간에 타입 변경이 가능하다.
             여러종류의 데이터타입을 넣을 수 있는것은 오브젝트와 매우 유사하지만, 차이점이 있다.

            오브젝트 타입은 underlyinh 타입을 멤버나 기능을 사용하기 위해서는 underlying 타입으로 캐스팅 한 다음에 그 객체를 얻고 멤버를 사용하게 된다.

            반면, 다이나믹 타입은 런 시에 그 타입을 동적으로 판별하고, 그 멤버들을 사용할 수 있기 떄문에, 별도의 casting을 필요로 하지 않는다.

             */

            a = 1.3;
            Console.WriteLine(a.GetType()); // System.double

            object i = 10;
            i = (int)i + 20; // 연산 불가!  정상적인 casting을 해야지만 됨.

            i = "Hello";
            string s = ((string)i).ToUpper(); // casting 필수.

            // 동적 판별하는 dynamic은 이게 필요없음.

            dynamic d = 10;
            d = d + 20;

            d = "Hello";
            s = d.ToUpper();
            

        }
        /*
        다이나믹 타입을 사용하는 case 로  익명 타입 개체를 다른 메소드에 전달하는 부분에 대해 알아보도록 하자.
         */

            // 익명 타입으 ㅣ제약점을 고치기 위해 expend object를 사용가능하다. 사용시 속성이나 메서드 이벤트를 동적으로 추가한 개체를 만듨 수 있고 이를 다른 어셈블리로 보낼 수 있다.
            // 오브젝트는 system.dynamicnamespace 안에 있다.

         void ExpandoTest()
        {
            dynamic person = new ExpandoObject();
            person.Name = "Kim";
            person.Age = 23; // 속성 추가.

            person.DisplayData = (Action)(() => // 액션 정의
            {
                Console.WriteLine($"{person.Name} : {person.Age}");
            });

            person.AgeChanged = null;
            person.ChangeAge = (Action)(() => // 이벤트 정의.
            {
                person.Age = age;
                if (person.AgeChanged != null)
                {
                    person.AgeChanged(this, EventArgs.Empty);
                }
            });
        }
         class Class1
        {
            public void Test()
            {
                dynamic t = new { Name = "Kim", Age = 25 };
                new Class2().Run(t);
            }

        }
        class Class2
        {
            public void Run(dynamic o)
            {
                // dynamic 타입의 속성 적립 사용
                Console.WriteLine(o.Name);
                Console.WriteLine(o.Age);
            }
        }
    }
}
