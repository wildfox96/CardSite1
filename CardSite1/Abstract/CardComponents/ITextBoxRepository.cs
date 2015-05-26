using CardSite1.Models.CardComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardSite1.Abstract.CardComponents
{
    public interface ITextBoxRepository
    {
        IQueryable<TextBoxModel> TextBoxs { get; }
        void CreateTextBox(TextBoxModel textBox);
        TextBoxModel GetTextBox(int id);
        IQueryable<TextBoxModel> GetTextBoxs(int cardId);
        void ChangeTextBox(TextBoxModel textBox);
        void DeleteTextBox(TextBoxModel textBox);
    }
}