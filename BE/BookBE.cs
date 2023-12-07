using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BookBE
    {
        public BookBE()
        {
            Stock = false;
            DeleteStatus = false;
        }
        public int ID { get; set; }
        public bool DeleteStatus { get; set; }
        public Nullable<bool> Stock { get; set; }
        public string Name { get; set; }
        public string Puplisher { get; set; }
        public int Radif { get; set; }
        public string Title { get; set; }
        public string Presenter { get; set; }
        public List<LibraryBE> LibraryBES { get; set; } = new List<LibraryBE>();
    }
}
