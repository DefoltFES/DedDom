﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DedDom
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class heroku_b27ae8c6ecb20b8Entities1 : DbContext
    {
        public heroku_b27ae8c6ecb20b8Entities1()
            : base("name=heroku_b27ae8c6ecb20b8Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<@class> classes { get; set; }
        public virtual DbSet<classrom> classroms { get; set; }
        public virtual DbSet<group> groups { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<schedule> schedules { get; set; }
        public virtual DbSet<student> students { get; set; }
        public virtual DbSet<subject> subjects { get; set; }
        public virtual DbSet<teacher> teachers { get; set; }
        public virtual DbSet<visit_log> visit_log { get; set; }
        public virtual DbSet<week_day> week_day { get; set; }
    }
}
