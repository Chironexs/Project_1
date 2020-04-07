using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AplikacjaKonsolowa
{
    public static class ConsoleEx
    {
        public static void Write(string text, ConsoleColor consoleColor)
        {
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor;
            Console.Write(text);
            Console.ForegroundColor = temp;
        }
        public static void WriteLine(string text, ConsoleColor consoleColor)
        {
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor; 
            Console.WriteLine(text);
            Console.ForegroundColor = temp; 
        }
        public static void WriteMainHeaders()
        {
            var sb = new StringBuilder();
            sb.Append("\n");
            sb.Append("|-----------------------Konsolowy menadżer zadań------------------------|\n");
            sb.Append("| Wpisz polecenie:                                                      |\n");
            sb.Append("|-----------------------------------------------------------------------|\n");
            sb.Append("| Add     - dodaje zadanie                                              |\n");
            sb.Append("| Remove  - usuwa wybrane zadanie                                       |\n");
            sb.Append("| Show    - wyświetla wszystkie zadania                                 |\n");
            sb.Append("| Save    - zapisuje zadania do pliku                                   |\n");
            sb.Append("| Load    - wczytuje zadania z pliku                                    |\n");
            sb.Append("| Clear   - czyszczenie ekranu                                          |\n");
            sb.Append("| Exit    - wyjście                                                     |\n");
            sb.Append("|-----------------------------------------------------------------------|\n");
            Console.WriteLine(sb.ToString());
        }
        public static void WriteListOfTasksHeaders()
        {
            var sb = new StringBuilder();
            Console.WriteLine("|-----------------------------------------------------------------------|");
            ConsoleEx.WriteLine("| Zadania ważne wyświetlane są na niebiesko                             |", ConsoleColor.Blue);
            Console.WriteLine("|-----------------------------------------------------------------------|");

            var lp = "Lp.".PadRight(4, ' ');
            var a = "Opis zadania".PadRight(20, ' ');
            var b = "Data rozpoczęcia".PadRight(20, ' ');
            var c = "Data zakończenia".PadRight(20, ' ');
            Console.WriteLine("| " + lp + "| " + a + "| " + b + "| " + c + "|");
            Console.WriteLine("|-----------------------------------------------------------------------|");

        }
        public static void WriteListOfTasks(string lp, string x, string y, string z, ConsoleColor consoleColor)
        {
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor;
            Console.WriteLine("| " + lp + "| " + x + "| " + y + "| " + z + "|");
            Console.ForegroundColor = temp;

        }
        public static void WriteError()
        {
            ConsoleColor temp = Console.ForegroundColor;
            ColorFromFlag(Flag.red);
            Console.WriteLine("Wprowadzono niepoprawne dane, spróbuj ponownie");
            Console.ForegroundColor = temp;
        }

        public static void RequierdField()
        {
            ConsoleColor temp = Console.ForegroundColor;
            ColorFromFlag(Flag.red);
            Console.WriteLine("Pole jest obowiązkowe");
            Console.ForegroundColor = temp;
        }
        public static void ColorFromFlag(Flag color)
        {
            switch (color)
            {
                case Flag.red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Flag.green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case Flag.blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}