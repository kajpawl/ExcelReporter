using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Excel_Reader.Models
{
    public class ReportStatement
    {
        [Key]
        public string UserLogin { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<ProjectSheet> ProjectSheets { get; set; }
    }
}
