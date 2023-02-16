using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyPressed;
            int[] frequencies = { };
            frequencies = octaveChange(4);
            while (true)
            {
                keyPressed = Console.ReadKey();
                Console.Clear();
                switch (keyPressed.Key)
                {
                    case ConsoleKey.F1:
                        frequencies = octaveChange(1);
                        break;
                    case ConsoleKey.F2:
                        frequencies = octaveChange(2);
                        break;
                    case ConsoleKey.F3:
                        frequencies = octaveChange(3);
                        break;
                    case ConsoleKey.F4:
                        frequencies = octaveChange(4);
                        break;
                    case ConsoleKey.F5:
                        frequencies = octaveChange(5);
                        break;
                    case ConsoleKey.F6:
                        frequencies = octaveChange(6);
                        break;
                    case ConsoleKey.F7:
                        frequencies = octaveChange(7);
                        break;
                    case ConsoleKey.F8:
                        frequencies = octaveChange(8);
                        break;
                    default:
                        soundCreate(keyPressed, frequencies);
                        break;

                }
            }
        }

        static int[] octaveChange(int octave)
        {
            int[] firstOctave = new int[] { 33, 35, 37, 39, 41, 44, 46, 49, 52, 55, 58, 62 };
            int[] secondOctave = new int[] { 65, 69, 73, 78, 82, 87, 92, 98, 104, 110, 116, 123 };
            int[] thirdOctave = new int[] { 131, 139, 147, 156, 165, 175, 185, 196, 208, 220, 233, 247 };
            int[] fourthOctave = new int[] { 262, 277, 294, 311, 330, 349, 370, 392, 415, 440, 466, 494 };
            int[] fifthOctave = new int[] { 523, 554, 587, 622, 659, 698, 740, 784, 831, 880, 932, 988 };
            int[] sixthOctave = new int[] { 1047, 1109, 1175, 1245, 1319, 1397, 1480, 1568, 1661, 1760, 1865, 1976 };
            int[] seventhOctave = new int[] { 2093, 2217, 2349, 2489, 2637, 2794, 2960, 3136, 3322, 3520, 3729, 3951 };
            int[] eighthOctave = new int[] { 4186, 2235, 4699, 4978, 5274, 5588, 5920, 6272, 6645, 7040, 7459, 7902 };
            Console.WriteLine(octave + " октава");
            switch (octave)
            {
                case 1:
                    return firstOctave;
                case 2:
                    return secondOctave;
                case 3:
                    return thirdOctave;
                case 4:
                    return fourthOctave;
                case 5:
                    return fifthOctave;
                case 6:
                    return sixthOctave;
                case 7:
                    return seventhOctave;
                case 8:
                    return eighthOctave;
                default:
                    return firstOctave;
            }
        }

        static void soundCreate(ConsoleKeyInfo keyPressed, int[] frequencies)
        {
            switch (keyPressed.Key)
            {
                case ConsoleKey.A:
                    Console.Beep(frequencies[0],500);
                    break;
                case ConsoleKey.W:
                    Console.Beep(frequencies[1],500);
                    break;
                case ConsoleKey.S:
                    Console.Beep(frequencies[2],500);
                    break;
                case ConsoleKey.E:
                    Console.Beep(frequencies[3],500);
                    break;
                case ConsoleKey.D:
                    Console.Beep(frequencies[4],500);
                    break;
                case ConsoleKey.F:
                    Console.Beep(frequencies[5],500);
                    break;
                case ConsoleKey.T:
                    Console.Beep(frequencies[6],500);
                    break;
                case ConsoleKey.G:
                    Console.Beep(frequencies[7],500);
                    break;
                case ConsoleKey.Y:
                    Console.Beep(frequencies[8],500);
                    break;
                case ConsoleKey.H:
                    Console.Beep(frequencies[9],500);
                    break;
                case ConsoleKey.U:
                    Console.Beep(frequencies[10],500);
                    break;
                case ConsoleKey.J:
                    Console.Beep(frequencies[11],500);
                    break;
                
            }
                
        }
    }
}
