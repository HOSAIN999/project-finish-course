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
    public class LibraryDAL
    {
        DB db = new DB();

        public string Create(LibraryBE L)
        {
            try
            {
                db.Libraries.Add(L);
                db.SaveChanges();
                return "خوب عالی شد کتاب خونه با موفقیت ثبت شد";
            }
            catch (Exception e)
            {
                return "یک مشکلی یک جا هست که منم نمیدونم \n" + e.Message;
            }
        }
        public string Update(LibraryBE L, int ID)
        {
            var q = db.Libraries.Where(i => L.ID == ID).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.Name = L.Name;
                    q.Adress = L.Adress;
                    q.Boss = L.Boss;
                    q.Phone = L.Phone;
                    db.SaveChanges();
                    return "عالی شد اینم درست کردیم";
                }
                else
                {
                    return "این کتابخونه رو پیدا نمیکنم  \n " + "لطفا یکم دقت کن ";
                }
            }
            catch (Exception e)
            {
                return "یک مشکلی یک جا هست که منم نمیدونم \n" + e.Message;
            }
        }
        public string Delete(int ID)
        {
            var q = db.Libraries.Where(i => i.ID == ID).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.DeleteStatus = true;
                    db.SaveChanges();
                    return "بعدا از این حذفت پشیمون میشی";
                }
                else
                {
                    return "این کتابخونه رو پیدا نمیکنم  \n " + "لطفا یکم دقت کن ";
                }
            }
            catch (Exception e)
            {
                return "یک مشکلی یک جا هست که منم نمیدونم \n" + e.Message;
            }
        }
        public bool Read(LibraryBE L)
        {
            var q = db.Libraries.Where(i => L.Name == i.Name);
            if (q.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable Read()
        {
            string cmd = "SELECT ID, Name AS [نام کتابخانه], Boss AS مدیر, Phone AS [شماره تماس], Adress AS [آدرس کتابخانه] FROM   dbo.LibraryBEs WHERE (DeleteStatus = 0)";
            SqlConnection con = new SqlConnection("data source=.;initial catalog = Library;integrated security=True");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];


        }
        public LibraryBE Read(int id)
        {
            return db.Libraries.Where(i => i.ID == id).FirstOrDefault();
        }
        public DataTable Read(string s)
        {
            SqlCommand cmd = new SqlCommand("[dbo].[SearchLibrary]");

            SqlConnection con = new SqlConnection("data source=.;initial catalog = Library;integrated security=True");

            cmd.Parameters.AddWithValue("@SEALibrary", s);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public List<string> ReadNameLI()
        {
            return db.Libraries.Where(i => i.DeleteStatus == false).Select(i => i.Name).ToList();
        }
        public LibraryBE ReadName(string N)
        {
            return db.Libraries.Where(i => i.Name == N).SingleOrDefault();
        }
    }
}
