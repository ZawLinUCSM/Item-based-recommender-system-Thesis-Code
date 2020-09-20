using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataObject
{
    public class AttributesInfo
    {
        #region Variables
        AttributesDataAccess dataAccess;
        #endregion
        public string Attributes_Name { get; set; }
        public Array Equivalence_Classes { get; set; }

        public AttributesInfo()
        {
            dataAccess = new AttributesDataAccess();
        }

        public static void RetrieveMedicalList(DataTable _medicalDataTable)
        {
            _medicalDataTable.Clear();
            new AttributesDataAccess().RetrieveMedicalList(_medicalDataTable);
        }

        public static void GenerateAttributeList(DataTable _attributeDataTable)
        {
            _attributeDataTable.Clear();

        }
    }
}
