using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VatakorTestCaseAPI.Interface;
using VitakorTestCaseAPI.DTOs;




namespace VitakorTestCaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotController : ControllerBase
    {
        private readonly IGetAllLots _getAllLots;
        public LotController(IGetAllLots getAllLots)
        {
            _getAllLots = getAllLots;
        }
        [HttpGet("/getLots")]
        public async Task<List<LotDTO>> GetAllLot()
        {
            var lots = await _getAllLots.GetAllLots();
            if (lots == null)
            {
                return null;
            }
            return lots;
        }
    }
}
