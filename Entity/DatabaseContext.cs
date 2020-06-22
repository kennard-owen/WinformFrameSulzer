﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity {
    public class DatabaseContext : DbContext {
        public DatabaseContext() : base(new SQLiteConnection() {

           
            ConnectionString = new SQLiteConnectionStringBuilder() {

                DataSource = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DB\\sulzer.db"),
                ForeignKeys = true
            }.ConnectionString
        }, true) {


        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<EmployeeMaster> EmployeeMaster { get; set; }
    }

}
