using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Model
{
    public class LibraryContext : DbContext
    {
        public  DbSet<Book> Books { get; set; }
        public  DbSet<Loan> Loans { get; set; }
        public  DbSet<Users> User { get; set; }
        public DbSet<Member> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True");
        }
    }
}
