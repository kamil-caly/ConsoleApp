using System;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            IImportData importData = new ImportData("data.csv");
            IDataOperations dataOperations = new DataOperations(importData);
            IPrintData printData = new PrintData(dataOperations);

            printData.PrintDataBaseInformation();

            Console.ReadLine();
        }
    }
}
