﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rpmmm
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WiseLanceEntities3 : DbContext
    {
        public WiseLanceEntities3()
            : base("name=WiseLanceEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adminis> Adminis { get; set; }
        public virtual DbSet<Ispolnitel> Ispolnitel { get; set; }
        public virtual DbSet<Koncurs> Koncurs { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Zakaz> Zakaz { get; set; }
        public virtual DbSet<Zakazchik> Zakazchik { get; set; }
    }
}
