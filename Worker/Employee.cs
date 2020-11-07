using System;
using System.Collections.Generic;
using System.Text;

namespace Worker
{
    public class Employee : Worker
    {
        public Employee(decimal sal, int pr, string name, List<ModelWorker> user) : base(sal, pr, name, user)
        { }
    }
}
