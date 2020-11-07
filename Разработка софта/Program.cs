using System;
using Worker;

namespace Разработка_софта
{
    class Program
    {
        static void Main(string[] args)
        {
            SomeJob<Worker.Worker> job = new SomeJob<Worker.Worker>("Шарага");
            bool alive = true;
            
            while(alive)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("1. Додати робітника \t 2. Додати робочі години робітникові \n 3. Переглянути інформацію робітника \t 4. Нарахувати відсотки \t 5. Вийти");
                Console.WriteLine("Введіть номер пункут: ");
                Console.ForegroundColor = color;
                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());
                    
                    switch(command)
                    {
                        case 4:
                            Calculation(job);
                            break;
                        case 1:
                            HirengWorker(job);
                            break;
                        case 2:
                            AddWorkHourse(job);
                            break;
                        case 3:
                            Show(job);
                            break;
                        case 5:
                            alive = false;
                            continue;
                    }
                }
                catch (Exception ex)
                {
                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }
            }
        }

        private static void HirengWorker(SomeJob<Worker.Worker> job)
        {
            Console.WriteLine("Вкажіть статуc раба: ");
            Console.WriteLine("Menager \t Employee \t Freelancer");
            string status = Console.ReadLine();
            Console.WriteLine("Вкажіть зарплату раба: ");
            int sal = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Вкажіть ім'я для раба: ");
            string name = Console.ReadLine();
            Console.WriteLine("Вкажіть премію для раба: ");
            int pr = Convert.ToInt32(Console.ReadLine());

            Status st = Status.Employee;
            if (status == "Menager")
                st = Status.Manager;
            else if (status == "Employee")
                st = Status.Employee;
            else if (status == "FreeLancer")
                st = Status.FreeLancer;
            else Console.WriteLine("Введи блять нормільний статус");

            job.Hiring(st, sal, pr, name,
                addHourseWorkHandler, calcultionHandler, addNewWorkerJandler, showHandler);
        }

        private static void AddWorkHourse(SomeJob<Worker.Worker> job)
        {
            Console.WriteLine("Вкажіть дату додавання годин: ");
            Console.Write("Рік \t");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("\t Місяць \t");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\t День \t");
            int day = Convert.ToInt32(Console.ReadLine());
            DateTime date = new DateTime(year, month, day);

            Console.WriteLine("Вкажіть кількість годин: ");
            int count = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Вкажіть ім'я: ");
            string name = Console.ReadLine();

            job.AddHourse(date, count, name);
        }

        private static void Calculation(SomeJob<Worker.Worker> job)
        {
            Console.WriteLine("Вкажіть премію працівникові");
            int pr = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Вкажіть ім'я працівника: ");
            string name = Console.ReadLine();

            job.Calculetion(pr, name);
        }

        private static void Show(SomeJob<Worker.Worker> job)
        {
            Console.WriteLine("Вкажіть ім'я раба про якого потрібно вивести інфу");
            string name = Console.ReadLine();

            job.Show(name);
        }

        private static void addHourseWorkHandler(object sender, WorkerEventArgs e)
        {
            Console.WriteLine(e.Messege);
        }

        private static void calcultionHandler(object sender, WorkerEventArgs e)
        {
            Console.WriteLine(e.Messege);
        }

        private static void addNewWorkerJandler(object sender, WorkerEventArgs e)
        {
            Console.WriteLine(e.Messege);
        }

        private static void showHandler(object sender, WorkerEventArgs e)
        {
            Console.WriteLine(e.Messege);
        }
    }
}
