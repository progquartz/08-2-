using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12_Lambda_Expression
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        delegate int FN(int a);
        private void Form1_Load(object sender, EventArgs e)
        {
            // 무명메서드를 람다식으로
            button1.Click += delegate (object s, EventArgs ea)
            {
                MessageBox.Show("Done");
            };

            button1.Click += ( s,  ea) => {
                MessageBox.Show("Done");
            };// 람다식은 입력 파라미터를 적고 -> 를한 다음에 메소드 바디를 입력한다.
              // 람다식에서는 일반적으로 파라미터 타입은 적지 않는것이 일반적이다. 파라미터 타입은 Click에서 이미 정해져있기 때문에 이와 같이 할 수 있다.
              // 또한 여러 줄의 코드도 가능하지만 한줄일 경우 그냥 줄여서 중괄호를 없애버리자.

            /*
            람다식은 무명메서드와 마찬가지로 delegate 타입의 변수의 람다식을 할당할 수 있다. 
             */
            FN sqr = (x) => { return x * x;  };
            sqr = (x) => x * x; // 이렇게도 표현이 된다 삐슝뿌슝빠슝
            int res = sqr(4); // 4가 x로 전달되고 이 x가 다시 메소드 바디가 옆으로 전달되어서 4*4가 계산되어 리턴된다.
            Func<int, int> sq = (x) => x * x; // 이렇게도 사용할 수 있다. 이경우에는 func라는 .net기반의 친구임. 16개까지 입력 파라미터를 받을 수 있음.
            Func<double,double,decimal>a = (x, y) => (decimal)(x * y);
            Func<decimal> f; // 리턴만 있는 경우는 action이라는 친구와 유사해진다.
        }
    }
}
