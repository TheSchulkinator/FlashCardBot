﻿using Amazon;
using Amazon.DynamoDBv2;
using Amazon.S3;
using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.DataModel;
using Core.Model.Entity;
using NLog;
using System.Threading;

namespace ChatBotHook.DAL
{
    public class DynomoDatabaseDAL : IDatabaseDAL
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
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

        public void AddNewDeck(string userId, string deckName, Deck deck = null)
        {
            _logger.Info(String.Format("Adding a new deck: {0}, {1}", userId, deckName));
            var context = new DynamoDBContext(Client);
            if(deck == null)
                deck = new Deck();
            deck.UserID = userId;
            deck.DeckName = deckName;
            //deck.Cards = new List<Card>();
            //deck.Cards.Add(new Card() { Front = "Front", Back = "Back" });
            try
            {
                var task = context.SaveAsync<Deck>(deck);
                while (!task.IsCompleted)
                    Thread.Sleep(500);
            }
            catch (Exception e)
            {
                _logger.Info(String.Format("Exception on write: {0}", e.Message));
            }
            _logger.Info("Done");
        }

        public Deck GetDeck(string userId, string deckName)
        {
            var context = new DynamoDBContext(Client);
           return context.LoadAsync<Deck>(userId, deckName).Result;
        }

        public void UpdateDeck(Deck deck)
        {
            var context = new DynamoDBContext(Client);
            context.SaveAsync<Deck>(deck);
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
    }
}
