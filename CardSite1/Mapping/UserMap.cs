using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using CardSite1.Models;

namespace CardSite1.Mapping
{
    public class UserMap : EntityTypeConfiguration<UserModel>
    {
        public UserMap()
        {
            HasKey(t => t.Id);

            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.FirstName);
            Property(t => t.LastName);
            Property(t => t.Email);
            Property(t => t.Post);
            Property(t => t.Place);

            ToTable("UserModels");
        }
    }
}