using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RabbitMQ.Hubs;
using RabbitMQ.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQ.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly Producer _producer;
        private readonly IMemoryCache _memoryCache;
        private readonly MessageHub _myHub;

        public SampleDataController(Producer producer, IMemoryCache memoryCache, MessageHub myHub)
        {
            _producer = producer;
            _memoryCache = memoryCache;
            _myHub = myHub;
        }

        [HttpGet("[action]")]
        public void SendToQ()
        {
            _producer.PushMessageToQ();
        }

        [HttpGet("[action]")]
        public List<string> Refresh()
        {
            Dictionary<string, int> messages = null;
            _memoryCache.TryGetValue<Dictionary<string, int>>("messages", out messages);
            if (messages == null) messages = new Dictionary<string, int>();

            return messages.OrderBy(m => m.Value).Select(m => m.Key).ToList();
        }

        //[HttpPost]
        //public async Task SendMessage(string message)
        //{
        //    await _myHub.SendMessage(message);
        //}

    }
}
