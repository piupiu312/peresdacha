using System;
using N8;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Threading;

namespace N8
{
    class Program
    {
        static void Main(string[] args)
        {
            start();
        }
        static void start()
        {
            Thread thread = new Thread(x =>
            {
                int time = 1;
                while (time != 61)
                {
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("  ");
                    Console.WriteLine(time);
                    Thread.Sleep(1000);
                    time++;
                }
            });
            Thread thread2 = new Thread(x =>
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                Thread.Sleep(60000);
                stopWatch.Stop();
            });
            Console.WriteLine("Введите ваш никнейм или ник");
            Info users = new Info();
            users.Name = Console.ReadLine();
            string nam = users.Name;
            Console.Clear();
            Console.WriteLine("Когда будете готовы нажмите энтер и вы должны будете начать печатать текст");
            ConsoleKeyInfo clavisha = Console.ReadKey();
            if (clavisha.Key == ConsoleKey.Enter)
            {
                
                thread.Start();
                thread2.Start();
                Console.SetCursorPosition(0, 1);
                string text = ("На ферме большой птичий двор. На дворе гуляют гуси и гусята, утки и утята, куры и цыплята. Птиц кормит птичница бабушка Настя. Ей помогают Таня и Катя. Они кормят гусят, утят и цыплят.");
                Console.WriteLine(text);
                int i = 0;
                while (thread2.IsAlive)
                {
                    char c = Console.ReadKey(true).KeyChar;
                    if (c == text[i])
                    {
                        Console.SetCursorPosition(i, 1);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(c);
                        Console.ResetColor();
                        i++;
                    }
                }
                users.Min = i;
                users.Sec = i / 60;
                Console.SetCursorPosition(0, 13);
                Console.WriteLine($"Было введено символов {i}, введено символов в минуту {users.Min}, введено символов в секунду {users.Sec}");
                Console.ReadKey();

                Tabl men = new Tabl();
                men.save(users);
                Console.ReadKey();
                Console.Clear();
                start();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Программа была завершена");
            }
        }
    }
}
