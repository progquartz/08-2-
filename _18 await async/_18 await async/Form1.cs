using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18_await_async
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Run();
        }

        private async void Run()
        {
            // 동기
            int sum = LongCalc(10); // 이런식으로 코딩을 한다.
            label1.Text = sum.ToString(); // 실행하면 렉 졸라 걸린다. 이러한 ui 횡 이슈를 막기 위해서는 비동기 처리를 해야만 한다.

            // 비동기
            // 비동기 방식으로 작업 스레드가 롱 컬크를 실행하도록 하기 위해서는 task 클래스를 사용한다.
            var task1 = Task.Run(() => LongCalc(10)); // taskrun에소드는 thread pool에서 작업 스레드를 할당받아서 long calc 라는 메소드를 실행하면서 task 에 대한 객채를 task1에 return 한다.
                                                      // 그리고 이 task 가 끝날떄까지 wait 하게 await를 사용한다.
                                                      // await를 사용하기 위해서는 메소드의 선언 부분에 async라는걸 꼭 넣어야한다.
                                                      // 이 메소드 전체가 비동기 메소드임을 적은것이며, 최소 1개의 비동기 메소드가 있음을 보이는것이다.

            sum = await task1;
            label1.Text = sum.ToString();
        }

        private int LongCalc(int n) // 실행하는데 오랜 시간이 걸리는 메소드.
        {
            int result = 0;
            for(int i = 1; i <= n; i++)
            {
                result += i;
                // ... 긴 작업.
                Thread.Sleep(1000); // 걸린다고 주장하는걸 하기 위해 1초 대기.
            }
            return result;

        }
    }
}
