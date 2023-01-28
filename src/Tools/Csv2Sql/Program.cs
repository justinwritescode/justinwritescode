using System.Collections;
// See https://aka.ms/new-console-template for more information

using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using CsvHelper;

var csvFile = args[0];
using var csv = new CsvReader(new StreamReader(File.OpenRead(csvFile)), CultureInfo.CurrentCulture, true);
var sb = new StringBuilder();
var columns = Enumerable.Repeat(0, csv.ColumnCount).Select((x, i) => i).ToArray();
sb.AppendLine($"SET IDENTITY_INSERT {args[1]} ON;");
if (csv.Read() && csv.ReadHeader())
{
    var header = csv.HeaderRecord;
    while (csv.Read())
    {
        sb.Append($"INSERT INTO {args[1]} (");
        sb.Append(header.Select(x => $"[{x}]").Join(", "));
        sb.Append(") VALUES (");
        sb.Append(header.Select(c => $"'{csv.GetField(c)}'").Join(", "));
        sb.AppendLine(");");
    }
}
sb.AppendLine($"SET IDENTITY_INSERT {args[1]} OFF;");
Console.WriteLine(sb.ToString());
