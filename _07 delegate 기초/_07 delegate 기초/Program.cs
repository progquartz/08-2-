using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_delegate_기초
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            도대체 delegate가 뭔지는 모르겠지만, 더럽게 무서운것은 분명하다. 그러지 않고서야 4강이 이거일리가 없어라고 생각하면서 문서를 적기 시작함.
            
            일반적으로, 함수에는 파라미터로 '데이터'  를넣었다.
            뭐 굳이 예를 들어본다면, 다음과 같은 함수의 경우는 a라는 int를 파라미터로 사용하고 있다.
            void Run(int a){}

            근데, 왜 맨날 파라미터로 데이터만 사용할 수 있을까?, Delegate는 이렇게 메서드를 다른 메서드로 전달할 수 있기 위해 만들어진 친구이다.
             숫자 혹은 객체를 메서드의 파라미터로써 전달할 수 있듯이, 메서드 또한 파라미터로서 전달할 수 있다. 
             Delegate는 메서드의 입력 파라미터로 피호출자에게 전달될 수 있을 뿐만 아니라, 또한 메서드의 리턴값으로 호출자에게 전달 수도 있다.

            예를 들어, 다음과 같은 함수를 가정해 보자. 여기서 MyDelegate가 델리게이트 타입이라고 가정하면,
            이 함수는 다른 어떤 메서드를 Run() 메서드에 전달하고 있는 것이다.

            void Run(MyDelegate method) { ... }

            그러면 델리게이트 타입 MyDelegate은 C# 키워드 class 를 사용하여 해당 클래스를 정의하게 된다.
            델리케이트 타입을 정의하기 위해선 특별한 C# 키워드 delegate 를 사용한다.

            delegate int MyDelegate(string s); // 앞에 보다시피 delegate를 쓰고 있다.
             */

            /*
            델리케이트 정의에서 중요한 것은 입력 파리미터들과 리턴 타입이다. 
            만약 어떤 메서드가 이러한 델리게이트 메서드 원형(Prototype)과 일치한다면, 즉 입력 파리미터 타입 및 갯수, 리턴 타입이 동일하다면 
            그 메서드는 해당 델리게이트에서 사용될 수 있다.

            델리케이트 정의는 마치 하나의 함수(메서드)를 정의하는 Prototype 선언식처럼 보이는데,
            사실 내부적으로 이 선언식은 컴파일러에 의해 특별한 클래스로 변환된다. 

            델리케이트를 다른 메서드에 전달하는 방식은 델리케이트 객체를 메서드 호출 파라미터에 넣으면 된다.
             이는 메서드를, 좀 더 정확히는 그 메서드 정보를 갖는 Wrapper 클래스의 객체를, 다른 메서드의 입력 파라미터로 전달하는 것이 된다.
             */
            /*
            델리게이트는 개념적으로 동일한 메서드 원형을 같는 메서드들을 받아서, 그 메서드들을 실행하는것이지만,
            내부적으로는 컴파일러가 delegate를 multi class delegate라는 .net 클래스로부터 파생된 새로운 클래스를 만들고 이를 통해서 그 안의 메서드들을 맵핑하여 그 메서드를 전달하는것이다. 

           컴파일러가 메소드들을 받으면 내부에서 새로운 클래스를 복사, 맵핑해서 그 메서드를 사용하는것이다.
           으 무슨 정리를 3번해야 이해되는 논리이람.
            */

            new Program().TestCode();
        }

        void TestCode()
        {

        }

        void Calc(int a, int b , string flag)
        {
            int res = 0;
            switch (flag)
            { // 각 케이스 별로 다른 메서드를 호출. 6개뿐이지만, 계속 늘어나면 case문도 늘어난다.
                // flag와 같이 하는것이 아닌, 직접적으로 연산 메소드를 받아들일 수 있다ㅕㅁㄴ
                // switch로 이렇게 고생할 필요가 없다.
                case "Add":
                    res = Add(a, b);
                    break;
                case "Subtract":
                    res = Subtract(a, b);
                    break;
                // 더 많은 경우...
                default:
                    break;
            }
            //... 연산을 하는 부분이 여러가지 연산이 있다고 하자. 
        }

        delegate int CalcDelegate(int a, int b);  // 델리게이트 만듬.두개의 정수를 받아들이고, 1개의 정수를 리턴한다는 함수를 이렇게 정의했다.
                                       // c는 메서드 원형 전체의 이름이다. 
        void Calc2(int a, int b, CalcDelegate calc) // 모든 메서드를 받는게 아니라 어떠한 메서드 원형을 갖는 메서드를 가질까를 정해야 한다.
        {
            int res = calc.Invoke(a, b); // Invoke를 사용할 수 있는 이유는 이것이 delegate로부터 상속된 메소드이기 때문이다.
            res = calc(a, b); // 이렇게도 사용할 수 있다.
                              // 시간이 더 있었으면 재밌는걸 만들 수 있을거 같은데.. 시간이 모자란게 한이다.
            Console.WriteLine("사용함수 : {0}", calc.Method);
            Console.WriteLine($"f({a},{b}) = {res}");
        }

        #region delegate 
        // 4개의 메서드는 2개의 int 를 받아 1개의 int를 반환함.
        public int Add(int a, int b)
        {
            int result = a + b;
            return result;
        }

        public int Subtract(int a, int b)
        {
            int result = a - b;
            return result;
        }

        public int Multiply(int a, int b)
        {
            int result = a * b;
            return result;
        }
        public int Divide(int a, int b)
        {
            int result = a / b;
            return result;
        }

        public int Mod(int a, int b)
        {
            return a % b;
        }

        public int Pow(int a, int b)
        {
            int r = 1;
            for(int i = 0; i < b; i++)
            {
                r *= a;
            }
            return r;
        }
        #endregion

    }
}
