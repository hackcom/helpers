using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace MeterDataSubmission.Data.Helpers
{
    public class ExcelReader
    {
        public static IEnumerable<IEnumerable<string>> ReadFile(string filePath, bool isFirstRowHeader = true)
        {
            using (var wb = new XLWorkbook(filePath))
            {
                using (var ws = wb.Worksheet(1))
                {
                    var data = ws.Rows().Select(r => 
                            r.Cells().Select(c => 
                                c.Value.ToString()));

                    if (isFirstRowHeader)
                    {
                        data = data.Skip(1);
                    }

                    return data;
                }
            }
            
        }
    }
}
