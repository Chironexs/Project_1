using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace AplikacjaKonsolowa
{
    public class Task
    {
        public static List<TaskModel> listTaskModel = new List<TaskModel>();

        public static void AddTask()
        {
            ConsoleEx.WriteLine("Podaj opis zadania:", ConsoleColor.Green);
            var description = IsRequired();

            ConsoleEx.WriteLine("Czy zadanie jest całodniowe - Y/N", ConsoleColor.Green);
            var allDayTask = TrueOrFalse();

            ConsoleEx.WriteLine("Podaj datę rozpoczęcia yyyy-MM-dd HH:mm", ConsoleColor.Green);
            var startDate = Date();

            DateTime? endDate = null;
            if (allDayTask == false)
            {
                ConsoleEx.WriteLine("Podaj datę zakończenia yyyy-MM-dd HH:mm", ConsoleColor.Green);
                DateTime? endDateFromDateMethod = Date();
                endDate = endDateFromDateMethod;
            }

            ConsoleEx.WriteLine("Czy zadanie jest ważne - Y/N", ConsoleColor.Green);
            var importantTask = TrueOrFalse();

            TaskModel task = new TaskModel(description, startDate, endDate, allDayTask, importantTask);
            listTaskModel.Add(task);
        }

        private static bool TrueOrFalse()
        {
            string answer = Console.ReadLine().ToLower();
            if (answer == "y")
            {
                return true;
            }

            return false;
        }

        private static DateTime Date()
        {
            while (true)
            {
                string start = Console.ReadLine();
                var patternDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                if (DateTime.TryParseExact(start, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out patternDate))
                {
                    return DateTime.Parse(start);
                }

                ConsoleEx.WriteError();
            }
        }

        private static string IsRequired()
        {
            while (true)
            {
                string description = Console.ReadLine();
                if (!string.IsNullOrEmpty(description))
                {
                    return description;
                }

                ConsoleEx.RequierdField();
            }
        }

        private static bool IsRequired1()
        {
            while (true)
            {
                string description = Console.ReadLine();
                if (!string.IsNullOrEmpty(description))
                {
                    return true;
                }

                ConsoleEx.RequierdField();
            }
        }
        public static void RemoveTask()
        {
            ShowTasks();
            ConsoleEx.WriteLine("Wybierz lp. zadania do usunięcia:", ConsoleColor.Green);
            var result = IsRequired();
            int patternRemove = 0;
            if (Int32.TryParse(result, out patternRemove))
            {
                listTaskModel.RemoveAt(patternRemove);
            }
            else
            {
                ConsoleEx.WriteError();
            }
        }

        public static void ShowTasks()
        {
            Console.Clear();
            ConsoleEx.WriteListOfTasksHeaders();
            foreach (var itemTaskModel in listTaskModel)
            {
                var lp = listTaskModel.IndexOf(itemTaskModel).ToString().PadRight(4, ' ');
                var x = itemTaskModel.Description.PadRight(20, ' ');
                var y = itemTaskModel.StartDate.ToString().PadRight(20, ' ');
                var date = itemTaskModel.EndDate.ToString();
                var z = "";

                ConsoleColor cc = ConsoleColor.White;
                if (string.IsNullOrEmpty(date))
                {
                    z = " Zadanie całodniowe ";
                }
                else
                {
                    z = itemTaskModel.EndDate.ToString().PadRight(20, ' ');
                }

                if (itemTaskModel.Important == true)
                {
                    cc = ConsoleColor.Blue;
                }
                else
                {
                    cc = ConsoleColor.White;
                }

                ConsoleEx.WriteListOfTasks(lp, x, y, z, cc);
            }
        }

        public static void SaveTasks()
        {
            string path = @"TaskMenager.txt";
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            using (StreamWriter writer = new StreamWriter(path))
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in listTaskModel)
                {
                    sb.Append(item.Description);
                    sb.Append(';');
                    sb.Append(item.StartDate);
                    sb.Append(';');
                    sb.Append(item.EndDate);
                    sb.Append(';');
                    sb.Append(item.Important);
                    sb.Append(';');
                    sb.Append(item.AllDayTask);
                    sb.AppendLine();
                }

                writer.Write(sb.ToString());
                ConsoleEx.WriteLine("Zapisano do pliku: TaskMenager.txt", ConsoleColor.Green);
            }
        }

        public static void LoadTasks()
        {
            string path = @"TaskMenager.txt";
            if (!(listTaskModel == null))
            {
                listTaskModel.Clear();
            }


            if (File.Exists(path))
            {
                string[] readAllLines = File.ReadAllLines(path);
                foreach (var item in readAllLines)
                {
                    string[] textTable = item.Split(";");
                    var textTable2 = textTable[2].ToString();
                    DateTime? endDate;
                    //bool allDayTask;
                    var patternDate = DateTime.Parse(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
                    if (DateTime.TryParseExact(textTable2, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out patternDate))
                    {
                        endDate = DateTime.Parse(textTable2);
                        //allDayTask = false;
                    }
                    else
                    {
                        endDate = null;
                        // allDayTask = true;
                    }

                    bool importantTask;
                    if (textTable[3].ToString() == "True")
                    {
                        importantTask = true;
                    }
                    else
                    {
                        importantTask = false;
                    }

                    bool allDayTask;
                    if (textTable[4].ToString() == "True")
                    {
                        allDayTask = true;
                    }
                    else
                    {
                        allDayTask = false;
                    }

                    TaskModel task = new TaskModel(textTable[0], DateTime.Parse(textTable[1]), endDate, allDayTask, importantTask);
                    listTaskModel.Add(task);
                }

                ShowTasks();
                ConsoleEx.WriteLine("Załadowano dane z pliku: TaskMenager.txt", ConsoleColor.Green);
            }
            else
            {
                ConsoleEx.WriteLine("Nie znaleziono pliku", ConsoleColor.Green);
            }
        }
    }
}