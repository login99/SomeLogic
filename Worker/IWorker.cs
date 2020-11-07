using System;
using System.Collections.Generic;
using System.Text;

namespace Worker
{
    interface IWorker
    {
        public void AddWorkTime(DateTime workTime, int worktime);
        public void Show();
    }
}
