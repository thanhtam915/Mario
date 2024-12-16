using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Mario
{
    internal class QuestionsBus
    {
        public int ID_Question { get; set; }
        public int ID_SJ { get; set; }
        public string Question {  get; set; }
        public string DA1 { get; set; }
        public string DA2 { get; set; }
        public string DA3 { get; set; }
        public string DA4 { get; set; }
        public string DA { get; set; }
        public static List<QuestionsBus> listQuestion(int ID_SJ)
        {
            DataTable dt = Questions.listQuestion(ID_SJ);
            List<QuestionsBus> list = new List<QuestionsBus>();
            foreach(DataRow dr in dt.Rows)
            {
                QuestionsBus item = new QuestionsBus();
                item.ID_Question = Convert.ToInt32(dr["ID_Question"]);
                item.ID_SJ = Convert.ToInt32(dr["ID_Subject"]);
                item.Question = Convert.ToString(dr["Question"]).Trim();
                item.DA1 = Convert.ToString(dr["DA1"]).Trim();
                item.DA2 = Convert.ToString(dr["DA2"]).Trim();
                item.DA3 = Convert.ToString(dr["DA3"]).Trim();
                item.DA4 = Convert.ToString(dr["DA4"]).Trim();
                item.DA = Convert.ToString(dr["DA"]).Trim();
                list.Add(item);
            }
            return list;
        }
    }
}
