namespace Excel_Reader.Models
{
    public class Holiday : ProjectDetailItem
    {
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public new string? DateStarted { get; set; }
        public new string? DateEnded { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public override string ToString()
        {
            return ProjectSheetId.ToString() + ", " + UserLogin + ", " + Id + ", " + Name + ", " + DateStarted + ", " + DateEnded;
        }
    }
}