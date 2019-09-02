using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11_Anonymous_method
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        delegate void RunDelegate(int p); // 리턴값이 없는 무명 메소드
        delegate int ExprDelegate(int a, int b); // 리턴이 있는 무명 메소드

        private void Form1_Load(object sender, EventArgs e)
        {
            // 무명메소드
            // 기본형태는  delegate *** (int p) {본문}; 이다.
            // 이름이 없어서, 무명메소드이다. 기본적으로 delegate를 앞에 쓰고 마디를 만든 다음 ;를 찍어 완성한다. 
            // 무명메소드는 delegate 타입에 무명메소드 자체를 할당할 수 있다.
            RunDelegate r = delegate (int p) { MessageBox.Show(p.ToString()); };
            r(123);  // 123부분이 int p로들어가서  메세지 박스로 가서 123이 출력되게 된다.

            ExprDelegate expr = delegate (int a, int b)
            {
                return 2 * a + b;
            };
            int result = expr(1, 2);

            button1.Click += Button1_Click; // 아래 적힌대로, inline 무명메소드를 사용해보자.
            button2.Click += delegate (object s, EventArgs ae)
            {
                 MessageBox.Show("Button 2");
            };
        }

        private void Button1_Click(object sender, EventArgs e) // 일반적으로 이벤트 핸들러는 별도의 메소드를 만드렁서 처리를 해주지만, 간단하면 inline 무명메소드로도 만들 수 있다.
        {
            MessageBox.Show("Button 1");
        }// button2 와 같은 경우는 그럼 이게 쓸모 없어지는거다!
    }
}
