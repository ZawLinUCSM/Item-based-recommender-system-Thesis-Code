using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
   public class TestConnection
    {
       TestConnectionAccess access;
       public TestConnection()
       {
           access = new TestConnectionAccess();
       }
       public bool TestDBConnection()
       {
           access.OpenConnection();

           return true;
       }
    }
}
