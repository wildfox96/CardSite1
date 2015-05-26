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
    public class RectangleMap : EntityTypeConfiguration<RectangleModel>
    {
        public RectangleMap()
        {
            HasKey(t => t.Id);

            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.CardId).IsRequired();
            Property(t => t.X);
            Property(t => t.Y);
            Property(t => t.Width);
            Property(t => t.Height);
            Property(t => t.Color);

            ToTable("RectangleModels");

            HasRequired(t => t.Card).WithMany(c => c.Rectangles).HasForeignKey(t => t.CardId).WillCascadeOnDelete(true);
        }
    }
}