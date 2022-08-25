using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Tests
{
    public class ImportDataTests
    {
        private const string fileToImport = "data.csv";

        [Fact]
        public void ReadData_ForGivenCsvFile_ReturnIEnumerableString()
        {
            // arrange 

            IImportData importData = new ImportData(fileToImport);

            // act 

            var result = importData.ReadData();

            // arrange

            Assert.NotNull(result);
            Assert.Equal(1431, result.Count());
        }

    }
}
