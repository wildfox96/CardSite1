using CardSite1.Models;
using CardSite1.Models.CardComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CardSite1.Mapping.CardComponents
{
    public class TextBoxMap : EntityTypeConfiguration<TextBoxModel>
    {
        public TextBoxMap()
        {
            HasKey(t => t.Id);

            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.CardId).IsRequired();
            Property(t => t.X);
            Property(t => t.Y);
            Property(t => t.Text);
            Property(t => t.Color);

            ToTable("TextBoxModels");

            HasRequired(t => t.Card).WithMany(c => c.TextBoxs).HasForeignKey(t => t.CardId).WillCascadeOnDelete(true);
        }
    }
}