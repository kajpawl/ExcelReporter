using System;

namespace Excel_Reader.Models
{
    public class ProjectDetailItem
    {
        public Guid ProjectSheetId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string DateStarted { get; set; }
        public string DateEnded { get; set; }
    }
}