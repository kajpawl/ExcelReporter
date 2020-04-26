using System;
using System.Collections.Generic;
using System.Text;

namespace Excel_Reader.Models
{
    class ReportStatement
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DomainLogin { get; set; }
        public List<Guid> ProjectSheetIds { get; set; }
    }
}
