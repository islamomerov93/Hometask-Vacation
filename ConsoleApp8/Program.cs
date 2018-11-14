using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker[] workers = new Worker[5];
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    Console.Write((i + 1) + ". Worker's name           :   ");
                    var name = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(name)) throw new Exception("Invalide values . Enter again : ");
                    Console.Write((i + 1) + ". Worker's surname        :   ");
                    var surname = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(name)) throw new Exception("Invalide values . Enter again : ");
                    Console.Write((i + 1) + ". Worker's position       :   ");
                    var position = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(name)) throw new Exception("Invalide values . Enter again : ");
                    Console.Write((i + 1) + ". The year of employement :   ");
                    var check = Console.ReadLine();
                    if (!uint.TryParse(check, out uint yearOfStart)) throw new Exception("Invalide values . Enter again : ");
                    workers[i] = new Worker(name, surname, position, yearOfStart);
                    Console.WriteLine();
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"Enter worker {i + 1}");
                    i--;
                }
            }
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Worker's name and surname               : {workers[i].Name} {workers[i].Surname}");
                    Console.WriteLine($"Worker's position                       : {workers[i].Position}");
                    Console.WriteLine($"Worker's work experience                : {workers[i].WorkExperience()}");
                    Console.WriteLine($"Worker's vacation days for current year : {workers[i].Vacation()}\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Can't show anything due to errors : {ex.Message}");
            }

        }
    }
    class Worker
    {
        string name, surname, position = default(string);
        uint yearOfStart = default(uint);
        public string Name
        {
            get { return name; }
        }
        public string Surname
        {
            get { return surname; }
        }
        public string Position
        {
            get { return position; }
        }
        public uint YearOfStart
        {
            get { return yearOfStart; }
            set
            {
                if (value <= DateTime.Now.Year && value > (DateTime.Now.Year - 45)) yearOfStart = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public Worker(string name, string surname, string position, uint yearOfStart)
        {
            this.name = name;
            this.surname = surname;
            this.position = position;
            YearOfStart = yearOfStart;
        }
        public uint WorkExperience() { return (uint)DateTime.Now.Year - yearOfStart; }
        public uint Vacation()
        {
            if (WorkExperience() > 0 && WorkExperience() <= 3) return 30;
            if (WorkExperience() > 3 && WorkExperience() <= 7) return 33;
            if (WorkExperience() > 7 && WorkExperience() <= 10) return 35;
            if (WorkExperience() > 10) return 40;
            return 0;
        }
    }
}