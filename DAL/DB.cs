using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BE;

namespace DAL
{
    public class DB : DbContext
    {
        public DB() : base("conect")
        {

        }
        public DbSet<LibraryBE> Libraries { get; set; }
        public DbSet<BookBE> Books { get; set; }
        public DbSet<PersonelBE> Personels { get; set; }
        public DbSet<UserBE> Users { get; set; }
    }
}
