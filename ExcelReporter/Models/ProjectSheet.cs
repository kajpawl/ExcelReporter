using System;
using System.Collections.Generic;
using System.Text;

namespace Excel_Reader.Models
{
    class ProjectSheet
    {
        public Guid SheetId { get; set; }
        public int UserId { get; set; }
        public string ProjectName { get; set; }
        public List<ProjectTask> Tasks { get; set; }
        public List<Holiday> Holidays { get; set; }
        public override string ToString()
        {
            Tasks.ForEach(t => Console.WriteLine(t.ToString()));
            return SheetId.ToString() + ", " + ProjectName + ", ";
        }
    }
}
