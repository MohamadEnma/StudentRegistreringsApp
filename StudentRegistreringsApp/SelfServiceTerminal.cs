using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistreringsApp
{
    internal class SelfServiceTerminal
    {
        private StudentsDbContext dbCtx = new StudentsDbContext();

        public void Terminal()
        {
            Console.WriteLine("\n1 - Läs första inlägg i databasen");
            Console.WriteLine("2 - Läs alla inlägg i databasen");
            Console.WriteLine("3 - Lägg till ett nytt inlägg");
            Console.WriteLine("4 - Avsluta programmet\n");
        }

        public void RunApp()
        {
            Console.WriteLine("- Välkommen till Student Databas Service Terminal - \n");
            Terminal();
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int userInput) && userInput > 0 && userInput < 5)
                {
                    Console.WriteLine("Invalid input");
                }

                switch (userInput)
                {
                    case 1: ReadFirstPost(); break;
                    case 2: ReadAll(); break;
                    case 3: AddNewStudent(); break;
                    case 4: EndApp(); break;
                    default:
                        Console.WriteLine("Ett fel har inträffat.");
                        break;
                }
            }
        }

        public void ReadFirstPost()
        {
            Console.WriteLine(dbCtx.Students?.FirstOrDefault());
            Console.WriteLine("Din var första inlägg i databasen");
            Terminal();
        }

        public void ReadAll()
        {
            if (dbCtx.Students != null)
                foreach (var item in dbCtx.Students)
                {
                    Console.WriteLine(item);
                }
            Console.WriteLine("Slut på databasen");
            Terminal();
        }

        public void AddNewStudent()
        {
            Console.WriteLine("Ange student namn");
            string? name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Student namn kan inte vara tomt.");
                return;
            }

            Console.WriteLine("Ange student Ort");
            string? city = Console.ReadLine();
            if (string.IsNullOrEmpty(city))
            {
                Console.WriteLine("Student ort kan inte vara tomt.");
                return;
            }
            var student = new Student()
            {
                Name = name,
                City = city
            };
            dbCtx.Add(student);
            dbCtx.SaveChanges();
            Console.WriteLine("En ny student har lagts till.");
            Terminal();
        }

        public void EndApp()
        {
            Console.Clear();
            Console.WriteLine("Programet avslutas");
            Environment.Exit(0);
        }
    }
}
