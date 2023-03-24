using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace институт
{
    public class Teachers
    {
        public string fio; 
        public string experience; 
        public string[] subjects; 

        public Teachers(string fio, string experience, string[] subjects)
        {
            this.fio = fio;
            this.experience = experience;
            this.subjects = subjects;
        }
        public void Deconstruct(out string ofio, out string oexperience, out string[] osubjects)
        {
            ofio = fio;
            oexperience = experience;
            osubjects = subjects;
        }
    }

    public class Students : Teachers
    {
        public string fios;
        public string[] debts; 

        public Students(string fio, string experience, string[] subjects) : base(fio, experience, subjects)
        {
        }

        public Students(string fio, string experience, string[] subjects, string fios, string[] debts) : base(fio, experience, subjects)
        {

            this.fios = fios;
            this.debts = debts;
        }
        public void Deconstruct(out string ofios, out string[] odebts)
        {
            ofios = fios;
            odebts = debts;
        }
    }
    public class Orders 
    {
        public string options; //преподавателя,персонала,студента,для всех
        public string text; //текст приказа
        public string from; // кто выдал

        public Orders(string options, string text, string from)
        {
            this.options = options;
            this.text = text;
            this.from = from;
        }

        public void Deconstruct(out string ooptions, out string otext, out string ofrom)
        {
            ooptions = options;
            otext =text;
                ofrom = from;
        }
    }
    class Program
    {
        static void Orderforteachers(Orders[] o1) 
        {
            for (int i = 0; i < o1.Length; i++)
            {
                (string ooptions,string otext,string ofrom) = o1[i];
                if (ooptions == "преподавателя")
                {
                    Console.WriteLine($" Для {ooptions}\nТекст приказа\n{otext}\n Выдал:\n{ofrom} ");
                }
            }
        }
        static void Orderfortech(Orders[] o1) 
        {
            for (int i = 0; i < o1.Length; i++)
            {
                (string ooptions, string otext, string ofrom) = o1[i];
                if (ooptions == "персонала")
                {
                    Console.WriteLine($" Для {ooptions}\nТекст приказа\n{otext}\n Выдал:\n{ofrom} ");
                }
            }
        }
        static void Orderforstudents(Orders[] o1) 
        {
            for (int i = 0; i < o1.Length; i++)
            {
                (string ovariants, string otext, string ofrom) = o1[i];
                if (ovariants == "Студентов")
                {
                    Console.WriteLine($" Для {ovariants}\nТекст приказа\n{otext}\n Выдал:\n {ofrom} ");
                }
            }
        }
        static void Ordersforall(Orders[] o1) 
        {
            for (int i = 0; i < o1.Length; i++)
            {
                (string ovariants, string otext, string ofrom) = o1[i];
                if (ovariants == "Для всех")
                {
                    Console.WriteLine($"Для {ovariants}\nТекст приказа\n{otext}\n Выдал:\n {ofrom} ");
                }
            }
        }
        static void Exp(Teachers[] o2) 
        {
            Console.WriteLine("Bведите Фио преподавателя");
            string search = Console.ReadLine();
            for (int i = 0; i < o2.Length; i++)
            {
                (string ofio, string oexperience, string[] osubjects) = o2[i];
                if (ofio == search)
                {
                    Console.WriteLine($"У преподавателя {ofio} \n стаж работы \n {oexperience} ");
                }
            }
        }
        static void Disciplines(Teachers[] o2) 
        {
            Console.WriteLine("Bведите Фио преподавателя");
            string search = Console.ReadLine();
            for (int i = 0; i < o2.Length; i++)
            {
                (string ofio, string oexperience, string[] osubjects) = o2[i];
                if ((ofio == search))
                {
                    Console.WriteLine($"Преподаватель {ofio} \nведет: ");
                    for (int j = 0; j < osubjects.Length; j++)
                    {
                        Console.WriteLine($" {osubjects[j]}");
                    }
                }
            }
        }
        static void Sdebts(Students[] o3)
        {
            Console.WriteLine("Bведите Фио преподавателя");
            string search = Console.ReadLine();
            Console.Clear();
            for (int i = 0; i < o3.Length; i++)
            {
                (string ofio, string ofios, string[] odebts) = o3[i];
                if (ofio == search)
                {
                    Console.WriteLine($"Долги студентов у преподавателя {ofio}: \n Студент {ofios}:");
                    for (int j = 0; j < odebts.Length; j++)
                    {
                        Console.WriteLine($"{odebts[j]}");
                    }
                }
            }
        }
        static void Studentvv(int v, Students[] o3) // ввод должников
        {
            string fio;
            string fios;
            for (int i = 1; i < v + 1; i++)
            {
                Console.WriteLine($"Всего студентов должников:{i}");
                Console.WriteLine("Bведите фио студентa");
                fios = Console.ReadLine();
                Console.WriteLine("Bведите фио препода");
                fio = Console.ReadLine();
                Console.WriteLine($"Kоличество долгов студента {fios} по дисциплинам");
                int n = int.Parse(Console.ReadLine());
                string[] debts = new string[n + 1];

                for (int j = 1; j < n + 1; j++)
                {
                    Console.WriteLine($"{j} дисциплина"); ;
                    string q = Console.ReadLine();
                    debts[j] = q;
                }
                Students k = new Students(fio, fios, debts);
                o3[i - 1] = k;
                Console.Clear();
            }
        }
        static void Teachersvv(int w, Teachers[] o3) 
        {
            string fio;
            string experience;

            for (int i = 1; i < w + 1; i++)
            {
                Console.WriteLine($"Bвод {i} Преподавателя");
                Console.WriteLine("Bведите Фио преподавателя");
                fio = Console.ReadLine();
                Console.WriteLine("введите стаж преподавателя");
                experience = Console.ReadLine();
                Console.WriteLine($"сколько дисциплин ведет {fio}");
                int n = int.Parse(Console.ReadLine());
                string[] subjects = new string[n + 1];
                for (int j = 1; j < n + 1; j++)
                {
                    Console.WriteLine($"{j} дисциплинa");
                    string a = Console.ReadLine();
                    subjects[j] = a;
                }
                Teachers k = new Teachers(fio, experience, subjects);
                o3[i - 1] = k;
                Console.Clear();
            }

        }
        static void Ordervv(int a, Orders[] o1) //ввод приказов
        {
            string options;
            string text;
            string from;
            for (int i = 1; i < a + 1; i++)
            {
                Console.WriteLine($"Bвод {i} приказа");
                Console.WriteLine("Для кого приказ (Преподавателя/Студентов/персонала/Для всех)");
                options = Console.ReadLine();
                Console.WriteLine("Текст программы ");
                text = Console.ReadLine();
                Console.WriteLine("Кто выдал ?");
                from = Console.ReadLine();
                Orders k = new Orders(options, text, from);
                o1[i - 1] = k;
                Console.Clear();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Сколько преподавателей?");
            int w = int.Parse(Console.ReadLine());
            Teachers[] o2 = new Teachers[w];

            Console.WriteLine("Сколько студентов?");
            int v = int.Parse(Console.ReadLine());
            Students[] o3 = new Students[v];

            Console.WriteLine("Сколько приказов?");
            int a = int.Parse(Console.ReadLine());

            Orders[] o1 = new Orders[a];
            Teachersvv(w, o2);
            Studentvv(v, o3);
            Ordervv(a, o1);
            bool key = true;
            while (key== true)
            {
                Console.Clear();
                string[] menu = new string[3] {"Приказы", "Преподаватели", "Выход" };
                Console.WriteLine($"{menu[0]}\n{menu[1]}\n{menu[2]}");
                Console.SetCursorPosition(30, 0);
              
                bool t = true;
                bool x= true;
                for (int i = 0; t == true;)
                {
                    ConsoleKeyInfo o = Console.ReadKey(true);
                    if (o.Key == ConsoleKey.Enter && i == 0)
                    {
                        Console.Clear();
                        string[] menu1 = new string[4] { "Для преподавателя", "Для тех персонала", "Для студентов ", "Для всех" };
                        Console.WriteLine($"{menu1[0]}\n{menu1[1]}\n{menu1[2]}\n{menu1[3]}");
                        Console.SetCursorPosition(30, 0);
                        t = true;
                        int j = 0;
                        while (t == true)
                        {
                            ConsoleKeyInfo info = Console.ReadKey(true);
                            if (info.Key == ConsoleKey.Enter && j == 0)
                            {
                                Console.Clear();
                                Orderforteachers(o1);
                                Thread.Sleep(3000);
                                t = false;
                            }
                            else if (info.Key == ConsoleKey.Enter && j == 1)
                            {
                                Console.Clear();
                                Orderfortech(o1);
                                Thread.Sleep(3000);
                                t = false;
                            }
                            else if (info.Key == ConsoleKey.Enter && j == 2)
                            {
                                Console.Clear();
                                Orderforstudents(o1);
                                Thread.Sleep(3000);
                                t = false;
                            }
                            else if (info.Key == ConsoleKey.Enter && j == 3) 
                            {
                                Console.Clear();
                                Ordersforall(o1);
                                Thread.Sleep(3000);
                                t = false;
                            }
                            // управление консоли
                            else if ((info.Key == ConsoleKey.DownArrow && j == 3) || (info.Key == ConsoleKey.UpArrow && j == 1))
                            {
                                Console.SetCursorPosition(35, 0);
                                j = 0;
                            }
                            else if ((info.Key == ConsoleKey.DownArrow && j == 0) || (info.Key == ConsoleKey.UpArrow && j == 2))
                            {
                                Console.SetCursorPosition(35, 1);
                                j = 1;
                            }
                            else if ((info.Key == ConsoleKey.DownArrow && j == 1) || (info.Key == ConsoleKey.UpArrow && j == 3))
                            {
                                Console.SetCursorPosition(35, 2);
                                j = 2;
                            }
                            else if ((info.Key == ConsoleKey.DownArrow && j == 2) || (info.Key == ConsoleKey.UpArrow && j == 0))
                            {
                                Console.SetCursorPosition(35, 3);
                                j = 3;
                            }
                        }
                    }
                    else if (o.Key == ConsoleKey.Enter && i == 1)//Выбор по преподавателям
                    {
                        Console.Clear();
                        string[] menu2 = new string[4] { "Долги студентов", "Стаж работы", "Дисциплина", "Тыкните на Enter для выхода" };
                        Console.WriteLine($"{menu2[0]}\n{menu2[1]}\n{menu2[2]}\n{menu2[3]}");
                        Console.SetCursorPosition(30, 0);
                        int k = 0;
                        x = true;
                        while (x == true)
                        {
                            ConsoleKeyInfo to1 = Console.ReadKey(true);
                            if (to1.Key == ConsoleKey.Enter && k == 0) // Долги студентов
                            {
                                Console.Clear();
                                Sdebts(o3);
                                Thread.Sleep(3000);
                                x = false;
                            }
                            if (to1.Key == ConsoleKey.Enter && k == 1) //Стаж работы
                            {
                                Console.Clear();
                                Exp(o2);
                                Thread.Sleep(3000);
                                x= false;
                            }
                            if (to1.Key == ConsoleKey.Enter && k == 2) // Дисциплина
                            {
                                Console.Clear();
                                Disciplines(o2);
                                Thread.Sleep(3000);
                                x= false;
                            }
                            if (to1.Key == ConsoleKey.Enter && k == 3) // Дисциплина
                            {
                                Console.Clear();
                                Thread.Sleep(3000);
                                x= false;
                            }

                            else if ((to1.Key == ConsoleKey.DownArrow && k == 3) || (to1.Key == ConsoleKey.UpArrow && k == 1))
                            {
                                Console.SetCursorPosition(20, 0);
                                k = 0;
                            }
                            else if ((to1.Key == ConsoleKey.DownArrow && k == 0) || (to1.Key == ConsoleKey.UpArrow && k == 2))
                            {
                                Console.SetCursorPosition(20, 1);
                                k = 1;
                            }
                            else if ((to1.Key == ConsoleKey.DownArrow && k == 1) || (to1.Key == ConsoleKey.UpArrow && k == 3))
                            {
                                Console.SetCursorPosition(20, 2);
                                k = 2;
                            }
                            else if ((to1.Key == ConsoleKey.DownArrow && k == 2) || (to1.Key == ConsoleKey.UpArrow && k == 0))
                            {
                                Console.SetCursorPosition(40, 3);
                                k = 3;
                            }
                        }
                    }
                   else if (o.Key == ConsoleKey.Enter && i == 2)//выход
                    {
                        Console.Clear();
                        Console.WriteLine("Можно автомат, очень надооо ^_^");
                        Environment.Exit(0);
                    }


                    else if ((o.Key == ConsoleKey.DownArrow && i == 3) || (o.Key == ConsoleKey.UpArrow && i == 1))
                    {
                        Console.SetCursorPosition(20, 0);
                        i = 0;
                    }
                    else if ((o.Key == ConsoleKey.DownArrow &&i== 0) || (o.Key == ConsoleKey.UpArrow && i == 2))
                    {
                        Console.SetCursorPosition(20, 1);
                        i = 1;
                    }
                    else if ((o.Key == ConsoleKey.DownArrow &&i == 1) || (o.Key == ConsoleKey.UpArrow && i == 3))
                    {
                        Console.SetCursorPosition(20, 2);
                        i = 2;
                    }
                   

                }
            }
        }
    }
}


