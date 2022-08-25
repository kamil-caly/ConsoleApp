using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class PrintData : IPrintData
    {
        private readonly IDataOperations _dataOperations;
        private readonly List<ImportedObject> _importedObjects;
        public List<bool> isDatabase { get; set; }
        public bool printDatabaseTables { get; set; }

        public PrintData(IDataOperations dataOperations)
        {
           
            _dataOperations = dataOperations;
            _importedObjects = _dataOperations.GetImportedObjectAfterOperations();
        }

        public void PrintDataBaseInformation()
        {
            isDatabase = new List<bool>();

            foreach (var database in _importedObjects)
            {
                if (database.Type == "DATABASE")
                {
                    Console.WriteLine($"Database '{database.Name}' ({database.NumberOfChildren} tables)");
                    isDatabase.Add(true);

                    this.PrintAllDatabasesTables(database);
                }

                isDatabase.Add(false);
            }
        }

        public void PrintAllDatabasesTables(ImportedObject database)
        {
            foreach (var table in _importedObjects)
            {
                if (table.ParentType.ToUpper() == database.Type)
                {
                    if (table.ParentName == database.Name)
                    {
                        Console.WriteLine($"\tTable '{table.Schema}.{table.Name}' ({table.NumberOfChildren} columns)");

                        this.PrintAllTablesColumns(table);
                    }
                }
            }
        }

        public void PrintAllTablesColumns(ImportedObject table)
        {
            foreach (var column in _importedObjects)
            {
                if (column.ParentType.ToUpper() == table.Type)
                {
                    if (column.ParentName == table.Name)
                    {
                        Console.WriteLine($"\t\tColumn '{column.Name}' with {column.DataType} data type {(column.IsNullable == "1" ? "accepts nulls" : "with no nulls")}");
                    }
                }
            }
        }
    }
}
