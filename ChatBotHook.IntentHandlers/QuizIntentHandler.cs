using Core;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBotHook.IntentHandlers
{
    public class QuizIntentHandler : BaseHandler<QuizSlotType>
    {
        protected override OutputModel<QuizSlotType> ProcessIntent()
        {
            var outputModel = new OutputModel<QuizSlotType>();

            outputModel.dialogAction.message.content = "Let the quiz begin";
            outputModel.dialogAction.intentName = Constants.INTENT_NAME_QUIZ;

            return outputModel;
        }
    }
}
