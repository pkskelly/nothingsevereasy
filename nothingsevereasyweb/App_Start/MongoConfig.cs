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
            using (ITopicProvider topics = new TopicDB())
            {
                if (!topics.GetAllTopics().AsQueryable().Any(t => t.Title == "Killing a tree"))
                {
                    var data = new List<Topic>()
                {
                    new Topic {Title="Installing SharePoint", CreatedBy="Pete Skelly", Created= DateTime.Now, 
                        Comments = new List<Comment>() {new Comment() { Desription  = "That is so true!",  CreatedBy= "Jim Smith"}},
                          Votes = new List<Vote>() { new Vote(){ UpVote=true, CreatedBy="Enriquo Pallatzo"}}                      
                    },
                     new Topic {Title="Finding Windows 8 Start Menu", CreatedBy="Aiden Skelly", Created= DateTime.Now, 
                        Comments = new List<Comment>() {new Comment() { Desription  = "I Hate that, can never find it!",  CreatedBy= "John Coctostin"}},
                          Votes = new List<Vote>() { new Vote(){ UpVote=true, CreatedBy="Enriquo Pallatzo"},new Vote(){ UpVote=true, CreatedBy="Rob Horton"}}                      
                    },
                     new Topic {Title="Killing a tree", CreatedBy="Jim Sheedy", Created= DateTime.Now, 
                        Comments = new List<Comment>() {new Comment() { Desription  = "Tried everything including copper nails! CUT IT DOWN!",  CreatedBy= "Pete Skelly"}},
                          Votes = new List<Vote>() { new Vote(){ UpVote=true, CreatedBy="Alexander Clambell"},new Vote(){ UpVote=true, CreatedBy="Matt Balde"}}                      
                    }
                };
                    topics.InsertBatch(data);
                }
            }
        }
    }
}