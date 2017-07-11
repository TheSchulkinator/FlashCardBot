using Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBotHook.DAL
{
    public interface IDatabaseDAL
    {
        void AddNewDeck(string userId, string deckName, Deck deck = null);
        Deck GetDeck(string userId, string deckName);
        void UpdateDeck(Deck deck);
    }
}
