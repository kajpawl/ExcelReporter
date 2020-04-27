using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Excel_Reader.Models;
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
        private readonly ReportToDbManager _reportToDbManager;
        private readonly ReportToExcelManager _reportToExcelManager;

        public ReportStatementsController(ApplicationDbContext context)
        {
            _context = context;
            _reportToDbManager = new ReportToDbManager();
            _reportToExcelManager = new ReportToExcelManager();
        }

        // GET: api/ReportStatements/GetReportsList
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<ReportStatement> GetReportsList()
        {
            var reportList = _context.ProjectSheets.ToList();
            var userLogins = reportList.Select(r => r.UserLogin).Distinct();
            var reportsByPeople = new List<ReportStatement>();

            foreach (var login in userLogins)
            {
                //search DB for user's name and surname

                var reportStatement = new ReportStatement()
                {
                    UserLogin = login,
                    Name = "name",
                    Surname = "surname",
                    ProjectSheets = reportList.Where(r => r.UserLogin == login).OrderBy(r => r.ProjectName).ToList()
                };

                reportsByPeople.Add(reportStatement);
            }


            return reportsByPeople;
        }

        // GET: api/ReportStatements/{userLogin}
        [HttpGet("{userLogin}", Name = "Get")]
        public ReportStatement Get(string userLogin)
        {
            //search DB for user's name and surname

            var reports = _context.ProjectSheets.Where(r => r.UserLogin == userLogin).ToList();

            var reportStatement = new ReportStatement()
            {
                UserLogin = userLogin,
                Name = "name",
                Surname = "surname",
                ProjectSheets = reports
            };

            return reportStatement;
        }

        // GET: api/ReportStatements/GetFile/{userLogin}
        [HttpGet("{userLogin}")]
        public FileResult GetFile(string userLogin)
        {
            var reports = _context.ProjectSheets.Where(r => r.UserLogin == userLogin).ToList();
            var filePath = _reportToExcelManager.GenerateExcelFile(reports, userLogin);
            var fileName = userLogin + ".xlsx";
            var mimeType = "application/vnd.ms-excel";

            return File(new FileStream(filePath, FileMode.Open), mimeType, fileName);
        }

        // POST: api/ReportStatements/{userLogin}
        [HttpPost("{userLogin}")]
        public async Task<IEnumerable<ProjectSheet>> Post(string userLogin, [FromBody] string reportPath)
        {
            FileInfo fileInfo = new FileInfo(reportPath);
            var sheetList = _reportToDbManager.GetReportDataFromFile(fileInfo, userLogin);

            foreach (var sheet in sheetList)
            {
                bool isPresent = _context.ProjectSheets.Any(
                    r => r.UserLogin == userLogin && r.ProjectName == sheet.ProjectName);

                if (!isPresent) _context.ProjectSheets.Add(sheet);
            }
            await _context.SaveChangesAsync();

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
