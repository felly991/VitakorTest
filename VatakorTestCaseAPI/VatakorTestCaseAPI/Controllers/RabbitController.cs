using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using VatakorTestCaseAPI.Rabbit;

namespace VatakorTestCaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitController : ControllerBase
    {
        private readonly IRabbitMq _rabbitMQ;
        public RabbitController(IRabbitMq rabbitMQ)
        {
            _rabbitMQ = rabbitMQ;
        }

        [Route("send")]
        [HttpGet]
        public IActionResult SendMessage(string message)
        {
            _rabbitMQ.SendMessage(message);

            return Ok("Сообщение отправлено");
        }
    }
}
