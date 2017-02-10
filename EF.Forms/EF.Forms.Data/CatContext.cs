using System;
using Microsoft.EntityFrameworkCore;

namespace EF.Forms.Data
{
	public class CatContext: DbContext
    {
        public DbSet<Cat> Cats { get; set; }
 
        private string DatabasePath { get; set; }
 
        public CatContext()
        {
 
        }
 
        public CatContext(string databasePath)
        {
            DatabasePath = databasePath;
        }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }
    }
}