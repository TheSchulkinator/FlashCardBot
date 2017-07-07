using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBotHook.IntentHandlers
{
    public interface IIntentHandler<SlotType> : IIntentHandler where SlotType : BaseSlotType 
    {
        //InputModel<SlotType> InputModel { get; set; }
    }

    public interface IIntentHandler
    {
        dynamic HandleIntent(dynamic inputModel);
    }
}
