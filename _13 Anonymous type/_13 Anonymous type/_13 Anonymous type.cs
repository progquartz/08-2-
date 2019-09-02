using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Anonymous_type
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            일반적으로 객체를 생성하기 위해서는 먼저 클래스를 작성하고 그 클래스로부터 객체를 생성하는데, ananymous tyoe를 사용하면 객체를 생성할 수 있다.
            익명 타입은 다음과 같이 사용한다. 
             */
            var t = new { Name = "홍길동", Age = 20, Phone = "02-2222-22" }; // 무명 타입은 var에 저장된다.
            // 익명 타입은 무명이기 때문에, new ~ 등의 이름조차 적지 않는다. 명시적인 이름조차 없기 때문에, 컴파일러가 알아서 할 수 있게 var를 사용하는것이다.
            // 생성자를 사용하지 않고, 속성의 속성값을 이렇게 초기화하는 방법을 두고 object initializer라고 한다.
            // 익명 타입은 여러 속성을 가진 속성들의 집합이다.

            int age = t.Age;
            //t.Age = 2; // 새로운 값은 할당할 수 없느 read only 이다.
            // 컴파일러는 익명 타입을 만난면 익명 클래스를 생성한다. 확인할 경우 isclass 가 true임을 확인가능하다.

            Type typ = t.GetType();

            // 익명 타입은 특히 LINQ에서 많이 사용된다.
            var v = new[]
            {
                new { Name = "1lee", Age = 33 , Phone = "123-456-789"}, // 굳이 익명타입으로 할 필요가 없는 부분이니 안심하자.
                new { Name = "2lee", Age = 33, Phone = "123-456-789" },
                new { Name = "3lee", Age = 33, Phone = "123-456-789" }
            };
            // LINQ select를 이용해 30세 이상인 놈들 조회
            var list = v.Where(p => p.Age >= 30).Select(p => new {이름 =  p.Name, 나이 = p.Age}); // LINQ의 where절 사용. 추려내서 list에 넣음.
            foreach( var a in list)
            {
                Debug.WriteLine(a.이름 , a.나이);
            }
        }
    }
}
