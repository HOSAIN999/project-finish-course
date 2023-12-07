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
    public class PersonelDAL
    {
        DB db = new DB();
        public string Create(PersonelBE P)
        {
            try
            {
                db.Personels.Add(P);
                db.SaveChanges();
                return "همکار جدید هم اومد هوا شو داشته باش";
            }
            catch (Exception e)
            {
                return "یک مشکلی یک جا هست که منم نمیدونم \n" + e.Message;
            }
        }
        public bool Read(PersonelBE P)
        {
            var q = db.Personels.Where(i => P.CodeMely == i.CodeMely);
            if (q.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string Update(PersonelBE P, int id)
        {
            var q = db.Personels.Where(i => i.ID == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.Name = P.Name;
                    q.UserName = P.UserName;
                    q.Adress = P.Adress;
                    q.Age = P.Age;
                    q.CodeMely = P.CodeMely;
                    q.Phone = P.Phone;
                    q.Email = P.Email;
                    q.Pic = P.Pic;
                    q.Education = P.Education;
                    q.Password = P.Password;
                    db.SaveChanges();
                    return "این همکار رو هم اطلاعاتش رو درست کردیم";
                }
                else
                {
                    return "اطمینان داری همچین همکاری داریم آخه من پیدا نکردم";
                }
            }
            catch (Exception e)
            {
                return "یک مشکلی یک جا هست که منم نمیدونم \n" + e.Message;
            }
        }
        public string Delete(int id)
        {
            var q = db.Personels.Where(i => i.ID == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.DeleteStatus = true;
                    db.SaveChanges();
                    return "حیف شد همکار خوبی بود کاش میشد بیشتر همکاری کنیم";
                }
                else
                {
                    return "اطمینان داری همچین همکاری داریم آخه من پیدا نکردم";
                }
            }
            catch (Exception e)
            {
                return "یک مشکلی یک جا هست که منم نمیدونم \n" + e.Message;
            }
        }
        public PersonelBE Read(int id)
        {
            return db.Personels.Where(i => i.ID == id).FirstOrDefault();
        }
        public DataTable Read()
        {
            string cmd = "SELECT ID, Name AS [نام همکار], Phone AS [شماره تماس] FROM   dbo.PersonelBEs WHERE (DeleteStatus = 0)";
            SqlConnection con = new SqlConnection("data source=.;initial catalog = Library;integrated security=True");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public bool Isregistered()
        {
            return db.Users.Count() > 0;
        }
        public PersonelBE Login(string U, string P)
        {
            return db.Personels.Where(i => i.UserName == U && i.Password == P).SingleOrDefault();
        }
    }
}
