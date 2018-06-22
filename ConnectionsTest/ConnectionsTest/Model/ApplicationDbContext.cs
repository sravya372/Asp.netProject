using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConnectionsTest.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {

        }
        //create a DB Set property to add connections to database
        public DbSet<Connections> ConnectionItems { get; set; }
        //**this property is a table in your database


    }
}
