using System;

namespace Worker
{
    public delegate void WorkerStateHandler(object sender, WorkerEventArgs e);
    public class WorkerEventArgs 
    {
        public string Messege { get; private set; }
        public int NumberOfHourse { get; private set; }
        public WorkerEventArgs(string mes, int hourse)
        {
            Messege = mes;
            NumberOfHourse = hourse;
        }
    }
}
