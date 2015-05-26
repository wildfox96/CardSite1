using CardSite1.Models.CardComponents;
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

        //Card:

        public DbSet<CardModel> Cards { get; set; }
        public DbSet<RectangleModel> Rectangles { get; set; }
        public DbSet<TextBoxModel> TextBoxs { get; set; }
        public DbSet<LinkedTextBoxModel> LinkedTextBoxs { get; set; }

    }
}