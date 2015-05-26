using CardSite1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardSite1.Abstract
{
    public interface ICardRepository
    {
        IQueryable<CardModel> Cards { get; }
        void CreateCard(CardModel card);
        CardModel GetCard(int id);
        IQueryable<CardModel> GetCards(int userId);
        void ChangeCard(CardModel card);
        void DeleteCard(CardModel card);
        Boolean Contains(int id);
    }
}