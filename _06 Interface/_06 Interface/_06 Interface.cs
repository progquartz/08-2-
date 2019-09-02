using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            클래스와 비슷하게 인터페이스는 메서드, 속성, 이벤트, 인덱서 등을 갖지만, 인터페이스는 이를 직접 구현하지 않고 단지 정의(prototype definition)만을 갖는다.
            즉, 인터페이스는 추상 멤버(abstract member)로만 구성된 추상 Base 클래스(abstract base class)와 개념적으로 유사하다. 
            클래스가 인터페이스를 가지는 경우 해당 인터페이스의 모든 멤버에 대한 구현(implementation)을 제공해야 한다. 

            한 클래스는 하나의 Base 클래스만을 가질 수 있지만, 인터페이스는 여러 개를 가질 수 있다.
            아래의 예를 보면, MyConnection 이라는 클래스는 Component 라는 하나의 Base 클래스와 IDbConnection, IDisposable이라는 2개의 인터페이스를
            가지고 있음을 알 수 있다.

            쉽게 설명하자면, base / 파생 클래스인 상속 개념은 서로 상당히 긴밀한 관계를 가지고 있지만, 
            인터페이스의 경우는 일부만을 넘겨주는, 별 관련이 없지만 사용 가능한 파라미터가 되는 상당히 가볍고 유연한 형태의 관계라고 할 수 있다. 

             */
            List<_06_Isendable> deliveryMethods = new List<_06_Isendable>();
            deliveryMethods.Add(new email());
            deliveryMethods.Add(new Snailmail());
            deliveryMethods.Add(new SMS());

            Alert(deliveryMethods, "Emergency msg...");
        }

        private static void Alert(List<_06_Isendable> deliveryMethods, string msg) // 입력파라미터로써, 인터페이스를 받아들이고, 인터페이스를 이곳에서 사용.
        {
            foreach (_06_Isendable s in deliveryMethods)
            {
                s.Send(msg);
            }
        }
    }
    public class MyConnection : Component, IDisposable
    {
        // IDbConnection을 구현
        // IDisposable을 구현
    }
    /*
     인터페이스는 C# 키워드 interface를 사용하여 정의한다. 인터페이스 정의 시에는 (메서드와 같은) 내부 멤버들에 대해 public과 같은 접근 제한자를 사용하지 않는다.
    예를 들어, 아래 예제에서 CompareTo() 메서드 앞에 public 을 쓸 수 없다.
     */
    public interface IComparable
    {
        // 멤버 앞에 접근제한자 사용 안함
        int CompareTo(object obj);
    }

    /*
    C# 클래스가 인터페이스를 갖는 경우 인터페이스의 모든 멤버에 대한 구현을 제공해야 한다. C# 에서는 인터페이스로부터 직접 new를 사용하여 객체를 생성할 수 없다. 
    아래의 클래스는 IComparable이라는 인터페이스를 갖는 경우로서 IComparable.CompareTo() 메서드를 구현한 예이다. 
     */
    public class MyClass : IComparable
    {
        private int key;
        private int value;

        // IComparable 의 CompareTo 메서드 구현
        public int CompareTo(object obj)
        {
            MyClass target = (MyClass)obj;
            return this.key.CompareTo(target.key);
        }
    }

}
