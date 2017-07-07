using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using System.Reflection;
using AWS.Logger.Core;
using NLog;
using Core.Model;
using ChatBotHook.IntentHandlers;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
//[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
[assembly: LambdaSerializer(typeof(ChatBotHook.Parse.InputDeserializer))]

namespace ChatBotHook
{
    public class Function
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private IIntentCreator _intentCreator = new FlashCardBotIntentCreator();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        //public InputModel<WelcomeIntentSlotType> FunctionHandler(InputModel<WelcomeIntentSlotType> input, ILambdaContext context)
        //{
        //    _logger.Info("Called Welcome Function Handler");
        //    _logger.Info(input.ToString());
        //    return input;
        //}

        public dynamic FunctionHandler(dynamic inputModel, ILambdaContext context)
        {
            _logger.Info("Called Function Handler");
            _logger.Info(inputModel.ToString());

            string intentName = String.Empty;
            if (inputModel.currentIntent != null)
                intentName = inputModel.currentIntent.name.ToString();
            _logger.Info("Getting Handler");
            IIntentHandler intentHandler = _intentCreator.GetIntentHandler(intentName);
            _logger.Info("Calling Handler");
            var returnModel = intentHandler.HandleIntent(inputModel);

            _logger.Info("Returned");
            _logger.Info(String.Format("Returned {0}", returnModel.ToString()));
            return returnModel;
            //return inputModel;
        }
    }
}
