using System;
using System.Collections.Generic;
using System.Text;

namespace Worker
{
    public class FreeLancer : Worker
    {
        public FreeLancer(decimal sal, int pr, string name, List<ModelWorker> user) : base(sal, pr, name, user)
        { }
        public override void AddWorkTime(DateTime date, int dateTime)
        {
            if(date.AddDays(2) >= DateTime.Now)
                base.AddWorkTime(date, dateTime);
        }
    }
}
