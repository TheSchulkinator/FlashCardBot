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
        public string Front { get; set; }
        public string Back { get; set; }

        public string GetSlotToElicit()
        {
            if (String.IsNullOrEmpty(ManageType) || String.IsNullOrWhiteSpace(ManageType))
                return nameof(ManageType);
            if (String.IsNullOrEmpty(DeckName) || String.IsNullOrWhiteSpace(DeckName))
                return nameof(DeckName);
            if (ManageType == Constants.ManageTypes.Delete.ToString())
            {
                if (String.IsNullOrEmpty(Front) || String.IsNullOrWhiteSpace(Front))
                    return nameof(Front);
                if (String.IsNullOrEmpty(Back) || String.IsNullOrWhiteSpace(Back))
                    return nameof(Back);
            }
            return String.Empty;
        }

        public IEnumerable<ValidationError> Validate()
        {
            if (String.IsNullOrEmpty(ManageType) || String.IsNullOrWhiteSpace(ManageType))
                yield return new ValidationError() { ErrorMessage = String.Format(Constants.ERROR_MESSAGE_INVALID_VALUE, "Manage Type"), PropertyName = nameof(ManageType) };
            else if(!Enum.GetNames(typeof(Constants.ManageTypes)).Select(manageType => manageType.ToUpper()).ToList().Contains(ManageType.ToUpper()))
                yield return new ValidationError() { ErrorMessage = String.Empty, PropertyName = nameof(ManageType) };
        }
    }
}
