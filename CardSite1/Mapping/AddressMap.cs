using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using CardSite1.Models;

namespace CardSite1.Mapping
{
    public class AddressMap : EntityTypeConfiguration<AddressModel>
    {
        public AddressMap()
        {
            HasKey(t => t.Id);

            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Address).IsRequired();
            Property(t => t.Comment);
            Property(t => t.UserId).IsRequired();

            ToTable("AddressModels");

            HasRequired(t => t.User).WithMany(c => c.Addresses).HasForeignKey(t => t.UserId).WillCascadeOnDelete(true);
        }
    }
}