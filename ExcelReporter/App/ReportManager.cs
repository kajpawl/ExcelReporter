using System;
using System.Collections.Generic;
using Excel_Reader.Models;
using OfficeOpenXml;
using System.IO;

namespace ExcelReporter.App
{
    public class ReportManager
    {
        public IEnumerable<string> LogReport(FileInfo fileInfo)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var sourceExcel = new ExcelPackage(fileInfo))
            {
                var projectSheets = sourceExcel.Workbook.Worksheets;
                var userId = 0;
                var columnNames = Utilities.ReportColumnNames;

                var sheetList = new List<string>();

                foreach (var sheet in projectSheets)
                {
                    var projectSheet = new ProjectSheet
                    {
                        Id = new Guid().ToString(),
                        UserId = userId,
                        ProjectName = sheet.Name,
                        Tasks = new List<ProjectTask>(),
                        Holidays = new List<Holiday>()
                    };


                    int rows = sheet.Dimension.Rows;
                    int columns = sheet.Dimension.Columns;

                    for (int i = 1; i <= rows; i++)
                    {
                        if (columns <= 5 && Utilities.CheckForHeaderRows(sheet, i, columnNames))
                        {

                            var task = new ProjectTask
                            {
                                ProjectSheetId = projectSheet.Id,
                                UserId = projectSheet.UserId,
                                Name = sheet.Cells[i, 2].Value.ToString(),
                                DateStarted = sheet.Cells[i, 4].Value.ToString(),
                                DateEnded = sheet.Cells[i, 5].Value.ToString()
                            };

                            var idVal = sheet.Cells[i, 1].Value;
                            if (idVal != null)
                                task.TaskId = idVal.ToString();

                            var descriptionVal = sheet.Cells[i, 3].Value;
                            if (descriptionVal != null)
                                task.Description = descriptionVal.ToString();

                            if (columns < 5)
                            {
                                for (int k = 5; k <= columns; k++)
                                {
                                    var content = sheet.Cells[i, k].Value;
                                    if (content != null)
                                        task.Others += content.ToString() + "; ";
                                }
                            }

                            projectSheet.Tasks.Add(task);
                        }
                        else if (Utilities.CheckForHeaderRows(sheet, i, columnNames))
                        {
                            var holiday = new Holiday
                            {
                                ProjectSheetId = projectSheet.Id,
                                UserId = projectSheet.UserId,
                                Id = new Guid().ToString()
                            };
                            var holidayName = "";

                            for (int j = 1; j <= columns; j++)
                            {
                                var content = sheet.Cells[i, j].Value;
                                if (content != null)
                                    holidayName += content.ToString() + "; ";

                            }
                            holiday.Name = holidayName;

                            projectSheet.Holidays.Add(holiday);
                        }
                    }

                    sheetList.Add(projectSheet.ToString());
                }

                return sheetList;
            }
        }
    }
}
