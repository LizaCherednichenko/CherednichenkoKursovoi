﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CherednichenkoKursovoi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AirEntities : DbContext
    {

        private static AirEntities _context;

        public static AirEntities GetContext()
        {
            if ( _context == null )
                _context = new AirEntities();
            return _context;
        }

        public AirEntities()
            : base("name=AirEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Airplane> Airplane { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Passajir> Passajir { get; set; }
        public virtual DbSet<Reis> Reis { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Zakaz> Zakaz { get; set; }
    }
}
