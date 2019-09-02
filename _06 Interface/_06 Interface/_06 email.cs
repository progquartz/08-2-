using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Interface
{
    class email : _06_Isendable
    {
        private string email = "admin@ppap.com";
        
        public void Send(string msg) // implement 됨.
        {
            Console.WriteLine($"Email {msg} to {email}");

        }

        public bool ValidateEmail()
        {
            //...
            return true;
        }

    }
}
