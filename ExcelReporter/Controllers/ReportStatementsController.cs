using System.Collections.Generic;
using System.IO;
using ExcelReporter.App;
using ExcelReporter.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExcelReporter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportStatementsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ReportManager _reportManager;

        public ReportStatementsController(ApplicationDbContext context)
        {
            _context = context;
            _reportManager = new ReportManager();
        }

        // GET: api/ReportStatements
        [HttpGet]
        [AllowAnonymous]
        public string Get()
        //public IEnumerable<ReportStatement> Get()
        {
            //var reports = _context.ReportStatements.ToList();

            return "reports";
        }

        // GET: api/ReportStatements/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ReportStatements
        [HttpPost]
        public IEnumerable<string> Post([FromBody] string reportPath)
        {
            FileInfo fileInfo = new FileInfo(reportPath);
            var sheetList = _reportManager.LogReport(fileInfo);

            return sheetList;
        }

        // PUT: api/ReportStatements/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
