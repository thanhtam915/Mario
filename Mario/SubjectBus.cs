using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Mario
{
    public class SubjectBus
    {
        public int Id_SJ {  get; set; }
        public string Name_SJ { get; set; }
        public static List<SubjectBus> listSubjects()
        {
            DataTable dt = Subject.listSubject();
            List<SubjectBus> list = new List<SubjectBus>();
            foreach (DataRow dr in dt.Rows)
            {
                SubjectBus item = new SubjectBus();
                item.Id_SJ = Convert.ToInt32(dr["Subject ID"]);
                item.Name_SJ = Convert.ToString(dr["Subject"]).Trim();
                list.Add(item);
            }
            return list;
        }
        public override string ToString()
        {
            return this.Name_SJ;

    }
}
