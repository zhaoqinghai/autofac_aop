using System;
using System.Collections.Generic;
using System.Text;
using Proxy.Interface;
using Proxy.Model;
using Proxy.Proxy;

namespace Proxy.Service
{
    public class Add : IAdd
    {
        
        void IAdd.Add(int a, int b)
        {
            Console.WriteLine($"{a}+{b}={a+b}");
        }
    }
}
