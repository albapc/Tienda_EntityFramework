﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TiendaInterfaz
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TIENDADBEntities : DbContext
    {
        public TIENDADBEntities()
            : base("name=TIENDADBEntities")
        {
        }

        public TIENDADBEntities(string server, string database)
            : base("metadata=res://*/Tienda.csdl|res://*/Tienda.ssdl|res://*/Tienda.msl;provider=System.Data.SqlClient;provider connection string='data source=" + server + ",1433;initial catalog=" + database + ";integrated security=True;MultipleActiveResultSets=True;App=EntityFramework'")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<MARCA> MARCAs { get; set; }
        public virtual DbSet<PRODUCTO> PRODUCTOes { get; set; }
        public virtual DbSet<TICKET> TICKETs { get; set; }
        public virtual DbSet<TICKETDETALLE> TICKETDETALLEs { get; set; }
        public virtual DbSet<TIPOPRODUCTO> TIPOPRODUCTOes { get; set; }
    }
}
