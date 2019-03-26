using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace AllTasks.Models
{
    public class tasks
    {
        public int ID { get; set; }
        [DisplayName("Task Nr")]
        public int Nr { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Worked { get; set; }
        [DisplayName("Tested L")]
        public bool T_L { get; set; }
        [DisplayName("Test Date")]
        [DataType(DataType.Date)]
        public DateTime Test_Date { get; set; }
        [DisplayName("My Time")]
        public decimal My_Time{ get; set; }
        [DisplayName("Project Name")]
        public string Project_Name{ get; set; }
    }

    public class TasksDBContext : DbContext
    {
        public DbSet<tasks> Tasks { get; set; }
    }
}