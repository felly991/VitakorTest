using VitakorTestCaseAPI.DTOs;

namespace VatakorTestCaseAPI.Interface
{
    public interface IGetAllLots
    {
        public Task<List<LotDTO>> GetAllLots();
    }
}
