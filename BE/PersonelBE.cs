using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PersonelBE
    {
        public PersonelBE()
        {
            DeleteStatus = false;
        }
        public int ID { get; set; }
        public bool DeleteStatus { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Pic { get; set; }
        public string Adress { get; set; }
        public int Age { get; set; }
        public string CodeMely { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public LibraryBE LibraryBES { get; set; }
    }
}
