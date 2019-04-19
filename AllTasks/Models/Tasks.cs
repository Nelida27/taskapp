using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Web.Mvc;

namespace AllTasks.Models
{
    public class tasks
    {
        public int ID { get; set; }
        [DisplayName("Task Nr")]
        public int Nr { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string Worked { get; set; }
        [DisplayName("Tested L")]
        public bool T_L { get; set; }
        [Display(Name = "Test Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
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