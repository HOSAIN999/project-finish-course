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
    public class UserDAL
    {
        DB db = new DB();
        public string Create(UserBE U)
        {
            try
            {
                db.Users.Add(U);
                db.SaveChanges();
                return "ما تونستیم یک نفر دیگه به جمع کتاب خون ها اضافه کنیم";
            }
            catch (Exception e)
            {
                return "یک مشکلی یک جا 4343هست که منم نمیدونم \n" + e.Message;
            }
        }
        public string Update(UserBE U, int id)
        {
            var q = db.Users.Where(i => i.ID == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.Name = U.Name;
                    q.Father = U.Father;
                    q.Phone = U.Phone;
                    q.Age = U.Age;
                    q.CodeMely = U.CodeMely;
                    q.Email = U.Email;
                    q.Edocation = U.Edocation;
                    q.Pic = U.Pic;
                    q.Job = U.Job;
                    q.BirthPlace = U.BirthPlace;
                    q.Adress = U.Adress;
                    db.SaveChanges();
                    return "این مورد هم درست شد";
                }
                else
                {
                    return "اطمینان داری همچین عضوی داریم آخه من پیدا نکردم";
                }
            }
            catch (Exception e)
            {
                return "یک مشکلی یک جا هست که منم نمیدونم \n" + e.Message;
            }
        }
        public string Delete(int id)
        {
            var q = db.Users.Where(i => i.ID == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.DeleteStatus = true;
                    return "میدونستی از میانگین کتاب خونی کشور الان کم شد";
                }
                else
                {
                    return "اطمینان داری همچین عضوی داریم آخه من پیدا نکردم";
                }
            }
            catch (Exception e)
            {
                return "یک مشکلی یک جا هست که منم نمیدونم \n" + e.Message;
            }
        }
        public UserBE Read(int id)
        {
            return db.Users.Where(i => i.ID == id).FirstOrDefault();
        }
        public bool Read(UserBE U)
        {
            var q = db.Users.Where(i => U.CodeMely == i.CodeMely);
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
            string cmd = "SELECT ID, Name AS نام, Phone AS [شماره تماس], Job AS شغل FROM   dbo.UserBEs WHERE (DeleteStatus = 0)";
            SqlConnection con = new SqlConnection("data source=.;initial catalog = Library;integrated security=True");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable Read(string s)
        {
            SqlCommand cmd = new SqlCommand("[dbo].[USERSEARCH]");

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
        public string UserCount()
        {
            return db.Users.Where(i => i.DeleteStatus == false).Count().ToString();
        }
    }
}
