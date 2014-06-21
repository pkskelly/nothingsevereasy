using MongoDB.Driver;
using nothingsevereasy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nothingsevereasy.Services;

namespace nothingsevereasy.Services
{
    public interface ITopicProvider : IDisposable
    {

        IEnumerable<Topic> GetAllTopics();
        IEnumerable<WriteConcernResult> InsertBatch(IEnumerable<Topic> _topics);
        Topic FindById(string id);
        IEnumerable<Comment> GetComments(string topicId);

    }
}
