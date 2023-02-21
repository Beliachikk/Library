using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace что_то_сложное_со_списком
{
    public class Book
    {
        public string fio;
        public string name;
        public string idd;
        public string yearizd;
        public string namecompany;
        public string genre;
        public string[] d1d2;//массив, где чередуются дата выдачи и сдачи// если нет даты сдачи ставим -,те книга на руках
        public Book(string fio, string name, string idd, string yearizd, string namecompany, string genre, string[] d1d2) // конструктор  Book(тип данных Book)
        {
            this.fio = fio;
            this.name = name;
            this.idd = idd;
            this.yearizd = yearizd;
            this.namecompany = namecompany;
            this.genre = genre;
            this.d1d2 = d1d2;
        }
        public void Deconstruct(out string ofio, out string oname, out string oidd, out string oyearizd, out string onamecompany, out string ogenre, out string[] od1d2)// деконструктор
        {
            ofio = fio;
            oname = name;
            oidd = idd;
            oyearizd = yearizd;
            onamecompany = namecompany;
            ogenre = genre;
            od1d2 = d1d2;
        }//эта штука нужна, чтобы из переменной Book вытаскивать всякие элементики типа фио, ...
    }


    class Cards// тут выборки
    {
        static void Company(Book[] a)//каждый элемент этого массива представляет тип Book(который типа одна большая переменная)
        {
            Console.WriteLine("Введите издательство ");
            string company = Console.ReadLine();
            for (int i = 0; i < a.Length; i++)
            {
                (string ofio, string oname, string oidd, string oyearizd, string onamecompany, string ogenre, string[] od1d2) = a[i];
                if (onamecompany == company)
                {
                    Console.WriteLine($"{ofio} {oname} {oidd} {oyearizd} {onamecompany} {ogenre}");
                }
            }

        }
        static void Author(Book[] a)
        {
            Console.WriteLine("Введите авторааааа");
            string auth = Console.ReadLine();
            for (int i = 0; i < a.Length; i++)
            {
                (string ofio, string oname, string oidd, string oyearizd, string onamecompany, string ogenre, string[] od1d2) = a[i];
                if (ofio == auth)
                {
                    Console.WriteLine($"{ofio} {oname} {oidd} {oyearizd} {onamecompany} {ogenre}");
                }
            }

        }
        static void Genre(Book[] a)
        {
            Console.WriteLine("Введите жанр");
            string genre = Console.ReadLine();
            for (int i = 0; i < a.Length; i++)
            {
                (string ofio, string oname, string oidd, string oyearizd, string onamecompany, string ogenre, string[] od1d2) = a[i];
                if (ogenre == genre)
                {
                    Console.WriteLine($"{ofio} {oname} {oidd} {oyearizd} {onamecompany} {ogenre}");
                }
            }

        }
        static void OnHands(Book[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                (string ofio, string oname, string oidd, string oyearizd, string onamecompany, string ogenre, string[] od1d2) = a[i];
                if (od1d2[od1d2.Length - 1] == "99.99.9999")// максимально возможный предел интервала
                {
                    Console.WriteLine($"{ofio} {oname} {oidd} {oyearizd} {onamecompany} {ogenre}");
                }
            }
        }
        static void OnHandsNow(Book[] a, string date1, string date2)
        {
            for (int i = 0; i < a.Length; i++)
            {
                (string ofio, string oname, string oidd, string oyearizd, string onamecompany, string ogenre, string[] od1d2) = a[i];
                DateTime dateTime1 = DateTime.Parse(date1);
                DateTime dateTime2 = DateTime.Parse(date2);
                if(dateTime1 != dateTime2&& dateTime1 < dateTime2)
                    Console.WriteLine($"{ofio} {oname} {oidd} {oyearizd} {onamecompany} {ogenre}");
            }
        }
        static void Vvod(int n, Book[] a)
        {
            string fio;
            string name;
            string idd;
            string yearizd;
            string namecompany;
            string genre;
            for (int i = 1; i < n+1; i++)
            {
                Console.WriteLine($"Номер книги {i}");
                Console.WriteLine("Напишите ФИО автора");
                fio = Console.ReadLine();
                Console.WriteLine("Напишите название книги");
                name = Console.ReadLine();
                Console.WriteLine("Напишите идентификационный номер");
                idd = Console.ReadLine();
                Console.WriteLine("Напишите год издания");
                yearizd = Console.ReadLine();
                Console.WriteLine("Напишите наименование издательства");
                namecompany = Console.ReadLine();
                Console.WriteLine("Напишите жанр");
                genre = Console.ReadLine();
                Console.WriteLine("Сколько раз книга была выдана? ");
                int m = 2 * Convert.ToInt32(Console.ReadLine());
                string[] d1d2 = new string[m];
                for (int j = 0; j < m; j += 2)
                {
                    Console.WriteLine("напишите дату выдачи **.**.****");
                    d1d2[j] = Console.ReadLine();
                    Console.WriteLine("напишите дату сдачи **.**.****, если книга не сдана поставьте 0)");

                    string str= Console.ReadLine();
                    if (str == "0")
                    {
                        str = "99.99.9999";
                    }
                    d1d2[j + 1] = str;
                }
                Book k = new Book(fio, name, idd, yearizd, namecompany, genre, d1d2);
                a[i - 1] = k;
                Console.Clear();
            }
        }
        static void Main()
        {
            Console.WriteLine("Сколько будет книг?");
            int n = Convert.ToInt32(Console.ReadLine());
            Book[] a = new Book[n];
            Console.Clear();
            Vvod(n, a);
            bool x = true;
            while (x == true)
            {
                Console.WriteLine("Выборки:\n1. Издательство \n2. Автор \n3. Жанр \n4. Книги на руках \n5. Книги на руках в заданном интервале \n6. Завершение программы");
                int u = Convert.ToInt32(Console.ReadLine());
                if (u == 1)
                {
                    Company(a);
                    Thread.Sleep(3000);
                }
                if (u== 2)
                {
                    Author(a);
                    Thread.Sleep(3000);
                }
                if (u == 3)
                {
                    Genre(a);
                    Thread.Sleep(3000);
                }
                if (u== 4)
                {
                    OnHands(a);
                    Thread.Sleep(3000);
                }
                if (u== 5)
                {
                    Console.WriteLine("Напишите даты интервала в формате **.**.****");
                    string z = Console.ReadLine();
                    string y = Console.ReadLine();
                    OnHandsNow(a, z, y);
                    Thread.Sleep(3000);
                }
                if (u== 6)
                {
                    Console.Clear();
                    Console.WriteLine("Для возобновления поиска, запустите программу еще раз");
                    return;
                    

                }

            }
        }
    }
}