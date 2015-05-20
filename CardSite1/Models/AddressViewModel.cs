using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardSite1.Models
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public string Comment { get; set; }
    }
}