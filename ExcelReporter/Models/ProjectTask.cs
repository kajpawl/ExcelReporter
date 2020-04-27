using System;

namespace Excel_Reader.Models
{
    public class ProjectTask : ProjectDetailItem
    {
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? TaskId { get; set; }
        public string? Description { get; set; }
        public string? Others { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public override string ToString()
        {
            return ProjectSheetId.ToString() + ", " + UserLogin + ", " + TaskId + ", " + Name + ", " + Description + ", " + DateStarted + ", " + DateEnded + ", " + Others;
        }
    }
}