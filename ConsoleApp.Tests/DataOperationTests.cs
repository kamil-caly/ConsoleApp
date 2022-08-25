namespace ConsoleApp.Tests
{
    public class DataOperationTests
    {
        private const string fileToImport = "data.csv";

        [Theory]
        [InlineData("TypeNameSchemaParentNameParentTypeDataTypeIsNullable", 0)]
        [InlineData("TableSalesTaxRateSalesAdventureWorks2016_EXTDatabaseNULL", 1)]
        [InlineData("TablePersonCreditCardSalesAdventureWorks2016_EXTDatabaseNULL", 2)]
        public void SplitDataToImportedObjectsList_ForGivenCsvFile_ReturnCorrectSplitObjects(string data, int row)
        {
            // arrange 

            IImportData importData = new ImportData(fileToImport);
            IDataOperations dataOperations = new DataOperations(importData);

            // act

            var result = dataOperations.GetImportedObjectAfterSplit();

            // assert

            Assert.Equal(result[row].Type + result[row].Name + result[row].Schema +
                         result[row].ParentName + result[row].ParentType + result[row].DataType +
                         result[row].IsNullable , data);
        }

        [Theory]
        [InlineData("TYPENameSchemaParentNameParentTypeDataTypeIsNullable", 0)]
        [InlineData("TABLESalesTaxRateSalesAdventureWorks2016_EXTDatabaseNULL", 1)]
        [InlineData("TABLEPersonCreditCardSalesAdventureWorks2016_EXTDatabaseNULL", 2)]
        public void ClearAndCorrectObjectsList_ForGivenSplitedCsvFile_ReturnCorrectObjects(string data, int row)
        {
            // arrange 

            IImportData importData = new ImportData(fileToImport);
            IDataOperations dataOperations = new DataOperations(importData);

            // act

            var result = dataOperations.GetImportedObjectAfterSplitWithClearAndCorrect();

            // assert

            Assert.Equal(result[row].Type + result[row].Name + result[row].Schema +
                         result[row].ParentName + result[row].ParentType + result[row].DataType +
                         result[row].IsNullable, data);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(5, 1)]
        [InlineData(3, 2)]
        public void AssignNumberOfChildrenEveryImportedObject_ForGivenSplitedWithClearAndCorrectCsvFile_ReturnCorrectObjects(int numberOfChildren, int row)
        {
            // arrange 

            IImportData importData = new ImportData(fileToImport);
            IDataOperations dataOperations = new DataOperations(importData);

            // act

            var result = dataOperations.GetImportedObjectAfterOperations();

            // assert

            Assert.Equal(result[row].NumberOfChildren, numberOfChildren);
        }
    }
}
