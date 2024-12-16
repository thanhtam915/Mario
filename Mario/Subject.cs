using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Mario
{
    public class Subject
    {
        public static DataTable listSubject()
        {
            return Database.SelectQuery("select * from Subject");
        }
    }
}
