using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class BookDAL
    {
        DB db = new DB();
        public string Create(BookBE B)
        {
            try
            {
                db.Books.Add(B);
                db.SaveChanges();
                return "خوب عالی شدداره منابع کتابمون زیاد میشه";
            }
            catch (Exception e)
            {
                return "یک مشکلی یک جا هست که منم نمیدونم \n" + e.Message;
            }
        }
        public string Delete(int id)
        {
            var q = db.Books.Where(i => i.ID == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.DeleteStatus = true;
                    db.SaveChanges();
                    return "فقط بگو کتاب رو سالم بیاره";
                }
                else
                {
                    return "کتاب رو بردن برای مطالعه";
                }
            }
            catch (Exception e)
            {
                return "یک مشکلی یک جا هست که منم نمیدونم \n" + e.Message;
            }
        }
        public string Update(BookBE B, int id)
        {
            var q = db.Books.Where(i => i.ID == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.Name = B.Name;
                    q.Puplisher = B.Puplisher;
                    q.Radif = B.Radif;
                    q.Title = B.Title;
                    q.Presenter = B.Presenter;
                    db.SaveChanges();
                    return "خوب این کتاب رو هم درست کردیم";
                }
                else
                {
                    return "این کتاب رو پیدا نکردم";
                }
            }
            catch (Exception e)
            {
                return "یک مشکلی یک جا هست که منم نمیدونم \n" + e.Message;
            }
        }
        public BookBE Read(int id)
        {
            return db.Books.Where(i => i.ID == id).FirstOrDefault();
        }
        public string BookCount()
        {
            return db.Books.Where(i => i.DeleteStatus == false).Count().ToString();
        }
        public List<BookBE> Readb()
        {
            return db.Books.Where(i => i.Stock == true).ToList();
        }
        public DataTable Read()
        {
            string cmd = "SELECT ID, Radif AS ردیف, Name AS [نام کتاب], Puplisher AS [نام ناشر], Title AS موضوع, Stock AS [موجود هست] FROM   dbo.BookBEs WHERE (Stock = 0)";
            SqlConnection con = new SqlConnection("data source=.;initial catalog = Library;integrated security=True");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable Read(string s, int index)
        {
            SqlCommand cmd = new SqlCommand();
            if (index == 0)
            {
                cmd.CommandText = "[dbo].[BOOKNAME]";
            }
            else if (index == 1)
            {
                cmd.CommandText = "[dbo].[BOOKTITLE]";
            }
            else if (index == 2)
            {
                cmd.CommandText = "[dbo].[BOOKPUPLISHER]";
            }
            SqlConnection con = new SqlConnection("data source=.;initial catalog = Library;integrated security=True");

            cmd.Parameters.AddWithValue("@Seabookn", s);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
    }
}
