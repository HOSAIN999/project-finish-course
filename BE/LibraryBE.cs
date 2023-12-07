using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class LibraryBE
    {
        public LibraryBE()
        {
            DeleteStatus = false;
        }
        public int ID { get; set; }
        public bool DeleteStatus { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Boss { get; set; }
        public string Phone { get; set; }
        public DateTime DateSet { get; set; }
        public List<PersonelBE> PersonelBEs { get; set; } = new List<PersonelBE>();
        public List<BookBE> BookBEs { get; set; } = new List<BookBE>();
        public List<UserBE> UserBEs { get; set; } = new List<UserBE>();
    }
}
