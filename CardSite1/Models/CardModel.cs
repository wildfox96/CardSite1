using CardSite1.Models.CardComponents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardSite1.Models
{
    public class CardModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual UserModel User { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public virtual ICollection<RectangleModel> Rectangles { get; set; }
        public virtual ICollection<TextBoxModel> TextBoxs { get; set; }
    }
}