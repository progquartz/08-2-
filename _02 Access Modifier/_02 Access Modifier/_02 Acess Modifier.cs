using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Access_Modifier
{
    class Program
    {
        /*
        public  	모든 외부(파생클래스 포함)에서 이 타입(Type: 클래스, 구조체, 인터페이스, 델리게이트 등)을 엑세스할 수 있다. (개별 타입 멤버의 엑세스 권한은 해당 멤버의 접근 제한자에 따라 별도로 제한될 수 있다)
        internal	동일한 어셈블리 내에 있는 다른 타입들이 엑세스 할 수 있다. 하지만, 다른 어셈블리에서는 접근이 불가하다.
        protected	파생클래스에서 이 클래스 멤버를 엑세스할 수 있다.
        private	    동일 클래스/구조체 내의 멤버만 접근 가능하다.

        접근 제한자는 public class A {} 와 같이 클래스, 구조체와 같은 Type 앞에 사용하거나 메서드, 속성, 필드 등의 클래스/구조체 멤버 앞에 사용하여 (예: protected int GetValue(); ) 접근을 제한하게 된다.

        1. 클래스 멤버는 5가지의 접근 제한자를 (public, internal, private, protected, protected internal) 모두 가질 수 있지만, 
        구조체(struct) 멤버는 상속이 되지 않으므로 3가지의 접근 제한자만 (public, internal, private) 가질 수 있다.
        2. 보틍 클래스와 구조체는 네임스페이스 바로 밑에 선언하는데,이때 디폴트로 internal 접근 제한을 갖는다.
         단, 클래스 내부에 Nested 클래스를 선언하는 것과 같이 Nested Type을 선언하면 디폴트로 private 접근 제한을 갖는다.
        3. 인터페이스(interface)와 열거형(enum)의 멤버는 기본적으로 public 이며, 각 멤버에 별도의 접근 제한자를 사용하지 않는다.
             */
             /*
             다음과 같은 예제에서,
             Myclass 는 internal class로써 같은 어셈블리의 다른 타입만 이 클래스로 접근이 된다.
             _id는 private로 클래스 내부에서만 사용된다.

             */
        internal class MyClass
        {
            private int _id = 0;

            public string Name { get; set; }

            public void Run(int id) { }

            protected void Execute() { }
        }
        static void Main(string[] args)
        {
            _02_Logger logger = new _02_Logger;
            logger.LogSuccess("");
        }
    }
}
