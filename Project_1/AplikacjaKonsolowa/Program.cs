using System;
using System.Collections.Generic;

namespace AplikacjaKonsolowa
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            do
            {
                ConsoleEx.WriteMainHeaders();
                command = Console.ReadLine().ToLower();
                if (command == "add")
                {
                    Task.AddTask();
                }

                if (command == "remove")
                {
                    Task.RemoweTask();
                }

                if (command == "show")
                {
                    Task.ShowTasks();
                }

                if (command == "save")
                {
                    Task.SaveTasks();
                }

                if (command == "load")
                {
                    Task.LoadTasks();
                }

                if (command == "clear")
                {
                    Console.Clear();
                }

                if (command == "exit")
                {
                    break;
                }

            } while (true);
        }
    }
}