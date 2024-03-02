using VatakorTestCaseAPI.Models;

namespace VatakorTestCaseAPI.Interface
{
    public interface ILotWinner
    {
        public Task<string> WinnerMessage(Lot lot);
    }
}
