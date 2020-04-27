using OfficeOpenXml;

namespace ExcelReporter.App
{
    public static class Utilities
    {
        static Utilities()
        {
            ReportColumnNames = new string[] { "ID zadania", "Tytuł zadania", "Opis zadania", "Data rozpoczęcia", "Data zakończenia" };
        }

        public static string[] ReportColumnNames { get; }

        public static bool CheckForHeaderRows(ExcelWorksheet sheet, int i, string[] columnNames)
        {
            return (
                sheet.Cells[i, 1].Value != null && sheet.Cells[i, 1].Value.ToString().Trim() != columnNames[0] &&
                sheet.Cells[i, 2].Value != null && sheet.Cells[i, 2].Value.ToString().Trim() != columnNames[1] &&
                sheet.Cells[i, 3].Value != null && sheet.Cells[i, 3].Value.ToString().Trim() != columnNames[2] &&
                sheet.Cells[i, 4].Value != null && sheet.Cells[i, 4].Value.ToString().Trim() != columnNames[3] &&
                sheet.Cells[i, 5].Value != null && sheet.Cells[i, 5].Value.ToString().Trim() != columnNames[4]
            );
        }
    }
}
