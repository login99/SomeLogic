using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Worker
{
    public class Maneger : Worker
    {

        public Maneger(decimal sal, int pr, string name, List<ModelWorker> user) : base(sal,pr,name,user)
        {
        }

    }
}
