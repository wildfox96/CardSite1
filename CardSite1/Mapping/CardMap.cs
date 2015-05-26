using CardSite1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CardSite1.Mapping
{
    public class CardMap : EntityTypeConfiguration<CardModel>
    {
        public CardMap()
        {
            HasKey(t => t.Id);

            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.UserId).IsRequired();
            Property(t => t.Name);
            Property(t => t.Color);

            ToTable("CardModels");

            HasRequired(t => t.User).WithMany(c => c.Cards).HasForeignKey(t => t.UserId).WillCascadeOnDelete(true);
        }
    }
}