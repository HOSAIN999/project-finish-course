using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class UserBE
    {
        public UserBE()
        {
            DeleteStatus = false;
        }
        public int ID { get; set; }
        public bool DeleteStatus { get; set; }
        public string Name { get; set; }
        public string Father { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public string CodeMely { get; set; }
        public string Email { get; set; }
        public string Edocation { get; set; }
        public bool Meliat { get; set; }
        public bool Gender { get; set; }
        public bool Marriage { get; set; }
        public DateTime Date { get; set; }
        public string Pic { get; set; }
        public string Job { get; set; }
        public string BirthPlace { get; set; }
        public string Adress { get; set; }
        public List<LibraryBE> libraryBES { get; set; } = new List<LibraryBE>();
    }
}
