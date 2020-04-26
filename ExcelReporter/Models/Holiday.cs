using System;

namespace Excel_Reader.Models
{
    public class Holiday : ProjectDetailItem
    {
        public Guid Id { get; set; }
        public new string? DateStarted { get; set; }
        public new string? DateEnded { get; set; }
        public override string ToString()
        {
            return ProjectSheetId.ToString() + ", " + UserId.ToString() + ", " + Id + ", " + Name + ", " + DateStarted + ", " + DateEnded;
        }
    }
}