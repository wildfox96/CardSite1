using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardSite1.Models.CardComponents
{
    public class RectangleModel
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        [JsonIgnore]
        public virtual CardModel Card { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }
    }
}