﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WFTest1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TCSEntities : DbContext
    {
        public TCSEntities()
            : base("name=TCSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Activity> Activities { get; set; }
        public DbSet<AddmissionInstance> AddmissionInstances { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Form_Divsion> Form_Divsion { get; set; }
        public DbSet<Monitering> Moniterings { get; set; }
        public DbSet<Pending> Pendings { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<webpages_Membership> webpages_Membership { get; set; }
        public DbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public DbSet<webpages_Roles> webpages_Roles { get; set; }
        public DbSet<webpages_UsersInRoles> webpages_UsersInRoles { get; set; }
    }
}