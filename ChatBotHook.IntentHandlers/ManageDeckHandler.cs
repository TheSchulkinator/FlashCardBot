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
        public override OutputModel<ManageDeckSlotType> HandleIntent()
        {
            //var errors = InputModel.CurrentIntent.Slots.Validate();
            //if (errors.Any())
            //errors.First();

            var outputModel = new OutputModel<ManageDeckSlotType>();
            outputModel.dialogAction.type = "ElicitSlot";
            outputModel.dialogAction.slots = InputModel.CurrentIntent.Slots;
            outputModel.dialogAction.message.content = "What are you doing boy?";
            outputModel.dialogAction.message.contentType = Constants.RESPONSE_CONTENT_TYPE;
            outputModel.dialogAction.slotToElicit = "ManageType";//nameof(InputModel.CurrentIntent.Slots.ManageType);
            outputModel.dialogAction.intentName = InputModel.CurrentIntent.Name;
            return outputModel;
        }
    }
}