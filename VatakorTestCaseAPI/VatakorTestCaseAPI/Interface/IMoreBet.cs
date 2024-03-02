using VitakorTestCaseAPI.DTOs;

namespace VatakorTestCaseAPI.Interface
{
    public interface IMoreBet
    {
        public Task<string> Message(BetModel betModel);
    }
}
