using Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotHook.DAL
{
    public interface IDatabaseDAL
    {
        void AddNewDeck(string userId, string deckName, Deck deck = null);
        Deck GetDeck(string userId, string deckName);
        bool DeckExits(string userId, string deckName);
        void AddCardToDeck(string userId, string deckName, string front, string back);
        void AddCardToDeck(string userId, string deckName, Card card);
        void UpdateDeck(Deck deck);
    }
}
