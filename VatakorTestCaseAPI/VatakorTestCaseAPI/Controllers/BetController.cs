using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VatakorTestCaseAPI.Interface;
using VitakorTestCaseAPI.DTOs;

namespace VitakorTestCaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private readonly IBet _bet;
        public BetController(IBet bet)
        {
            _bet = bet;
        }
        [HttpPost("/bet")]
        public async Task<bool> Bet(BetModel bet)
        {
            var result = await _bet.UserBet(bet);
            return result;
        }
    }
}
