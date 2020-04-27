﻿namespace Excel_Reader.Models
{
    public class Holiday : ProjectDetailItem
    {
        public new string? DateStarted { get; set; }
        public new string? DateEnded { get; set; }
        public override string ToString()
        {
            return ProjectSheetId.ToString() + ", " + UserLogin + ", " + Id + ", " + Name + ", " + DateStarted + ", " + DateEnded;
        }
    }
}