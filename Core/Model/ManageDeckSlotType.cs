using System;
using System.Collections.Generic;
using System.Text;
using Core.ComponentModel;
using Core;

namespace Core.Model
{
    public class ManageDeckSlotType : ISlotType
    {
        public string ManageType { get; set; }
        public string DeckName { get; set; }
        public List<CardModel> Cards { get; set; }

        public IEnumerable<ValidationError> Validate()
        {
            if (String.IsNullOrEmpty(ManageType) || String.IsNullOrWhiteSpace(ManageType))
                yield return new ValidationError() { ErrorMessage = String.Empty, PropertyName = String.Empty };
            else if(!Enum.GetValues(typeof(Constants.ManageTypes)).ToString().ToUpper().Contains(ManageType.ToUpper()))
                yield return new ValidationError() { ErrorMessage = String.Empty, PropertyName = String.Empty };
        }
    }
}
