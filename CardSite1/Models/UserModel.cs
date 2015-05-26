using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CardSite1.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Cookie { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public RoleModel Role { get; set; }
        public bool IsConfirmed { get; set; }

        [Display(Name = "Post")]
        public string Post { get; set; }

        [Display(Name = "Place Of Employment")]
        public string Place { get; set; }

        public virtual ICollection<CardModel> Cards { get; set; }
        public virtual ICollection<AddressModel> Addresses { get; set; }
        public virtual ICollection<ExternalEmailModel> ExternalEmails { get; set; }
        public virtual ICollection<ExternalLinkModel> ExternalLinks { get; set; }
        public virtual ICollection<FaxModel> Faxs { get; set; }
        public virtual ICollection<SkypeModel> Skypes { get; set; }
        public virtual ICollection<TelephoneNumberModel> TelephoneNumbers { get; set; } 

    }
}