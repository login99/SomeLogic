using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Worker
{
    public enum Status
    {
        Manager,
        Employee,
        FreeLancer
    }
    public class SomeJob<T> where T : Worker
    {
        T[] allEmployees;

        public string Name { get; private set; }

        public SomeJob(string name)
        {
            this.Name = name;
        }

        public void Hiring(Status st, decimal sal, int prize, string Name,WorkerStateHandler addHourseWork,
            WorkerStateHandler calcultion, WorkerStateHandler addNewWorker, WorkerStateHandler show)
        {
            T newWorker = null;
            switch(st)
            {
                case Status.Manager:
                    newWorker = new Maneger(sal, prize, Name, new List<ModelWorker>
                    { new ModelWorker(){ WorkTime = DateTime.Now, NumberOfHourse = 8,
                        Message = "Перший робочий день"} }) as T;
                    break;
                case Status.Employee:
                    newWorker = new Employee(sal, prize, Name, new List<ModelWorker>
                    { new ModelWorker(){ WorkTime = DateTime.Now, NumberOfHourse = 8,
                        Message = "Перший робочий день"} }) as T;
                    break;
                case Status.FreeLancer:
                    newWorker = new FreeLancer(sal, prize, Name, new List<ModelWorker>
                    { new ModelWorker(){ WorkTime = DateTime.Now, NumberOfHourse = 8,
                        Message = "Перший робочий день"} }) as T;
                    break;
            }
            if (newWorker == null)
                throw new Exception("Помилка найму раба");
            if(allEmployees == null)
                allEmployees = new T[] {newWorker};
            else
            {
                var temp = allEmployees;
                allEmployees = new T[temp.Length + 1];
                allEmployees = temp;
                allEmployees[temp.Length] = newWorker;
            }

            newWorker.AddedHourse += addHourseWork;
            newWorker.Calculated += calcultion;
            if (st == Status.Manager)
                newWorker.AddedWorker += addNewWorker;
            newWorker.AddWorker();
        }

        public void AddHourse(DateTime date, int numberOfHourse, string name)
        {
            var temp = allEmployees.Where(t => t.Name == name);
            if (temp == null)
                throw new Exception("Раба з таким іменем не знайдено");
            foreach(var person in temp)
            {
                person.AddWorkTime(date, numberOfHourse);
            }
        }

        public void Calculetion(int prize, string name)
        {
            var temp = allEmployees.Where(t => t.Name == name);
            if (temp == null)
                throw new Exception("Раба з таким іменем не знайдено");
            foreach (var person in temp)
            {
                person.Calculate();
            }
        }

        public void Show(string Name)
        {
            var temp = allEmployees.Where(t => t.Name == Name);
            if (temp == null)
                throw new Exception("Раба з таким іменем не знайдено");
            foreach (var person in temp)
            {
                person.Show();
            }
        }
    }
}
