using System;
using System.Collections.Generic;
using System.Text;
using Core.ComponentModel;
using Core;
using System.Linq;

namespace Core.Model
{
    public class ManageDeckSlotType : ISlotType
    {
        public string ManageType { get; set; }
        public string DeckName { get; set; }
        public string JSONFile { get; set; }

        public string GetSlotToElicit()
        {
            string slotTypeToElicit = String.Empty;
            if (String.IsNullOrEmpty(ManageType) || String.IsNullOrWhiteSpace(ManageType))
                slotTypeToElicit =  nameof(ManageType);
            
            return slotTypeToElicit;
        }

        public IEnumerable<ValidationError> Validate()
        {
            if (String.IsNullOrEmpty(ManageType) || String.IsNullOrWhiteSpace(ManageType))
                yield return new ValidationError() { ErrorMessage = String.Empty, PropertyName = String.Empty };
            else if(!Enum.GetNames(typeof(Constants.ManageTypes)).Select(manageType => manageType.ToUpper()).ToList().Contains(ManageType.ToUpper()))
                yield return new ValidationError() { ErrorMessage = String.Empty, PropertyName = String.Empty };
        }
    }
}
