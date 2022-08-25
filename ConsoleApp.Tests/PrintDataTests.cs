namespace ConsoleApp.Tests
{
    public class PrintDataTests
    {
        private const string fileToImport = "data.csv";

        [Theory]
        [InlineData(2, false)]
        [InlineData(3, false)]
        [InlineData(25, true)]
        [InlineData(26, false)]
        [InlineData(27, false)]
        public void PrintDataBaseInformation_ForGivenCsvFile_ReturnIsDatabaseOrNot(int row, bool database)
        {
            // arrange

            IImportData importData = new ImportData(fileToImport);
            IDataOperations dataOperations = new DataOperations(importData);
            IPrintData printData = new PrintData(dataOperations);

            // act

            printData.PrintDataBaseInformation();

            // assert

            Assert.Equal(database, printData.isDatabase[row]);
        }
    }
}
