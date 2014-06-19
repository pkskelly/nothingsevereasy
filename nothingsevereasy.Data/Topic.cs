using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace nothingsevereasy.Data
{
    public class Topic
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Vote> Votes { get; set; }
 
    }

    public class Comment
    {
        public string Desription { get; set; }
        public string CreatedBy { get; set; }

    }

    public class Vote
    {
        public bool UpVote { get; set; }
        public string CreatedBy { get; set; }

    }
}


