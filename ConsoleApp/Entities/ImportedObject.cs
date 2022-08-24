﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class ImportedObject : ImportedObjectBase
    {
        public string Schema { get; set; }
        public string ParentName { get; set; }
        public string ParentType { get; set; } 
        public string DataType { get; set; }
        public string IsNullable { get; set; }
        public int NumberOfChildren { get; set; }
    }
}
