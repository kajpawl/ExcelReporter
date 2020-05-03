using System;
using System.Collections.Generic;
using Excel_Reader.Models;
using OfficeOpenXml;
using System.IO;

namespace ExcelReporter.App
{
    public class ReportToDbManager
    {
        public IEnumerable<ProjectSheet> GetReportDataFromFile(ExcelPackage sentFile, string domainLogin)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using var sourceExcel = sentFile;
            var projectSheets = sourceExcel.Workbook.Worksheets;
            var userId = domainLogin;
            var columnNames = Utilities.ReportColumnNames;

            var sheetList = new List<ProjectSheet>();

            foreach (var sheet in projectSheets)
            {
                ProjectSheet projectSheet = CreateProjectSheet(userId, columnNames, sheet);
                sheetList.Add(projectSheet);
            }

            return sheetList;
        }

        private static ProjectSheet CreateProjectSheet(string userId, string[] columnNames, ExcelWorksheet sheet)
        {
            var projectSheet = new ProjectSheet
            {
                ProjectSheetId = Guid.NewGuid().ToString(),
                UserLogin = userId,
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
                    ProjectTask task = CreateProjectTask(sheet, projectSheet, columns, i);
                    projectSheet.Tasks.Add(task);
                }
                else if (Utilities.CheckForHeaderRows(sheet, i, columnNames))
                {
                    Holiday holiday = CreateHoliday(sheet, projectSheet, columns, i);
                    projectSheet.Holidays.Add(holiday);
                }
            }

            return projectSheet;
        }

        private static ProjectTask CreateProjectTask(ExcelWorksheet sheet, ProjectSheet projectSheet, int columns, int i)
        {
            var task = new ProjectTask
            {
                Id = Guid.NewGuid().ToString(),
                ProjectSheetId = projectSheet.ProjectSheetId,
                ProjectSheet = projectSheet,
                UserLogin = projectSheet.UserLogin,
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

            return task;
        }

        private static Holiday CreateHoliday(ExcelWorksheet sheet, ProjectSheet projectSheet, int columns, int i)
        {
            var holiday = new Holiday
            {
                Id = Guid.NewGuid().ToString(),
                ProjectSheetId = projectSheet.ProjectSheetId,
                ProjectSheet = projectSheet,
                UserLogin = projectSheet.UserLogin
            };
            var holidayName = "";

            for (int j = 1; j <= columns; j++)
            {
                var content = sheet.Cells[i, j].Value;
                if (content != null)
                    holidayName += content.ToString() + "; ";

            }
            holiday.Name = holidayName;

            return holiday;
        }
    }
}
