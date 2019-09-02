using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Access_Modifier
{
{
    public class _02_Logger // internal 과 같은 경우에는, 이 어셈블리 내에서 다음의 클래스를 이용할 수 있음에 대해 이야기하는것이고,
                              // 어셈블리란 프로젝트를 빌드를 할경우 생기는 .exe나 .dll 을 두고 이야기하는것이다.
                              // 그 어셈블리 내에서 사용가능하다는것이다. 
                              // 다른 어셈블리에서까지 이를 이용하려면, public 으로 두면 된다. 그렇게 되면 다른 어셈블리에서 로거 클래스들을 접근가능해진다.
                              // 만약 다음과 같이, 다른 프로젝트에서 짓는다면 다른 어셈블리이므로, internal 은 문제가 생긴다. 그런고로 public으로 두었다.
    {
        // 필드
        public string logDirectory;
        private string logFilename;

        public _02_Logger() // 로거 클래스 정의.
        {
            logDirectory = Environment.CurrentDirectory;
            logFilename = "log.txt";
        }

        public string LogDirectory { get { return logDirectory; } }
        // 메서드
        public void LogSuccess(string msg)
        {

        }

        public void LogError(string msg)
        {

        }
    }
}

