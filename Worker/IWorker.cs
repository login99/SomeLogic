using System;
using System.Collections.Generic;
using System.Text;

namespace Worker
{
    interface IWorker
    {
        public void AddWorkTime(DateTime worktime);
        public void Show();
    }
}
