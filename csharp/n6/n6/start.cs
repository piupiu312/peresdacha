
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace n6
{

    public class start
    {
        public string RText;
        string Name, Age, Description;
        string way;
        ConsoleKeyInfo Key;
        Boolean Exist;
        List<Model> jsonList;
        string[] wayFormat, wayFormat2;
        char[] chars;
        private void EditText(char[] chars, ConsoleKeyInfo Key)
        {
            int height = 2;
            int width = 0;
            if (Key.Key == ConsoleKey.UpArrow || Key.Key == ConsoleKey.DownArrow)
            {
                Console.SetCursorPosition(width, height);
                ConsoleKeyInfo Hot = Console.ReadKey(true);
                while (Hot.Key != ConsoleKey.Enter)
                {
                    if (Hot.Key == ConsoleKey.UpArrow)
                    {
                        height--;
                        height = height < 2 ? height = 2 : height = height;
                    }
                    else if (Hot.Key == ConsoleKey.DownArrow)
                    {
                        height++;
                        height = height > 4 ? height = 4 : height = height;
                    }
                    else if (Hot.Key == ConsoleKey.RightArrow)
                    {
                        width++;
                    }
                    else if (Hot.Key == ConsoleKey.LeftArrow)
                    {
                        width--;
                    }
                    else if (Hot.Key == ConsoleKey.Backspace)
                    {
                        if (height == 2)
                        {
                            for (int i = 0; i < chars.Length; i++)
                            {
                                if (i == width)
                                {
                                    chars[i] = ' ';
                                }
                            }

                            for (int i = 0; i < chars.Length; i++)
                            {

                            }
                            Console.SetCursorPosition(0, 2);
                            foreach (char item in chars)
                            {
                                Console.Write(item);
                            }
                            Console.ReadLine();
                        }
                    }
                    Console.SetCursorPosition(width, height);
                    Hot = Console.ReadKey(true);
                }
            }
        }
        public void MainMenu()
        {
            Console.WriteLine("Введите путь до файла, указывая при этом формат, который хочется открыть: ");
            Console.WriteLine("-----------------------------------------------------------------------");
            way = Console.ReadLine();

            OpenedFileAsync(way);
        }
        private void OpenedFileAsync(string way)
        {
            Exist = false;
            do
            {
                if (File.Exists(way))
                {
                    Exist = true;
                    Console.Clear();
                    Console.WriteLine("Сохранить файл в одном из 3-ёх форматов: (txt, json, xml) - F1. Закрыть программу - Escape.");
                    Console.WriteLine("-----------------------------------------------------------------------");
                    wayFormat = way.Split(".");

                    RText = File.ReadAllText(way);

                    if (wayFormat[1] == "txt")
                    {
                        Console.WriteLine(RText);
                        chars = RText.ToCharArray();
                    }
                    else if (wayFormat[1] == "json")
                    {
                       jsonList = JsonConverter.DeserializeObject<List<Model>>(RText);
                        foreach (var item in jsonList)
                        {
                            Console.WriteLine(item.Name);
                            Console.WriteLine(item.Age);
                            Console.WriteLine(item.Description);

                            char[] NameChar = (item.Name + "\n").ToCharArray();
                            char[] AgeChar = (item.Age.ToString() + "\n").ToCharArray();
                            char[] DecsChar = item.Description.ToCharArray();

                            chars = NameChar.Concat(AgeChar).Concat(DecsChar).ToArray();
                        }
                    }
                    else if (wayFormat[1] == "xml")
                    {
                        string[] massivName = RText.Split("<Name>");
                        Name = Convert.ToString(massivName[1]);
                        massivName = Name.Split("</Name>");
                        Name = massivName[0];

                        string[] massivAge = RText.Split("<Age>");
                        Age = Convert.ToString(massivAge[1]);
                        massivAge = Age.Split("</Age>");
                        Age = massivAge[0];

                        string[] massivDescription = RText.Split("<Description>");
                        Description = Convert.ToString(massivDescription[1]);
                        massivDescription = Description.Split("</Description>");
                        Description = massivDescription[0];

                        Console.WriteLine(Name);
                        Console.WriteLine(Age);
                        Console.WriteLine(Description);
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка. Файла по этому пути не существует");
                    Console.ReadKey();
                    Console.Clear();
                    MainMenu();
                }
            } while (Exist == false);

            Buttons(wayFormat, chars);
        }
        private void Buttons(string[] wayFormat, char[] chars)
        {
            do
            {
                Key = Console.ReadKey(true);

                if (Key.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Выходим домой...");
                    Environment.Exit(0);
                }
                else if (Key.Key == ConsoleKey.UpArrow || Key.Key == ConsoleKey.DownArrow)
                {
                    EditText(chars, Key);
                }
                else if (Key.Key == ConsoleKey.F1)
                {
                    Console.Clear();
                    Console.WriteLine("Введите путь до файла, указывая при этом формат, куда вы хотите сохранить текст: ");
                    Console.WriteLine("=================================================================================");

                    way = Console.ReadLine();
                    wayFormat2 = way.Split(".");

                    if (wayFormat2[1] == "txt")
                    {
                        if (wayFormat[1] == "txt")
                        {
                            File.WriteAllText(way, RText);
                        }
                        else if (wayFormat[1] == "json")
                        {
                            foreach (var item in jsonList)
                            {
                                File.WriteAllText(way, item.Name + "\n");
                                File.AppendAllText(way, item.Age + "\n");
                                File.AppendAllText(way, item.Description + "\n");
                            }
                        }
                        else if (wayFormat[1] == "xml")
                        {
                            string Text = Name + "\n" + Age + "\n" + Description;
                            File.WriteAllText(way, Text);
                        }
                    }
                    else if (wayFormat2[1] == "json")
                    {
                        List<Model> InformationAbout = new List<Model>();
                        if (wayFormat[1] == "json")
                        {
                            File.WriteAllText(way, RText);
                        }
                        else if (wayFormat[1] == "txt")
                        {
                            string[] words = RText.Split("\r\n");

                            Model Something = new Model(words[0], Convert.ToInt32(words[1]), words[2]);
                            InformationAbout.Add(Something);

                            string json = JsonConvert.SerializeObject(InformationAbout);
                            File.WriteAllText(way, json);
                        }
                        else if (wayFormat[1] == "xml")
                        {
                            Model Something = new Model(Name, Convert.ToInt32(Age), Description);
                            InformationAbout.Add(Something);

                            string json = JsonConvert.SerializeObject(InformationAbout);
                            File.WriteAllText(way, json);
                        }
                    }
                    else if (wayFormat2[1] == "xml")
                    {
                        if (wayFormat[1] == "xml")
                        {
                            File.WriteAllText(way, RText);
                        }
                        else if (wayFormat[1] == "txt")
                        {
                            string[] words = RText.Split("\n");

                            Model Something = new Model(words[0], Convert.ToInt32(words[1]), words[2]);
                            List<Model> InformationAbout = new List<Model>();
                            InformationAbout.Add(Something);

                            XmlSerializer xml = new XmlSerializer(typeof(List<Model>));
                            using (FileStream fs = new FileStream(way, FileMode.OpenOrCreate))
                            {
                                xml.Serialize(fs, InformationAbout);
                            }
                        }
                        else if (wayFormat[1] == "json")
                        {
                            jsonList = JsonConvert.DeserializeObject<List<Model>>(RText);

                            foreach (var item in jsonList)
                            {
                                Model Something = new Model(item.Name, item.Age, item.Description);
                                List<Model> InformationAbout = new List<Model>();
                                InformationAbout.Add(Something);

                                XmlSerializer xml = new XmlSerializer(typeof(List<Model>));
                                using (FileStream fs = new FileStream(way, FileMode.OpenOrCreate))
                                {
                                    xml.Serialize(fs, InformationAbout);
                                }
                            }
                        }
                    } 
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            } while (true);
        }
        
    }
}
