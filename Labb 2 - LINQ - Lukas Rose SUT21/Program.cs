using Labb_2___LINQ___Lukas_Rose_SUT21.Data;
using Labb_2___LINQ___Lukas_Rose_SUT21.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Labb_2___LINQ___Lukas_Rose_SUT21
{
    class Program
    {
        static void Main(string[] args)
        {
            Labb2DbContext context = new Labb2DbContext();

            //Ämne prog1 = new Ämne { ÄmnesNamn = "Programmering 1" };
            //Ämne eng8 = new Ämne { ÄmnesNamn = "Engelska 8" };
            //Ämne pysk3 = new Ämne { ÄmnesNamn = "Psykologi 3" };
            //Ämne matte7 = new Ämne { ÄmnesNamn = "Matte 7" };
            //Ämne prog2 = new Ämne { ÄmnesNamn = "Programmering 2" };

            //context.Ämnen.AddRange(prog1, prog2, pysk3, matte7, eng8);

            //Lärare lars = new Lärare { FNamn = "Lars", LNamn = "Gunnarson" };
            //lars.Ämnen.AddRange(new List<Ämne> { prog1, prog2 });
            //Lärare lina = new Lärare { FNamn = "Lina", LNamn = "Assarsson" };
            //lina.Ämnen.AddRange(new List<Ämne> { pysk3, eng8 });
            //Lärare constantine = new Lärare { FNamn = "Constantine", LNamn = "Hellberg" };
            //constantine.Ämnen.Add(matte7);

            //context.Lärare.AddRange(lars, lina, constantine);

            //Student s1 = new Student { FName = "Claes", LName = "Bengtsson" };
            //Student s2 = new Student { FName = "Benny", LName = "Börjesson" };
            //Student s3 = new Student { FName = "Laura", LName = "Klasson" };
            //Student s4 = new Student { FName = "Hilda", LName = "Bernadottir" };
            //Student s5 = new Student { FName = "Jennifer", LName = "Halldén" };
            //Student s6 = new Student { FName = "Karsten", LName = "Jensen" };
            //Student s7 = new Student { FName = "Bentley", LName = "Carlsson" };
            //Student s8 = new Student { FName = "Carola", LName = "Carlsson" };
            //Student s9 = new Student { FName = "Astrid", LName = "Bildt" };
            //Student s10 = new Student { FName = "Ulrika", LName = "Berggren" };

            //context.Studenter.AddRange(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10);

            //Klass sun22 = new Klass { KlassNamn = "SUN22" };
            //sun22.Elever.AddRange(new List<Student> { s1, s2, s3, s4, s5 });
            //sun22.Ämnen.AddRange(new List<Ämne> { prog1, matte7, eng8 });
            //Klass sat21 = new Klass { KlassNamn = "SAT21" };
            //sat21.Ämnen.AddRange(new List<Ämne> { prog2, pysk3 });
            //sat21.Elever.AddRange(new List<Student> { s6, s7, s8, s9, s10 });

            //context.Klasser.AddRange(sun22, sat21);

            //context.SaveChanges();

            Reset(context);
            Intro();

            //-----------------------------------------------------------------------------------------------------------------  

            Console.Clear();
            PrintCyan("Visa lärare som undervisar matte: ");
            foreach (var item in from ämnen in context.Ämnen where ämnen.ÄmnesNamn == "Matte 7"
                                 join lär in context.Lärare on ämnen.LärareID equals lär.ID
                                 select lär)
            {
                PrintYellow(item.FNamn + " " + item.LNamn);
            }
            Console.ReadLine();

            //-----------------------------------------------------------------------------------------------------------------  

            Console.Clear();
            PrintCyan("Visa alla elever och deras lärare: ");        
            foreach (var s in from s in context.Studenter
                              join k in context.Klasser on s.KlassID equals k.ID
                              select new { sNamn = $"{s.FName} {s.LName}", klNamn = k.KlassNamn, klID = k.ID })
            {
                PrintYellow(s.sNamn + new string(' ', 23-s.sNamn.Length) + " - Klass: " + s.klNamn);

                foreach (var item in from ä in context.Ämnen
                                     where ä.KlassID == s.klID
                                     join l in context.Lärare on ä.LärareID equals l.ID
                                     select new { lärNamn = $"{l.FNamn} {l.LNamn}", ämNamn = ä.ÄmnesNamn })
                {
                    Console.SetCursorPosition(3, Console.CursorTop);
                    Console.WriteLine($"{item.lärNamn} {new string(' ', 20 - item.lärNamn.Length)}- {item.ämNamn}");
                }
                Console.WriteLine();
            }
            Console.ReadLine();

            //-----------------------------------------------------------------------------------------------------------------  

            Console.Clear();
            PrintCyan("Resultat av att kolla om tabellen ''Ämnen'' Contains(programmering 1): ");
            PrintYellow(((from ä in context.Ämnen select ä.ÄmnesNamn).ToList().Contains("Programmering 1")).ToString() + "\n");
            Console.ReadLine();

            //-----------------------------------------------------------------------------------------------------------------  

            Console.Clear();
            PrintCyan("Skriv ut alla ämnen:");
            foreach (var ä in context.Ämnen) { Console.WriteLine(ä.ÄmnesNamn); }

            PrintCyan("\nSkriv ut alla ämnen efter att ha ändrat Programmering 2 till OOP: ");
            foreach(var ä in from ä in context.Ämnen where ä.ÄmnesNamn == "Programmering 2" select ä) { ä.ÄmnesNamn = "OOP"; }
            context.SaveChanges();
            foreach (var ä in context.Ämnen) { Console.WriteLine(ä.ÄmnesNamn); }
            Console.ReadLine();

            //-----------------------------------------------------------------------------------------------------------------  

            Console.Clear();
            PrintCyan("Skriv ut lärare i kursen Psykologi 3: ");
            foreach (var item in from ä in context.Ämnen where ä.ÄmnesNamn == "Psykologi 3"
                                 join l in context.Lärare on ä.LärareID equals l.ID
                                 select l)
            {
                PrintYellow($"{item.FNamn} {item.LNamn}");
            }

            foreach (var item in from ä in context.Ämnen where ä.ÄmnesNamn == "Psykologi 3" select ä) { item.LärareID = 3; }
            context.SaveChanges();

            PrintCyan("\nSkriv ut en elev som har Psykologi 3 efter att ha bytt kursens lärare: ");
            foreach (var s in from s in context.Studenter where s.ID == 6
                              join k in context.Klasser on s.KlassID equals k.ID
                              select new { sNamn = $"{s.FName} {s.LName}", klNamn = k.KlassNamn, klID = k.ID })
            {
                PrintYellow(s.sNamn + new string(' ', 23 - s.sNamn.Length) + " - Klass: " + s.klNamn);
                foreach (var item in from ä in context.Ämnen
                                     where ä.KlassID == s.klID
                                     join l in context.Lärare on ä.LärareID equals l.ID
                                     select new { lärNamn = $"{l.FNamn} {l.LNamn}", ämNamn = ä.ÄmnesNamn })
                {
                    Console.SetCursorPosition(3, Console.CursorTop);
                    Console.WriteLine($"{item.lärNamn} {new string(' ', 20 - item.lärNamn.Length)}- {item.ämNamn}");
                }
                Console.WriteLine("\nTryck Enter för att avsluta.");
            }
            Console.ReadLine();

            //-----------------------------------------------------------------------------------------------------------------  
        }
        public static void PrintYellow(string input)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(input);
            Console.ResetColor();
        }
        public static void PrintCyan(string input)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(input);
            Console.ResetColor();
        }
        public static void Reset(Labb2DbContext context)
        {
            foreach (var ä in from ä in context.Ämnen where ä.ÄmnesNamn == "OOP" select ä) { ä.ÄmnesNamn = "Programmering 2"; }
            foreach (var item in from ä in context.Ämnen where ä.ÄmnesNamn == "Psykologi 3" select ä) { item.LärareID = 2; }
            context.SaveChanges();
        }

        public static void Intro()
        {
            Console.WindowHeight = 47;
            Console.WriteLine("Hej!\n\nProgrammet kommer visa exempel på olika sätt använda en databas med hjälp av LINQ." +
                              "\nTryck Enter efter varje exemepel för att gå vidare till nästa\n\n" +
                              "Tryck Enter för att börja!");
            Console.ReadLine();
        }
    } 
}
