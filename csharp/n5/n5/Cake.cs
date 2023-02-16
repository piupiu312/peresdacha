using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticalWork5;
using System.IO;
using n5;

namespace n5
{
    public class Cake
    {
        string description;
        int price;
        private int position = 3;
        private ConsoleKeyInfo key;
        private int Sum = 0;
        string Order = "";

        public int Menu()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Добро пожаловать в генератор тортов. Выберите пункты для создания идеального торта ;)");
            Console.WriteLine("Выберите параметр:");
            Console.WriteLine("------------------");
            Console.WriteLine("  Форма торта\n  Размер торта\n  Вкус начинки\n  Количество коржей\n  Глазурь\n  Начинка\n  Конец заказа\n");
            Console.WriteLine("Цена: " + Sum);
            Console.WriteLine("Ваш торт: " + Order);
            Console.SetCursorPosition(0, position);
            Console.Write("->");
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
                Environment.Exit(0);
            if (key.Key == ConsoleKey.UpArrow)
                if (position >= 4)
                position--;
            if (key.Key == ConsoleKey.DownArrow)
                if (position <= 8)
                position++;
            if (position == 9 && key.Key == ConsoleKey.Enter)
                Save(Order, Sum);
            if (key.Key == ConsoleKey.Enter)
                return position;
            return 0;
        }

        public void SecondMenu(List<Item> list)
        {
            int position = 0;
            do
            {
                Console.Clear();
                foreach (Item item in list)
                {
                    Console.WriteLine("  " + item.Name + "   " + item.Price);
                }
                Console.SetCursorPosition(0, position);
                Console.Write("->");
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                    if (position >= 1)
                        position--;
                if (key.Key == ConsoleKey.DownArrow)
                    if (position < list.Count-1)
                        position++;
                
            } while (key.Key != ConsoleKey.Enter);
            Order += list[position].Name + "  " + list[position].Price + "  ";
            Sum += list[position].Price;
        }

        private void Save(string order, int sum)
        {
            File.AppendAllText("C:\\Users\\Ruslan\\Desktop\\Cakes.txt", "Заказ от " + DateTime.Now + "\n\t\t" + order + "\n");
            Order = "";
            Sum = 0;
            position = 3;
            key = Console.ReadKey();
            Menu();
        }
    }   
}
