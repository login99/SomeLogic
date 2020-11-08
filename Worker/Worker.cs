using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Worker
{
    public abstract class Worker : IWorker
    {
        protected internal event WorkerStateHandler AddedHourse;

        protected internal event WorkerStateHandler Calculated;

        protected internal event WorkerStateHandler AddedWorker;

        protected internal event WorkerStateHandler Showed;
        protected List<ModelWorker> User { get; private set; }
        public decimal Salery { get; private set; }
        //Prize for worker
        public double Prize { get; private set; }

        public string Name { get; private set; }
        public Worker(decimal sal, int pr, string name, List<ModelWorker> user)
        {
            Name = name;
            Salery = sal;
            Prize = pr;
            User = user;
        }


        protected void CallEvent(WorkerEventArgs e, WorkerStateHandler handler)
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
        protected virtual void OnAddedWorker(WorkerEventArgs e)
        {
            CallEvent(e, AddedWorker);
        }

        protected virtual void OnShowed(WorkerEventArgs e)
        {
            CallEvent(e, Showed);
        }

        public virtual void AddWorkTime(DateTime date, int dateTime)
        {
            var temp = User.Where(t => t.WorkTime.ToString("dd:MM:yyyy") == date.ToString("dd:MM:yyyy"));
            foreach (ModelWorker t in temp)
            {
                if (t.NumberOfHourse+dateTime < 24)
                {
                    t.NumberOfHourse += dateTime;
                    OnAddedHourse(new WorkerEventArgs($"Додано робочих годин: {dateTime}", dateTime)); 
                }
            }
            
        }
        public virtual void Calculate()
        {
            decimal a = Salery;
            var temp = User.Select(t => t.NumberOfHourse);
            foreach(var t in temp)
                Salery += (decimal)((t - 8) * Prize);
            OnCalculated(new WorkerEventArgs($"Нараховано премію в розмірі{Salery - a}",8));
        }

        public virtual void AddWorker()
        {
            OnAddedWorker(new WorkerEventArgs("Створено робочого чєліка", 8));
        }
        public void Show()
        {
            foreach(var t in User)
            Console.WriteLine($"{t.WorkTime.ToString("dd:MM:yyyy")} {t.NumberOfHourse} {t.Message}");
            OnShowed(new WorkerEventArgs("Вся інфа про даного раба", 8));
        }
    }
}
