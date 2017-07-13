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
            string fulfillmentState = null;
            string intentName = InputModel.CurrentIntent.Name;
            var slots = InputModel.CurrentIntent.Slots;
            var errors = InputModel.CurrentIntent.Slots.Validate();
            string slotToElicit = InputModel.CurrentIntent.Slots.GetSlotToElicit();
            string responseMessage = String.Empty;

            if(slotToElicit == nameof(QuizSlotType.DeckName))
            {
                responseMessage = "What is the name of the deck you'd like to be quizzed on?";
            }
            else if (slotToElicit == nameof(QuizSlotType.QuizOrder))
            {
                responseMessage = "Would you liked to be quizzed in a sequential or a random fashion?";
            }
            else if (slotToElicit == nameof(QuizSlotType.QuizProgression))
            {
                if
            }

                var outputModel = new OutputModel<QuizSlotType>();

            outputModel.dialogAction.message.content = "Let the quiz begin";
            outputModel.dialogAction.intentName = Constants.INTENT_NAME_QUIZ;

            return outputModel;
        }
    }
}
