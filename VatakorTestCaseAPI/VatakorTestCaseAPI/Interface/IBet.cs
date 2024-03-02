using VitakorTestCaseAPI.DTOs;

namespace VatakorTestCaseAPI.Interface
{
    public interface IBet
    {
        public Task<bool> UserBet(BetModel bet);
    }
}
