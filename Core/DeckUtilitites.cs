using Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class DeckUtilitites
    {
        private const string deckFormat = "{0}, ";
        public static string CreateDeckNameString(List<Deck> allDecks)
        {
            string all = String.Empty;
            if (allDecks == null)
                return all;
            StringBuilder sb = new StringBuilder();
            allDecks.ForEach(deck => sb.Append(String.Format(deckFormat, deck.DeckName)));

            return sb.ToString().Trim().TrimEnd(new char[] { ',' });
        }
    }
}
