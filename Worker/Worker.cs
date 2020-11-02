using System;
using System.Collections.Generic;
using System.Text;

namespace Worker
{
    public abstract class Worker : IWorker
    {
        protected internal event WorkerStateHandler AddedHourse;

        protected internal event WorkerStateHandler Calculated;

        static int counter = 0;
        protected int days = 0;

        public DateTime WorkTime { get; private set; }
        //Basic salery for worker
        public decimal Salery { get; private set; }
        //Prize for worker
        public int Prize { get; private set; }

        public int Id { get; private set; }
        public Worker(decimal sal, int pr)
        {
            Salery = sal;
            Prize = pr;
            Id = ++counter;
        }


        private void CallEvent(WorkerEventArgs e, WorkerStateHandler handler)
        {
            if (e != null)
                handler?.Invoke(this, e);
        }

        protected virtual void OnAddedHourse(WorkerEventArgs e)
        {
            CallEvent(e, AddedHourse);
        }
        protected virtual void OnCalculated(WorkerEventArgs e)
        {
            CallEvent(e, Calculated);
        }

        public virtual void AddWorkTime( DateTime dateTime)
        {
            if(WorkTime.AddHours(dateTime.Hour) <= 24)

        }
    }
}
