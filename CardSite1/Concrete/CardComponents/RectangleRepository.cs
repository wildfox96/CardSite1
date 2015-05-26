using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CardSite1.Abstract.CardComponents;
using CardSite1.Models.CardComponents;
using CardSite1.Models;
using System.Data.Entity;

namespace CardSite1.Concrete.CardComponents
{
    public class RectangleRepository : IRectangleRepository
    {
        private Context db = new Context();

        public IQueryable<RectangleModel> Rectangles
        {
            get { return db.Rectangles; }
        }

        public void CreateRectangle(RectangleModel rectangle)
        {
            db.Rectangles.Add(rectangle);
            db.SaveChanges();
        }

        public RectangleModel GetRectangle(int id)
        {
            return db.Rectangles.FirstOrDefault(rectangle => rectangle.Id == id);
        }

        public IQueryable<RectangleModel> GetRectangles(int cardId)
        {
            return db.Rectangles.Where(rectangle => rectangle.CardId == cardId);
        }

        public void ChangeRectangle(RectangleModel rectangle)
        {
            db.Entry(rectangle).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteRectangle(RectangleModel rectangle)
        {
            db.Rectangles.Remove(rectangle);
            db.SaveChanges();
        }
    }
}