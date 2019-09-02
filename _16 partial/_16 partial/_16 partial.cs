using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_partial
{
    class Program
    {
        /*
        C# 2.0에서 partial 키워드가 도입되어 Partial Class, Partial Struct, Partial Interface 를 사용할 수 있게 되었다.
        기본적으로 이들 Partial 타입들이 만든어진 이유는 Code Generator가 만든 코드와 사용자가 만드는 코드를 분리하기 위함이다. 
        예를 들어, 윈폼에서는 Form UI 디자인과 관련된 Form1.designer.cs 파일과 사용자가 쓰는 Form1.cs 파일에 동일한 클래스명을 두고 이를 partial로 선언하는데,
        컴파일러는 나중에 이를 합쳐 하나의 클래스로 만든다. 또한, ASP.NET 웹폼에서는 하나의 웹페이지를 만들 때, 3개의 파일을 만드는데
        , XML인 page1.aspx 이외의 .cs 파일 안에는 윈폼과 마찬가지고 partial 클래스를 사용하고 있다.

        아래 예제는 C# partial 키워드를 사용한 코드들인데, partial 키워드는 class, struct, interface 키워드 바로 앞에 위치해야 하며, 2개 이상의 파일에 걸쳐 Type을 나눌 수 있게 한다.
        예제에서 처음의 partial class는 하나의 클래스를 3개로 분리한 예이며,
        두번째의 partial struct는 struct를 2개로 분리한 예이다 (비록 아래와 같이 필드를 분리하는 것도 가능하지만, 필드끼리 한군데 모아 두는 것이 권장사항이다).
        세번째는 partial interface를 2개로 분리한 경우인데 이 interface의 두 멤버를 구현한 클래스의 예제를 함께 보여주고 있다. 
             */
        static void Main(string[] args)
        {
        }
    }

    // 1. Partial Class - 3개로 분리한 경우
    partial class Class1
    {
        public void Run() { }
    }
    partial class Class1
    {
        public void Get() { }
    }
    partial class Class1
    {
        public void Put() { }
    }

    // 2. Partial Struct
    partial struct Struct1
    {
        public int ID;
    }
    partial struct Struct1
    {
        public string Name;

        public Struct1(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }

    // 3. Partial Interface
    partial interface IDoable
    {
        string Name { get; set; }
    }
    partial interface IDoable
    {
        void Do();
    }
    // IDoable 인터페이스를 구현
    public class DoClass : IDoable
    {
        public string Name { get; set; }

        public void Do()
        {
        }
    }
}
