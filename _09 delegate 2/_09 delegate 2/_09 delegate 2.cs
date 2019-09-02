using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_delegate_2
{

    class Program
    {
        static MyArea area;
        static void Main(string[] args)
        {
            /*
            delegate는 또한 클래스의 필드나 속성에 사용될 수 있다. 일종의 함수 포인터를 필드나 속성에 저장 하는 것과 비슷한 맥락이다.
            메서드 파라미터로 전달하던, 필드로 저장하던 클래스 객체의 입장에서는 전달된 delegate를 필요에 따라 자신의 클래스 내에서 사용하면 된다. 

            아래 예는 delegate 필드(MyClick)를 정의한 후, 클래스 내부 함수(MyAreaClicked)에서 delegate 필드가 NULL이 아니면, 
            해당 delegate를 실행하는( MyClick(this); ) 코드를 보여준다. delegate 실행은 메서드를 호출하는 것과 같은데, 
            델리게이트 필드 자신이 마치 메서드명인 것처럼 사용하면 된다.
             */

            /*
            C# delegate는 여러 개의 메서드들을 할당하는 것이 가능하다. C# 연산자 += 을 사용하면 메서드를 계속 delegate 에 추가하게 되는데,
            내부적으로는 .NET MulticastDelegate 클래스에서 이 메서드들의 리스트(이를 InvocationList 라고 한다)를 관리하게 된다.

            복수개의 메서드들이 한 delegate에 할당되면, 이 delegate가 실행될 때, InvocationList로부터 순서대로 메서드를 하나씩 가져와 실행한다. 
            아래 예제는 복수 개의 메서드를 한 delegate에 계속 추가하는 예이다. 
             */
            area = new MyArea();

            //복수개의 메서드를 delegate에 할당
            area.MyClick += Area_Click;
            area.MyClick += AfterClick;

            area.ShowDialog();

        }
        static void Area_Click(object sender)
        {
            area.Text += " MyArea 클릭! ";
        }

        static void AfterClick(object sender)
        {
            area.Text += " AfterClick 클릭! ";
        }
    }
}
