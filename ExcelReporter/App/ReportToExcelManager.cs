using Excel_Reader.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelReporter.App
{
    public class ReportToExcelManager
    {
        public string GenerateExcelFile(IEnumerable<ProjectSheet> projectSheets, string userLogin)
        {
            List<string[]> headerRow = new List<string[]>()
            {
              Utilities.ReportColumnNames
            };

            // Determine the header range (e.g. A1:E1)
            string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excel = new ExcelPackage())
            {
                foreach (var sheet in projectSheets)
                {
                    excel.Workbook.Worksheets.Add(sheet.ProjectName);

                    var excelWorksheet = excel.Workbook.Worksheets[sheet.ProjectName];

                    // Popular header row data
                    excelWorksheet.Cells[headerRange].LoadFromArrays(headerRow);

                    var taskList = new List<object[]>();
                    foreach (var task in sheet.Tasks)
                    {
                        taskList.Add(new object[]
                        {
                            task.Id,
                            task.Name,
                            task.Description,
                            task.DateStarted,
                            task.DateEnded
                        });
                    }

                    excelWorksheet.Cells[2, 1].LoadFromArrays(taskList);

                }

                var path = @"D:\" + userLogin + ".xlsx";
                FileInfo excelFile = new FileInfo(path);
                excel.SaveAs(excelFile);

                return path;
            }
        }
    }
}
