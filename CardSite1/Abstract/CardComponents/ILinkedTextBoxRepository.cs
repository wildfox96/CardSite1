using CardSite1.Models.CardComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardSite1.Abstract.CardComponents
{
    public interface ILinkedTextBoxRepository
    {
        IQueryable<LinkedTextBoxModel> LinkedTextBoxs { get; }
        void CreateLinkedTextBox(LinkedTextBoxModel linkedTextBox);
        LinkedTextBoxModel GetLinkedTextBox(int id);
        IQueryable<LinkedTextBoxModel> GetLinkedTextBoxs(int cardId);
        void ChangeLinkedTextBox(LinkedTextBoxModel linkedTextBox);
        void DeleteLinkedTextBox(LinkedTextBoxModel linkedTextBox);
    }
}