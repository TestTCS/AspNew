using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using AspDemoApp.DB;
using AspDemoApp.Models;

namespace AspDemoApp.DB
{
    public class MyDbContext: DbContext
    {
        public MyDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
           // options.UseSqlServer(@"Server=****;Database=***;user id=***;password=***");
        }


        public MyDbContext(Microsoft.Data.Entity.Infrastructure.DbContextOptions options): base(options)
        {

        }


        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Author> Authors { get; set; }

    }
}
