using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Geopharm_testttt.Models;
// using Geopharm_testttt.Entities;

namespace Geopharm_testttt.Data
{
    internal class ApplicationContext: DbContext
    {
        private string dataSource = @"DESKTOP-O98QPDO\SQLEXPRESS";
        private string dataBase = "Geopharm";
        private string userName = "DESKTOP-O98QPDO\\User";
        private string connectionString;
        public SqlConnection connection;
        public DbSet<Box> Boxes { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            this.connectionString = @"Data Source=" + dataSource + ";Initial Catalog="
                        + dataBase + ";Persist Security Info=True;User ID=" + userName + ";Trusted_Connection=True;" + ";TrustServerCertificate=True;" + "Encrypt=False;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
