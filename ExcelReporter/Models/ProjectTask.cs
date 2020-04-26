using System;

namespace Excel_Reader.Models
{
    public class ProjectTask : ProjectDetailItem
    {
        public string? TaskId { get; set; }
        public string? Description { get; set; }
        public string? Others { get; set; }
        public override string ToString()
        {
            return ProjectSheetId.ToString() + ", " + UserId.ToString() + ", " + TaskId + ", " + Name + ", " + Description + ", " + DateStarted + ", " + DateEnded + ", " + Others;
        }
    }
}