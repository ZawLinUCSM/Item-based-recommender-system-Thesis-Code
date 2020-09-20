using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    class AttributesDataAccess:DataAccessBase
    {

        internal void RetrieveMedicalList(System.Data.DataTable _medicalDataTable)
        {
            Command.CommandText = @"SELECT * FROM DecisionTable";
            LoadDataTable(_medicalDataTable);
        }
    }
}
