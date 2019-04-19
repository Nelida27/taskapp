using System;

namespace AllTasks.Models
{
    internal class UniqueAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
    }
}