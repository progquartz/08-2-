using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_static
{
    public class Program
    {/*
        static 붙은놈들.
        정적 메서드, static 속성, static 필드, static 생성자, 그리고 정적 클래스
         */

        static void Main(string[] args) // static 메서드는 static 멤버만 엑세스할 수 있다. 
        {
            StaticRun(); // static 멤버인 StaticRun은 호출되지만
            //InstanceRun(); // static이 아닌 멤버들은 호출할 수 없다.
            var p = new Program();
            p.InstanceRun(); // 인스턴스 메소드를 사용하기 위해서는 우선 객체를 생성한 다음 그 객체로부터 인스턴스 메소드를 호출할 수 있다.
            new Program().InstanceRun();// 이렇게 해도 된다.
                             // 신기하게 객체에서는 스태틱 메소드를 이용할 수 없다.

            Program.StaticRun(); // 다음과 같이 이용할수도 있다. 

            int[] nums = { 1, 2, 3, 4, 5 }; // 이런식으로 다른 클래스에 있는 static 메소드를 이용하려면, 클래스 이름을 적고 .을 찍어서 찾아내면 된다.
            int sum = Mycalc.Sum(nums);
            double avg = Mycalc.Avg(nums);

            int cnt = Mycalc.NextCount;
            Console.WriteLine(cnt); // 1
            cnt = Mycalc.NextCount;
            Console.WriteLine(cnt); // 2

            Mycalc calcobj = new Mycalc();
            // calcobj. 다음과 같이, calcobj.을 해도 static 을 볼 수 없다.

        }
        static void StaticRun()
        {

        }

        void InstanceRun()
        {

        }
    }
}
