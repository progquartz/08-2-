using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_generic
{
    class BaseClass
    {

    }
    class MyClass<T, U>
        where T : BaseClass // type T는 bassclass나 그 파생 클래스여야하고
        where U : IComparable // 이는 그 타입이 icomparable interface 를 할 수 있어야 한다는것이다.
    {   

    }
    // 좀 더 복잡한 제약들
    class EmployeeList<T> where T : Employee,
       IEmployee, IComparable<T>, new()
    {
    }
    class Caculator<T> where T : struct// type T는 제약을 걸수 있는데, where T : ~~ 로써 지정이 가능하다.
    {
        // 4개의 메서드는 2개의 int 를 받아 1개의 int를 반환함.
        // 제너릭은 닷넷에서 자주 쓰이는데, list의 경우 다음과 같고, dictionary는 2개의 제너릭을 가지고 있기도 하다.
        List<int> intlist;
        Dictionary<int, int> dictlist;
        public T Add(T a, T b) // 각자 차이나는 부분은 입력 타입과 리턴 타입이다. 그래서 이를 타입 파라미터로 표현한다. 
        {// 단순히 하는것만으로는 a와 b가 사칙연산이 되는지 모르기 때문에, 워커라운드로써 이를 다이나믹 변수에 집어넣고 런타임시에 동시에 사칙연산을 수행하게 한다.
            dynamic da = a;
            dynamic db = b; // 다이나믹 타입은 행위를 할 수 있는지에 대한 체크를 안하고 런타임시에 그 행동에 대해 수행한다. 
            T result = da + db;
            return result;
        }

        public T Subtract(T a, T b)
        {
            dynamic da = a;
            dynamic db = b;
            T result = da - db;
            return result;
        }

        public T Multiply(T a, T b)
        {
            dynamic da = a;
            dynamic db = b;
            T result = da * db;
            return result;
        }
        public T Divide(T a, T b)
        {
            dynamic da = a;
            dynamic db = b;
            T result = da / db;
            return result;
        }
    }

    class DoubleCaculator
    {
        // 4개의 메서드는 2개의 double 를 받아 1개의 double를 반환함.
        public double Add(double a, double b)
        {
            double result = a + b;
            return result;
        }

        public double Subtract(double a, double b)
        {
            double result = a - b;
            return result;
        }

        public double Multiply(double a, double b)
        {
            double result = a * b;
            return result;
        }
        public double Divide(double a, double b)
        {
            double result = a / b;
            return result;
        }
    }

    // 5개의 클래스를 정의했는데, 거의 동일한 로직을 가지고 있고, 리턴만을 제외하고 나머지 로직이 같다.
    // 이렇게 코드를 중복해서 쓰게 되는 문제점을 해겨ㅕㄹ하기 위해서 generic이란 방식을 사용한다
}
