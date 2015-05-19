using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CardSite1.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Post")]
        public string Post { get; set; }
        [Display(Name = "Place Of Employment")]
        public string Place { get; set; }


    }
}