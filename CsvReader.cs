using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace MeterDataSubmission.Data.Helpers
{
    public class CsvReader
    {
        public static IEnumerable<IEnumerable<string>> ReadFile(string filePath, bool isFirstRowHeader = true, string delimiter = ",")
        {
            var result = new List<IEnumerable<string>>();
            using (var parser = FileSystem.OpenTextFieldParser(filePath, delimiter))
            {
                while (!parser.EndOfData)
                {
                    result.Add(parser.ReadFields());
                }
            }

            if (isFirstRowHeader)
            {
                result.RemoveAt(0);
            }

            return result;
        }
    }
}
