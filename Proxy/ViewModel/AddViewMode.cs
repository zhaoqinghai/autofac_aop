using System;
using System.Collections.Generic;
using System.Text;
using Proxy.Interface;

namespace Proxy.ViewModel
{
    public class AddViewMode
    {
        public IAdd DependenceService { get; set; }

        public void ExcuteAdd(int a, int b)
        {
            DependenceService.Add(a,b);
        }
    }
}
