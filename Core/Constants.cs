using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Constants
    {
        //Messages
        public const string STRING_FORMAT_PROPERTY_VALUE = "{0} : {1}, ";

        //Error Messages
        public const string ERROR_MESSAGE_INVALID_VALUE = "{0} is invalid.";
        public const string ERROR_MESSAGE_RETRY_RESPONSE = "{0}";

        //Response Names
        public const string RESPONSE_CONTENT_TYPE = "PlainText";

        //IntentNames
        public const string INTENT_NAME_MANAGE_DECKS = "ManageDecks";

        //Sommething else
        public enum ManageTypes
        {
            Add,
            Modify,
            Delete
        }
    }
}
