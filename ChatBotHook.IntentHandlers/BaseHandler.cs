using System;
using System.Collections.Generic;
using System.Text;
using Core.Model;
using Newtonsoft.Json;
using ChatBotHook.DAL;

namespace ChatBotHook.IntentHandlers
{
    public abstract class BaseHandler<T> : IIntentHandler<T> where T : ISlotType
    {
        protected IDatabaseDAL Dal;
        public BaseHandler(IDatabaseDAL dal) //For unit testing
        {
            Dal = dal;
        }

        public BaseHandler()
        {
            Dal = new DynomoDatabaseDAL();
        }

        public InputModel<T> InputModel { get; set; }

        public string HandleIntent(dynamic inputModel)
        {
            InputModel = JsonConvert.DeserializeObject<InputModel<T>>(inputModel.ToString());
            return SerializeOutput(ProcessIntent());
        }

        private string SerializeOutput(OutputModel<T> outputModel)
        {
            return JsonConvert.SerializeObject(outputModel);
        }

        protected abstract OutputModel<T> ProcessIntent();
    }
}
