using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using System.Reflection;
using AWS.Logger.Core;
using NLog;
using Core.Model;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
//[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
[assembly: LambdaSerializer(typeof(ChatBotHook.Parse.InputDeserializer))]

namespace ChatBotHook
{
    public class Function
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public InputModel<OrderSlotType> FunctionHandler(InputModel<OrderSlotType> input, ILambdaContext context)
        {
            _logger.Info("Called Function Handler");
            _logger.Info(input.ToString());
            return input;
        }
    }
}
