using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.Entity
{
    public class Deck
    {
        public string UserID { get; set; }
        public string DeckName { get; set; }
        private List<Card> _Cards;
        public List<Card> Cards
        {
            get
            {
                if (_Cards == null)
                {
                    _Cards = new List<Card>();
                }
                return _Cards;
            }
            set
            {
                _Cards = value;
            }
        }
    }

    public class Card
    {
        public string Front { get; set; }
        public string Back { get; set; }
    }
}
