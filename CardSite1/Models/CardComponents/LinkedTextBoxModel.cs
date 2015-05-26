using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardSite1.Models.CardComponents
{
    public class LinkedTextBoxModel
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public CardModel Card { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Color { get; set; }
    }
}