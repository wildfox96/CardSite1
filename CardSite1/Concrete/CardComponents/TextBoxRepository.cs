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
    public class TextBoxRepository : ITextBoxRepository
    {
        private Context db = new Context();

        public IQueryable<TextBoxModel> TextBoxs
        {
            get { return db.TextBoxs; }
        }

        public void CreateTextBox(TextBoxModel textBox)
        {
            db.TextBoxs.Add(textBox);
            db.SaveChanges();
        }

        public TextBoxModel GetTextBox(int id)
        {
            return db.TextBoxs.FirstOrDefault(textBox => textBox.Id == id);
        }

        public IQueryable<TextBoxModel> GetTextBoxs(int cardId)
        {
            return db.TextBoxs.Where(textBox => textBox.CardId == cardId);
        }

        public void ChangeTextBox(TextBoxModel textBox)
        {
            db.Entry(textBox).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteTextBox(TextBoxModel textBox)
        {
            db.TextBoxs.Remove(textBox);
            db.SaveChanges();
        }
    }
}