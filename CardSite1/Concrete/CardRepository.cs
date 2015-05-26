using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CardSite1.Abstract;
using CardSite1.Models;
using System.Data.Entity;

namespace CardSite1.Concrete
{
    public class CardRepository : ICardRepository
    {
        private Context db = new Context();

        public IQueryable<CardModel> Cards
        {
            get { return db.Cards; }
        }

        public void CreateCard(CardModel card)
        {
            db.Cards.Add(card);
            db.SaveChanges();
        }

        public CardModel GetCard(int id)
        {
            return db.Cards.FirstOrDefault(card => card.Id == id);
        }

        public IQueryable<CardModel> GetCards(int userId)
        {
            return db.Cards.Where(card => card.UserId == userId);
        }

        public void ChangeCard(CardModel card)
        {
            db.Entry(card).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteCard(CardModel card)
        {
            // TODO: delete all components
            db.Cards.Remove(card);
            db.SaveChanges();
        }

        public bool Contains(int id)
        {
            return GetCard(id) != default(CardModel) ? true : false;
        }
    }
}