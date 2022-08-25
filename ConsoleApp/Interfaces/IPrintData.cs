using System.Collections.Generic;

namespace ConsoleApp
{
    public interface IPrintData
    {
        void PrintAllDatabasesTables(ImportedObject database);
        void PrintAllTablesColumns(ImportedObject table);
        void PrintDataBaseInformation();
        List<bool> isDatabase { get; set; }
    }
}