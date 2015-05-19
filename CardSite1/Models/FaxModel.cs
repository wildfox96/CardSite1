using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardSite1.Models
{
    public class FaxModel
    {
        public int Id { get; set; }
        public string Fax { get; set; }
        public int? UserId { get; set; }
        public UserModel User { get; set; }
        public string Comment { get; set; }
    }
}
