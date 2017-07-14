using ChatBotHook.DAL;
using Core;
using Core.Model;
using Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBotHook.IntentHandlers
{
    public class QuizIntentHandler : BaseHandler<QuizSlotType>
    {

        public QuizIntentHandler() { }

        public QuizIntentHandler(IDatabaseDAL dal) : base(dal) { }

        protected override OutputModel<QuizSlotType> ProcessIntent()
        {
            string fulfillmentState = null;
            string intentName = InputModel.CurrentIntent.Name;
            var slots = InputModel.CurrentIntent.Slots;
            var errors = InputModel.CurrentIntent.Slots.Validate();
            string slotToElicit = InputModel.CurrentIntent.Slots.GetSlotToElicit();
            string responseMessage = String.Empty;
            string quizOrder = slots.QuizOrder.ToLower();
            string quizProgression = slots.QuizProgression.ToLower();
    
            
            if(slotToElicit == nameof(QuizSlotType.DeckName))
            {
                responseMessage = "What is the name of the deck you'd like to be quizzed on?";

                var deck = Dal.GetAllDecks(InputModel.UserID);
                    
                for (int i = 0; i < deck.Count; i++)
                {
                    if (deck[i].DeckName.ToString().ToLower().Equals(slots.DeckName.ToString().ToLower()))
                    {
                        var userDeck = deck[i];
                        userDeck.Cards = userDeck.GetNonDeletedCards();
                        userDeck.ResetDeck();
                        Dal.UpdateDeck(userDeck);
                    }
                }

            }
            else if (slotToElicit == nameof(QuizSlotType.QuizOrder))
            {
                responseMessage = "Would you liked to be quizzed in a sequential or a random fashion?";

                if (quizOrder.Equals(Constants.QuizOrder.Random.ToString().ToLower()))
                {
                    var deck = Dal.GetDeck(InputModel.UserID, slots.DeckName.ToString().ToLower());

                    deck.IsQuizRandom = true;
                    Dal.UpdateDeck(deck);
                }
            }
            else if (slotToElicit == nameof(QuizSlotType.QuizProgression))
            {
              

                if (quizProgression == Constants.QuizProgression.Next.ToString().ToLower())
                {
                    //process next request
                }
                else if (quizProgression == Constants.QuizProgression.Previous.ToString().ToLower())
                {
                    //process previous
                }
                else if(quizProgression== Constants.QuizProgression.Skip.ToString().ToLower())
                {
                    //process skip
                }
                else if(quizProgression == Constants.QuizProgression.Stop.ToString().ToLower())
                {
                    //process stop
                }

                
            }

            var outputModel = new OutputModel<QuizSlotType>();
            outputModel.dialogAction.fulfillmentState = fulfillmentState;
            outputModel.dialogAction.slots = slots;
            outputModel.dialogAction.message.content = responseMessage;
            outputModel.dialogAction.message.contentType = Constants.RESPONSE_CONTENT_TYPE;
            outputModel.dialogAction.slotToElicit = slotToElicit;
            outputModel.dialogAction.intentName = intentName;
            return outputModel;
        }
    }
}
