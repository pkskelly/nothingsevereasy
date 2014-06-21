using nothingsevereasy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Net;
using MongoDB.Bson;


namespace nothingsevereasy.Services
{
    public  class TopicDB  : ITopicProvider
    {
        MongoClient _mongoClient;
        MongoServer _mongoServer;
        MongoDatabase _mongoDb;


        private void Init()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017");
            _mongoServer = _mongoClient.GetServer();
            _mongoDb = _mongoServer.GetDatabase("TopicsDb");
        }

        public TopicDB()
        {
            Init();
        }

        public IEnumerable<Topic> GetAllTopics()
        {
            return _mongoDb.GetCollection<Topic>("Topics").FindAll();

        }

        public IEnumerable<WriteConcernResult> InsertBatch(IEnumerable<Topic> _topics)
        {
            return _mongoDb.GetCollection<Topic>("Topics").InsertBatch(_topics);
        }

        public Topic FindById(string id)
        {           
            
            Topic topic = _mongoDb.GetCollection<Topic>("Topics").FindOneById(ObjectId.Parse(id));
            if (topic == null)
            {
                throw new Exception("Topic not found!");
            }
            return topic;
        }

        public IEnumerable<Comment> GetComments(string topicId)
        {
            Topic topic = _mongoDb.GetCollection<Topic>("Topics").FindOneById(ObjectId.Parse(topicId));
            if (topic == null)
            {
                throw new Exception("Topic not found!");
            }
            return topic.Comments;
        }

        public void Dispose()
        {
            if (_mongoServer.Instance.State == MongoServerState.Connected)
            {
                _mongoServer.Disconnect();
               
            }
        }
        
   
    }
}