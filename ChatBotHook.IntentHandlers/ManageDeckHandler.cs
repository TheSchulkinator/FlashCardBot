using ChatBotHook.DAL;
using Core;
using Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatBotHook.IntentHandlers
{
    public class ManageDeckHandler : BaseHandler<ManageDeckSlotType>
    {
        public ManageDeckHandler() { }

        public ManageDeckHandler(IDatabaseDAL dal) : base(dal) { }

        protected override OutputModel<ManageDeckSlotType> ProcessIntent()
        {
            string dialogActionType = Constants.DIALOG_ACTION_TYPE_ELICIT;
            string fulfillmentState = null;
            string intentName = InputModel.CurrentIntent.Name;
            var slots = InputModel.CurrentIntent.Slots;
            var errors = InputModel.CurrentIntent.Slots.Validate();
            string slotToElicit = InputModel.CurrentIntent.Slots.GetSlotToElicit();
            string responseMessage = String.Empty;

            if (slotToElicit == nameof(ManageDeckSlotType.ManageType))
            {
                var error = errors.FirstOrDefault(rr => rr.PropertyName == nameof(ManageDeckSlotType.ManageType));

                if (error != null)
                    responseMessage = "Would you like to add a new, modify an existing, or delete a flash card deck?";
                else
                {
                    responseMessage = String.Format(Constants.ERROR_MESSAGE_INVALID_VALUE, "Manage Type is invalid");
                    InputModel.CurrentIntent.Slots.ManageType = null;
                }
            }
            else if(slotToElicit == nameof(ManageDeckSlotType.DeckName))
            {
                responseMessage = String.Format("What is the name of the deck you'd like to {0}", InputModel.CurrentIntent.Slots.ManageType.ToLower());
            }
            else if (slotToElicit == nameof(ManageDeckSlotType.Front))
            {
                responseMessage = "Enter the front of the card";
            }
            else if (slotToElicit == nameof(ManageDeckSlotType.Back))
            {
                responseMessage = "Enter the back of the card";
            }
            else if (slotToElicit == nameof(ManageDeckSlotType.Confirm))
            {
                if (InputModel.CurrentIntent.Slots.ManageType.ToLower() == Constants.ManageTypes.Add.ToString().ToLower())
                    responseMessage = String.Format("Are you sure you want to add {0} as a new flash card deck?", InputModel.CurrentIntent.Slots.DeckName);
                else if (InputModel.CurrentIntent.Slots.ManageType.ToLower() == Constants.ManageTypes.Delete.ToString().ToLower())
                    responseMessage = String.Format("Are you sure you want to delete the flash car deck named {0}", InputModel.CurrentIntent.Slots.DeckName);
                else
                    responseMessage = "Would you like to add another?";
            }
            else if(slotToElicit == string.Empty)
            {
                slotToElicit = null;
                if (!InputModel.CurrentIntent.Slots.Validate().Any())
                {
                    dialogActionType = Constants.DIALOG_ACTION_TYPE_CLOSE;
                    fulfillmentState = Constants.FULLFILLMENT_STATE_FULFILLED;
                    intentName = null;
                    slots = null;
                    string manageType = InputModel.CurrentIntent.Slots.ManageType.ToLower();
                    if (manageType == Constants.ManageTypes.Add.ToString().ToLower())
                    {
                        manageType = "added";
                        Dal.AddNewDeck(InputModel.UserID, InputModel.CurrentIntent.Slots.DeckName);
                    }
                    else if (manageType == Constants.ManageTypes.Delete.ToString().ToLower())
                    {
                        manageType = "deleted";
                        Dal.AddNewDeck(InputModel.UserID, InputModel.CurrentIntent.Slots.DeckName);
                    }
                    responseMessage = String.Format("OK, your deck has been {0}", manageType);
                }
            }

            var outputModel = new OutputModel<ManageDeckSlotType>();
            outputModel.dialogAction.type = dialogActionType;
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