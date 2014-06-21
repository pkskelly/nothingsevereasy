using MongoDB.Driver;
using nothingsevereasy.Data;
using nothingsevereasy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace nothingsevereasy.Controllers
{
    public class TopicsController : ApiController
    {
        ITopicProvider _topicsProvider;

        public TopicsController()
        {
            _topicsProvider = new TopicDB();
        }

        public TopicsController(ITopicProvider topicsProvider)
        {
            _topicsProvider = topicsProvider;
        }

        public IEnumerable<Topic> Get()
        {
            return _topicsProvider.GetAllTopics();
        }

        public IHttpActionResult Get(string id)
        {
            Topic topic = _topicsProvider.FindById(id);
            if (topic == null)
            {
                return NotFound();
            }
            return Ok(topic);
        }

        [Route("api/topics/{id}/comments")]
        public IHttpActionResult GetComments(string id)
        {
            Topic topic = _topicsProvider.FindById(id);
            if (topic == null)
            {
                return NotFound() ;
            }
            return Ok(topic.Comments);
        }
    }
}
