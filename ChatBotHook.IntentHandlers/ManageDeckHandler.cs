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
        public override dynamic HandleIntent()
        {
            var errors = InputModel.CurrentIntent.Slots.Validate();
            //if (errors.Any())
            //errors.First();

            var outputModel = new OutputModel<ManageDeckSlotType>();

            outputModel.DialogAction.Slots = InputModel.CurrentIntent.Slots;
            outputModel.DialogAction.Message.Content = "What are you doing boy?";
            outputModel.DialogAction.Message.ContentType = Constants.RESPONSE_CONTENT_TYPE;
            outputModel.DialogAction.SlotToElict = nameof(InputModel.CurrentIntent.Slots.ManageType);
            outputModel.DialogAction.IntentName = InputModel.CurrentIntent.Name;

            string json = JsonConvert.SerializeObject(outputModel);
            return JsonConvert.DeserializeObject<dynamic>(json);
        }
    }
}
