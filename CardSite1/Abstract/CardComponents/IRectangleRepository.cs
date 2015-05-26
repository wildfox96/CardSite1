using CardSite1.Models.CardComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardSite1.Abstract.CardComponents
{
    public interface IRectangleRepository
    {
        IQueryable<RectangleModel> Rectangles { get; }
        void CreateRectangle(RectangleModel rectangle);
        RectangleModel GetRectangle(int id);
        IQueryable<RectangleModel> GetRectangles(int cardId);
        void ChangeRectangle(RectangleModel rectangle);
        void DeleteRectangle(RectangleModel rectangle);
    }
}