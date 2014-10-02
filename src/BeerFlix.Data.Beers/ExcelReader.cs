using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using OfficeOpenXml;

namespace BeerFlix.Data.Beers
{
    public class ExcelReader<T> where T : new()
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private ExcelPackage _package;
        private string[] _workSheetNames;

        public ExcelReader()
        {
        }

        private bool Open(Stream fileStream)
        {
            try
            {
                _package = new ExcelPackage(fileStream);

                _workSheetNames = _package.Workbook.Worksheets.Select(workSheet => workSheet.Name).ToArray();
            }
            catch
            {
                Log.Error("Import file was not valid, exiting");
                return false;
            }
            return true;
        }

        private void Close()
        {
            _package.Dispose();
        }

        public IEnumerable<T> GetAllRows(Stream fileStream, string worksheet)
        {
            //var fileStream = File.Open(@"Data/systembolaget.xlsx",
            //    FileMode.Open, FileAccess.Read, FileShare.Read);
            Open(fileStream);

            var workSheet = _package.Workbook.Worksheets[worksheet];
            var dataType = typeof (T);
            var propertiesInDataType = dataType.GetProperties();
            var headers = workSheet.Cells[1, 1, 1, propertiesInDataType.Length]
                .Select(c => new { Value = c.Value, Address = new CellAddress(c.Address) })
                .ToArray();
            var headersToColumnIndex = new Dictionary<int, _PropertyInfo>();
            foreach (var header in headers)
            {
                var propertyInfo = propertiesInDataType.FirstOrDefault(p => p.Name == (header.Value ?? "").ToString());
                if (propertyInfo != null)
                {
                    headersToColumnIndex.Add(header.Address.Column, propertyInfo);
                }
            }

            var rowIndex = 1;
            var firstCellValue = (string)null;
            var results = new List<T>();
            
            do
            {
                var range = workSheet.Cells[rowIndex + 1, 1, 1, propertiesInDataType.Length]
                    .Select(c => new { Value = c.Value, Address = new CellAddress(c.Address) })
                    .ToArray();

                firstCellValue = range[0].Value as string;
                
                var value = new T();
                foreach (var cell in range)
                {
                    var propertyInfo = headersToColumnIndex[cell.Address.Column];
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(value, cell.Value, null);
                    }
                }
                results.Add(value);
                rowIndex++;
            } while (firstCellValue != null);

            Close();
            return results;
        }

        public class CellAddress
        {
            private static readonly Regex AddressParsingRegEx;
            private static readonly int CharAValue;
            private static readonly int CharAtoZOffset;


            static CellAddress()
            {
                CharAValue = (int)'A';
                CharAtoZOffset = (int)'Z' - CharAValue + 1;
                const string regEx = @"\b([A-Z]{1,}?)(\d{1,})\b";
                AddressParsingRegEx = new System.Text.RegularExpressions.Regex(regEx, RegexOptions.Compiled);
            }

            public CellAddress(string address)
            {
                var groups = AddressParsingRegEx.Match(address).Groups;
                var columnValue = groups[1].Value.ToUpper();
                var column = 0;
                for (var i = 0; i < columnValue.Length; i++)
                {
                    var columnChar = (int)columnValue[i];
                    column += (columnChar - CharAValue) + i * CharAtoZOffset;
                }
                Column = column;

                var row = -1;
                if (int.TryParse(groups[2].Value, NumberStyles.Integer,
                    System.Globalization.CultureInfo.InvariantCulture, out row))
                {
                    Row = row - 1;
                }
            }

            public int Row { get; private set; }
            public int Column { get; private set; }
        }   
    }
}