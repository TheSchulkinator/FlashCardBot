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
            var errors = InputModel.CurrentIntent.Slots.Validate();
            //if (errors.Any())
            //errors.First();

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
                responseMessage = "Gimme a deck name yo";
            }
            //else if(slotToElicit == nameof(ManageDeckSlotType.Front))
            //{
            //    responseMessage = "Enter the front of the card";
            //}
            //else if (slotToElicit == nameof(ManageDeckSlotType.Back))
            //{
            //    responseMessage = "Enter the back of the card";
            //}
            else if(slotToElicit == string.Empty)
            {
                if (!InputModel.CurrentIntent.Slots.Validate().Any())
                {
                    responseMessage = "OK";
                    if(InputModel.CurrentIntent.Slots.ManageType == Constants.ManageTypes.Add.ToString())
                    {
                        Dal.AddNewDeck(InputModel.UserID, InputModel.CurrentIntent.Slots.DeckName);
                    }
                }
            }

            var outputModel = new OutputModel<ManageDeckSlotType>();
            outputModel.dialogAction.type = "ElicitSlot";
            outputModel.dialogAction.slots = InputModel.CurrentIntent.Slots;
            outputModel.dialogAction.message.content = responseMessage;
            outputModel.dialogAction.message.contentType = Constants.RESPONSE_CONTENT_TYPE;
            outputModel.dialogAction.slotToElicit = slotToElicit;
            outputModel.dialogAction.intentName = InputModel.CurrentIntent.Name;
            return outputModel;
        }
    }
}