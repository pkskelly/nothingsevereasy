using nothingsevereasy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;


namespace nothingsevereasy.Services
{
    public static class TopicDB 
    {
        public static MongoCollection<Topic> Open()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var server = client.GetServer();
            var db = server.GetDatabase("TopicsDb");
            return db.GetCollection<Topic>("Topics");
        }

    }
}