namespace _10_delegate_3
{
    internal class Program
    {
        /*
모든 이벤트(event)는 특수한 형태의 delegate이다. C#의 delegate 기능은 경우에 따라 잘못 사용될 소지가 있다.
예를 들어, 우리가 Button 컨트롤을 개발해 판매한다고 하자. 이 컨트롤은 delegate 필드를 가지고 있고,
버튼 클릭시 InvocationList에 있는 모든 메서드들을 차례로 실행하도록 하였다. 그런데, Button 컨트롤을 구입한 개발자가
한 컴포넌트에서 추가 연산(+=)을 사용 하지 않고 실수로 할당 연산자(=)를 사용하였다고 가정하자.
이 할당연산은 기존에 가입된 모든 메서드 리스트를 지워버리고 마지막에 할당한 메서드 한개만 InvocationList에 넣게 할 것이다.
즉, 누구든 할당 연산자를 한번 사용하면 기존에 가입받은 모든 메서드 호출요구를 삭제하는 문제가 발생한다.

이러한 문제점과 더불어 또다른 중요한 문제점은 delegate는 해당 클래스 내부에서 뿐만 아니라, 외부에서도 누구라도 메서드를 호출하듯 (접근 제한이 없다면)
해당 delegate를 호출할 수 있다는 점이다. 아래 예제는 할당연산자를 사용해서 기존 delegate를 덮어쓰는 예와 delegate를 외부에서 호출하는 예를 보여준다.
*/

        private static void Main(string[] args)
        {
            MyArea area = new MyArea();

            area.MyClick += Area_Click;
            area.MyClick += AfterClick;

            area.Show();

            // 덮어쓰기: MyClick은 Area_Click메서드만 갖는다
            area.MyClick = Area_Click;

            // C# delegate는 클래스 외부에서 호출할 수 있다.
            // C# event는 불가
            area.MyClick(null);
        }

        /*
         C# delegate는 메서드의 레퍼런스를 갖고 있다는 점에서 C의 함수 포인터(function pointer)와 닮았다.
         하지만 C# delegate는 몇 가지 측면에서 C의 함수 포인터와 다르다.

        1. 클래스의 개념이 없는 C에서의 함수 포인터는 말 그대로 외부의 어떤 함수에 대한 주소값만을 갖는다.
           반면 C#의 delegate는 클래스 객체의 인스턴스 메서드에 대한 레퍼런스를 갖기 위해 그 C# 객체의 주소(객체 레퍼런스)와 메서드 주소를 함께 가지고 있다.
           (주: 물론 Static 메서드의 경우에는 객체의 레퍼런스값이 null 이 된다) C# delegate는 델리게이트 Type을 정의하는 것으로 이 Type으로부터 델리게이트 객체를 생성할 때,
           이 객체가 메서드 정보와 객체 정보를 가진다.

           클래스를 사용하는 C++에는 Pointer to member function이 있는데, 이는 한 클래스의 멤버 함수에 대한 포인터로서 '객체'에 대한 컨텍스트를 가지고
           있다는 점에서 C#의 delegate와 비슷하다. 단, C#의 delegate는 메서드 Prototype이 같다면 어느 클래스의 메서드도 쉽게 할당할 수 있는데 반해,
           C++의 Pointer to member는 함수 포인터 선언시 특정 클래스를 지정해주기 때문에 한 클래스에 대해서만 사용할 수 있다.

        2. 두번째로 C의 함수 포인터는 하나의 함수 포인터를 갖는데 반해, C# delegate는 하나 이상의 메서드 레퍼런스들을 가질 수 있어서 Multicast가 가능하다.

        3. 또한 C의 함수포인터는 Type Safety를 완전히 보장하지 않는 반면, C#의 delegate는 엄격하게 Type Safety를 보장한다.
         */
    }

    // C 함수 포인터 예제

//    void myfunc(int x)
//    {
//        printf("%d\n", x);
//    }

//    void main()
//    {
//        // 함수포인터 f 정의
//        void (*f)(int);

//        // 함수포인터에 함수 지정
//        f = &myfunc;

//        // 함수 실행
//        f(2);
//    }

//    // C++ Pointer to member 예제
//# include <iostream>
//# include <string>

//    internal class Cls
//    {
//        public:

//    // 클래스 메서드 멤버
//    private void myfunc(std::string str)
//        {
//            std::cout << str << std::endl;
//        }
//    };

//    void main()
//    {
//        // Pointer to member function 정의
//        void (Cls::* fp)(std::string);

//        // Pointer to member 지정
//        fp = &Cls::myfunc;

//        // Cls 객체 생성 및 객체 포인터 지정
//        Cls obj;
//        Cls* pObj = &obj;

//        // Cls 객체에서 함수포인터 사용
//        (pObj->* fp)("hello");
    }
}