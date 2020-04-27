﻿using System;
using System.Collections.Generic;

namespace Excel_Reader.Models
{
    public class ProjectSheet
    {
        public string Id { get; set; }
        public int UserId { get; set; }
        public string ProjectName { get; set; }
        public List<ProjectTask> Tasks { get; set; }
        public List<Holiday> Holidays { get; set; }
        public override string ToString()
        {
            Tasks.ForEach(t => Console.WriteLine(t.ToString()));
            return Id + ", " + ProjectName + ", ";
        }
    }
}
