using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBotHook.IntentHandlers
{
    public class FlashCardBotIntentCreator : IntentCreator
    {
        public override IIntentHandler CreateIntentHandler(string intentName)
        {
            IIntentHandler intentHandler = null;
            if (intentName == "addorrecognizeuser")
                intentHandler = new AddOrRecognizeHandler();
            if(intentName == "bookcar")
                intentHandler = new AddOrRecognizeHandler();

            return intentHandler;
        }
    }
}
