using ChatBotHook.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Model.Entity;
using System.Threading.Tasks;

namespace ChatBotHook.IntentHandlers.Test.Mock
{
    public class MockDAL : IDatabaseDAL
    {
        public bool AddDeckCalled { get; set; }
        public bool GetDeckCalled { get; set; }
        public bool UpdateDeckCalled { get; set; }
        public Data LastDataPassed { get; set; }

        public void AddNewDeck(string userId, string deckName, Deck deck = null)
        {
            AddDeckCalled = true;
            LastDataPassed = new Data()
            {
                UserId = userId,
                DeckName = deckName,
                Deck = deck
            };
        }

        public Deck GetDeck(string userId, string deckName)
        {
            GetDeckCalled = true;
            LastDataPassed = new Data()
            {
                UserId = userId,
                DeckName = deckName
            };
            return new Deck();
        }

        public void UpdateDeck(Deck deck)
        {
            UpdateDeckCalled = true;
            LastDataPassed = new Data()
            {
                Deck = deck
            };
        }
    }
    public class Data
    {
        public string UserId { get; set; }
        public string DeckName { get; set; }
        public Deck Deck { get; set; }
    }

}
