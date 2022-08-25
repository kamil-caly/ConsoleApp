using System.Collections.Generic;

namespace ConsoleApp
{
    public interface IDataOperations
    {
        void SplitDataToImportedObjectsList();
        void ClearAndCorrectObjectsList();
        void AssignNumberOfChildrenEveryImportedObject();
        List<ImportedObject> GetImportedObjectAfterOperations();
        List<ImportedObject> GetImportedObjectAfterSplitWithClearAndCorrect();
        List<ImportedObject> GetImportedObjectAfterSplit();
    }
}