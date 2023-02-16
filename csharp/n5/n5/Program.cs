using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using n5;
using System.IO;

namespace n5
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int position;
            Cake cake = new Cake();
            Item circle = new Item("Круг", 500);
            Item square = new Item("Квадрат", 600);
            Item hearth = new Item("Сердце", 800);
            List<Item> shapes = new List<Item>();
            shapes.Add(circle);
            shapes.Add(square);
            shapes.Add(hearth);

            Item small = new Item("Маленький", 1000);
            Item medium = new Item("Средний", 1250);
            Item big = new Item("Большой", 1500);
            List<Item> sizes = new List<Item>();
            sizes.Add(small);
            sizes.Add(medium);
            sizes.Add(big);

            Item vanilla = new Item("Ванильный", 200);
            Item chocolate = new Item("Шоколадный", 300);
            Item caramel = new Item("Карамельный", 300);
            Item berry = new Item("Ягодный", 250);
            Item coconut = new Item("Кокосовый", 350);
            List<Item> taste = new List<Item>();
            taste.Add(vanilla);
            taste.Add(chocolate);
            taste.Add(caramel);
            taste.Add(berry);
            taste.Add(coconut);

            Item one = new Item("Один корж", 200);
            Item two = new Item("Два коржа", 400);
            Item three = new Item("Три коржа", 600);
            Item four = new Item("Четыре коржа", 800);
            List<Item> amount = new List<Item>();
            amount.Add(one);
            amount.Add(two);
            amount.Add(three);
            amount.Add(four);

            Item chocolateGlaze = new Item("Шоколад", 100);
            Item cream = new Item("Карамель", 100);
            Item meringue = new Item("Безе", 150);
            Item berryGlaze = new Item("Ягоды", 200);
            List<Item> glaze = new List<Item>();
            glaze.Add(chocolateGlaze);
            glaze.Add(cream);
            glaze.Add(meringue);
            glaze.Add(berryGlaze);

            Item chocolateDecor = new Item("Шоколадный", 150);
            Item berryDecor = new Item("Ягодный", 150);
            Item creamDecor = new Item("Кремовый", 150);
            List<Item> decor = new List<Item>();
            decor.Add(chocolateDecor);
            decor.Add(berryDecor);
            decor.Add(creamDecor);

            if (!File.Exists("C:\\Users\\Ruslan\\Desktop\\Cakes.txt"))
                File.Create("C:\\Users\\Ruslan\\Desktop\\Cakes.txt");
            while (true)
            {
                position = cake.Menu();
                switch (position)
                {
                    case 3:
                        cake.SecondMenu(shapes);
                        break;
                    case 4:
                        cake.SecondMenu(sizes);
                        break;
                    case 5:
                        cake.SecondMenu(taste);
                        break;
                    case 6:
                        cake.SecondMenu(amount);
                        break;
                    case 7:
                        cake.SecondMenu(glaze);
                        break;
                    case 8:
                        cake.SecondMenu(decor);
                        break;
                }
            }
        }
    }
}
