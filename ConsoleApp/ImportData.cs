using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
    public class ImportData : IImportData
    {
        private readonly StreamReader streamReader;

        public ImportData(string fileToImport)
        {
            streamReader = new StreamReader(fileToImport);
        }

        public IEnumerable<string> ReadData()
        {
            var importedLines = new List<string>();

            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                importedLines.Add(line);
            }

            return importedLines;
        }
    }
}
