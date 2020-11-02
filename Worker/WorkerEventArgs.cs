using System;

namespace Worker
{
    public delegate void WorkerStateHandler(object sender, WorkerEventArgs e);
    public class WorkerEventArgs 
    {
        public string Messege { get; private set; }

        public string Name { get; private set; }

        public DateTime StartWorkTime { get; private set; }

        public DateTime EndWorkTime { get; private set; }

        public int NumberOfHourse { get; private set; }

        public decimal Salery { get; private set; }

        public WorkerEventArgs(string mes, DateTime startTime, DateTime endTime, int hourse, string name, decimal sal)
        {
            Messege = mes;
            StartWorkTime = startTime;
            EndWorkTime = endTime;
            NumberOfHourse = hourse;
            Salery = sal;
            this.Name = name;
        }
    }
}
