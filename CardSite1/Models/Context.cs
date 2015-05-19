using System;
using System.Data.Entity;

namespace CardSite1.Models
{
    public class Context : DbContext
    {
        public Context() : base("CardSite1Db")
        { }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<ExternalEmailModel> Emails { get; set; }
        public DbSet<TelephoneNumberModel> TelephoneNumbers { get; set; }
        public DbSet<FaxModel> Faxs { get; set; }
        public DbSet<SkypeModel> Skypes { get; set; }
        public DbSet<ExternalLinkModel> Links { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<AddressModel>()
        //                .HasRequired<UserModel>(s => s.User)
        //                .WithMany(s => s.Addresses)
        //                .HasForeignKey(s => s.UserId);
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}