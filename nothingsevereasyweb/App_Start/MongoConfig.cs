using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver.Linq;
using nothingsevereasy.Services;
using nothingsevereasy.Data;
using nothingsevereasy;

namespace nothingsevereasy.App_Start
{
    public static class MongoConfig
    {
        public static void Seed()
        {
            var topics = TopicDB.Open();
            if (!topics.AsQueryable().Any(t => t.Title == "Installing SharePoint"))
            {
                var data = new List<Topic>()
                {
                    new Topic {Title="Installing SharePoint", CreatedBy="Pete Skelly", Created= DateTime.Now, 
                        Comments = new List<Comment>() {new Comment() { Desription  = "That is so true!",  CreatedBy= "Jim Smith"}},
                          Votes = new List<Vote>() { new Vote(){ UpVote=true, CreatedBy="Enriquo Pallatzo"}}                      
                    }
                };
                topics.InsertBatch(data);
            }
        }
    }
}