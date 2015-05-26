using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CardSite1.Abstract;
using CardSite1.Concrete;
using CardSite1.Infrastructure;
using CardSite1.Models;

namespace CardSite1.Controllers
{
    public class CardController : Controller
    {
        private ICardRepository cardRepository = new CardRepository();

        [HttpGet]
        public ActionResult Show(int id)
        {
            if (!cardRepository.Contains(id))
                return View("Error");
            return View(cardRepository.GetCard(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (!cardRepository.Contains(id))
                return View("Error");
            CardModel card = cardRepository.GetCard(id);
            if (AuthoriseData.GetUserId() != card.UserId)
                return View("Error");
            return View(card);
        }

        [HttpGet]
        public ActionResult MyCards()
        {
            return View(cardRepository.GetCards(AuthoriseData.GetUserId()));
        }
    }
}