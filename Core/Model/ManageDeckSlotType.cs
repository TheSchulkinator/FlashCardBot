using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class ManageDeckSlotType : BaseSlotType
    {
        public string ManageType { get; set; }
        public string DeckName { get; set; }
        public List<CardModel> Cards { get; set; }
    }
}
