﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FmsEntities : DbContext
    {
        public FmsEntities()
            : base("name=FmsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AgeClassEnum> AgeClassEnums { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<PurchasedTicket> PurchasedTickets { get; set; }
        public virtual DbSet<SeatClassEnum> SeatClassEnums { get; set; }
        public virtual DbSet<SeatInfo> SeatInfos { get; set; }
        public virtual DbSet<Stoppage> Stoppages { get; set; }
        public virtual DbSet<Transport> Transports { get; set; }
        public virtual DbSet<TransportSchedule> TransportSchedules { get; set; }
        public virtual DbSet<UserRoleEnum> UserRoleEnums { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
