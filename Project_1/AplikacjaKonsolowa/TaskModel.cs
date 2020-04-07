using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text;

namespace AplikacjaKonsolowa
{
    public class TaskModel
    {
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Important { get; set; }
        public bool? AllDayTask { get; set; }
        public TaskModel(string description, DateTime startDate, DateTime? endDate, bool? allDayTask, bool? importantTask)
        {
            this.Description = description;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.AllDayTask = allDayTask;
            this.Important = importantTask;
        }
    }
}