using System.Collections.Generic;

namespace Excel_Reader.Models
{
    public class ReportStatement
    {
        public string Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DomainLogin { get; set; }
        public List<ProjectSheet> ProjectSheets { get; set; }
    }
}
