using Amazon;
using Amazon.DynamoDBv2;
using Amazon.S3;
using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DocumentModel;

namespace ChatBotHook.DAL
{
    public class DynomoDatabaseDAL
    {
        private AmazonDynamoDBClient _client;
        private AmazonDynamoDBClient Client
        {
            get
            {
                if(_client == null)
                {
                    Configure();
                }
                return _client;
            }
            set
            {
                _client = value;
            }
        }

        public async void Test()
        {
            //Configure();
            var tables = Client.ListTablesAsync().Result;

            var inputDictionary = new Dictionary<string, Amazon.DynamoDBv2.Model.AttributeValue>();
            inputDictionary.Add("UserID", new Amazon.DynamoDBv2.Model.AttributeValue("User23"));
            //var dictionary = new Dictionary<string, Amazon.DynamoDBv2.Model.AttributeValueUpdate>();
            //dictionary.Add("UserID", new Amazon.DynamoDBv2.Model.AttributeValueUpdate(inputDictionary.ToList()[0].Value, AttributeAction.PUT));
            var user = Client.GetItemAsync("User", inputDictionary).Result;
            if (!user.Item.Any())
            {
                var returnValue = ReturnValue.ALL_OLD;
                //client.UpdateItem("User", inputDictionary, dictionary, returnValue);
                await Client.PutItemAsync(DBConstants.TABLE_NAME_USER, inputDictionary, returnValue);
            }
            user = Client.GetItemAsync("User", inputDictionary).Result;
        }

        public void GetDecks(string userId)
        {
            var table = GetTable(DBConstants.TABLE_NAME_DECK);

            var expressionAttributes = new Dictionary<string, string>();
            expressionAttributes.Add("UserID", userId);


            

            //var results = table.Query(queryConfig);
            var results = table.Query(userId, new Expression());
        }
        public async Task AddDeckAsync(string userId, string deckName)
        {
            var document = new Document();
            document[DBConstants.COLUMN_NAME_USER_USERID] = userId;
            document[DBConstants.COLUMN_NAME_DECK_NAME] = deckName;
            await GetTable(DBConstants.TABLE_NAME_DECK).PutItemAsync(document);
        }

        private void GetItems()
        {

        }


        private Table GetTable(string tableName)
        {
            return Table.LoadTable(Client, tableName);
        }

        public async Task<string> GetUser(string userId)
        {
            var inputDictionary = new Dictionary<string, Amazon.DynamoDBv2.Model.AttributeValue>();
            inputDictionary.Add(DBConstants.COLUMN_NAME_USER_USERID, new Amazon.DynamoDBv2.Model.AttributeValue(userId));
            var user = Client.GetItemAsync(DBConstants.TABLE_NAME_USER, inputDictionary).Result;

            //var dictionary = new Dictionary<string, Amazon.DynamoDBv2.Model.AttributeValueUpdate>();
            //dictionary.Add("UserID", new Amazon.DynamoDBv2.Model.AttributeValueUpdate(inputDictionary.ToList()[0].Value, AttributeAction.PUT));

            if (!user.Item.Any())   
            {
                var returnValue = ReturnValue.ALL_OLD;
                //client.UpdateItem("User", inputDictionary, dictionary, returnValue);
                await Client.PutItemAsync(DBConstants.TABLE_NAME_USER, inputDictionary, returnValue);
                user = Client.GetItemAsync(DBConstants.TABLE_NAME_USER, inputDictionary).Result;
            }
            return user.Item[DBConstants.COLUMN_NAME_USER_USERID].S;
        }

        public void AddCardToDeck(string userId, string deckId)
        {

        }

        public void GetCardFromDeck(string userId, string deckId, string cardId)
        {

        }

        private void Configure()
        {
            AmazonS3Config config = new AmazonS3Config();
            config.RegionEndpoint = RegionEndpoint.USEast1;
            IAmazonS3 s3Client = new AmazonS3Client(config);
            AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();
            // This client will access the US East 1 region.
            clientConfig.RegionEndpoint = RegionEndpoint.USEast1;
            Client = new AmazonDynamoDBClient(clientConfig);
        }

        private void Update(string tableName, List<string> columnNames, List<string> columnValues)
        {

        }
    }
}
