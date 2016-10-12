using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Admin.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Admin.DAL
{
    public class AdminContext : DbContext
    {
        public DbSet<LibraryItem> LibraryItem { get; set; }
        public DbSet<LibraryItemGroup> LibraryItemGroup { get; set; }
        public DbSet<LibraryItemType> LibraryItemType { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
