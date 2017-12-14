using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.MMSync;

namespace Test.MMSync
{
    class Program
    {
        static void Main(string[] args)
        {
            Services.MMSync.MMSyncronize mms = new Services.MMSync.MMSyncronize();
            mms.Process();
        }
    }
}
