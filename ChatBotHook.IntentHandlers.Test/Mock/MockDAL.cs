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
        public bool GetAllDecksCalled { get; set; }
        public bool UpdateDeckCalled { get; set; }
        public bool AddCardToDeckCaleled { get; set; }
        public bool DeleteDeckCalled { get; set; }
        public Data LastDataPassed { get; set; }
        public bool DeckExists = false;

        public void AddCardToDeck(string userId, string deckName, string front, string back)
        {
            AddCardToDeckCaleled = true;
            LastDataPassed = new Data()
            {
                UserId = userId,
                DeckName = deckName,
                Deck = new Deck()
                {
                    Cards = new List<Card>()
                    {
                        new Card()
                        {
                            Front = front,
                            Back = back
                        }
                    }
                }
            };
        }

        public void AddCardToDeck(string userId, string deckName, Card card)
        {
            AddCardToDeckCaleled = true;
            LastDataPassed = new Data()
            {
                UserId = userId,
                DeckName = deckName,
                Deck = new Deck()
                {
                    Cards = new List<Card>() { card }
                }
            };
        }

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

        
        public bool DeckExits(string userId, string deckName)
        {
            return DeckExists;
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

        public List<Deck> GetAllDecks(string userId)
        {
            GetAllDecksCalled = true;
            LastDataPassed = new Data()
            {
                UserId = userId
            };
            return new List<Deck>();
        }

        public void UpdateDeck(Deck deck)
        {
            UpdateDeckCalled = true;
            LastDataPassed = new Data()
            {
                Deck = deck
            };
        }

        public void DeleteDeck(string userId, string deckName)
        {
            DeleteDeckCalled = true;
            LastDataPassed = new Data()
            {
                UserId = userId,
                DeckName = deckName
            };
        }

        public void Reset()
        {
            AddDeckCalled = false;
            GetDeckCalled = false;
            UpdateDeckCalled = false;
            AddCardToDeckCaleled = false;
            GetAllDecksCalled = false;
            DeleteDeckCalled = false;
            LastDataPassed = null;
            DeckExists = false;
        }
    }
    public class Data
    {
        public string UserId { get; set; }
        public string DeckName { get; set; }
        public Deck Deck { get; set; }
    }

}
