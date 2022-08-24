using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class DataOperations : IDataOperations
    {
        private readonly IImportData _importData;
        private readonly List<ImportedObject> ImportedObjects;
        private ImportedObject importedObject;
        private string[] values;

        public DataOperations(IImportData importData)
        {
            _importData = importData;
            ImportedObjects = new List<ImportedObject>(); 
        }

        public void SplitDataToImportedObjectsList()
        {
           var importedLines = _importData.ReadData();

            foreach (var line in importedLines)
            {
                values = line.Split(';');

                importedObject = new ImportedObject();

                importedObject.Type = values.Count() < 1 ? "" : values[0];
                importedObject.Name = values.Count() < 2 ? "" : values[1];
                importedObject.Schema = values.Count() < 3 ? "" : values[2];
                importedObject.ParentName = values.Count() < 4 ? "" : values[3];
                importedObject.ParentType = values.Count() < 5 ? "" : values[4];
                importedObject.DataType = values.Count() < 6 ? "" : values[5];
                importedObject.IsNullable = values.Count() < 7 ? "" : values[6];

                ImportedObjects.Add(importedObject);
            }
        }

        public void ClearAndCorrectObjectsList()
        {
            foreach (var importedObject in ImportedObjects)
            {
                importedObject.Type = importedObject.Type.Trim().Replace(" ", "").ToUpper();
                importedObject.Name = importedObject.Name.Trim().Replace(" ", "");
                importedObject.Schema = importedObject.Schema.Trim().Replace(" ", "");
                importedObject.ParentName = importedObject.ParentName.Trim().Replace(" ", "");
                importedObject.ParentType = importedObject.ParentType.Trim().Replace(" ", "");
            }
        }

        public void AssignNumberOfChildrenEveryImportedObject()
        {
            foreach (var imported_Object in ImportedObjects)
            {
                importedObject = imported_Object;

                foreach (var impObj in ImportedObjects)
                {
                    if (impObj.ParentType == importedObject.Type)
                    {
                        if (impObj.ParentName == importedObject.Name)
                        {
                            importedObject.NumberOfChildren += 1;
                        }
                    }
                }
            }
        }

        public List<ImportedObject> GetImportedObject()
        {
            this.SplitDataToImportedObjectsList();
            this.ClearAndCorrectObjectsList();
            this.AssignNumberOfChildrenEveryImportedObject();
            
            return this.ImportedObjects;
        }
    }
}
