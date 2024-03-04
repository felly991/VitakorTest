using Microsoft.EntityFrameworkCore;
using VatakorTestCaseAPI.Data;
using VatakorTestCaseAPI.Interface;
using VatakorTestCaseAPI.Models;
using VitakorTestCaseAPI.DTOs;

namespace VatakorTestCaseAPI.Service
{
    public class MoreBetService : IMoreBet
    {
        private readonly DataContext _context;
        public MoreBetService(DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Сервис для перебития ставки, если ставка перебита,
        /// с помощью раббита отправляется сообщение на консоль
        /// </summary>
        /// <param name="betModel"></param>
        /// <returns></returns>
        public async Task<string> Message(BetModel betModel)
        {
            var maxBet = _context.Bets
                .Where(x => x.Lotid == betModel.Lotid).Select(x => x.Salary).Max();
            var user = await _context.Bets.Include(u => u.Users).Include(l => l.Lot)
                .Where(x => x.Lotid == betModel.Lotid)
                .FirstOrDefaultAsync(x => x.Lot.StartBet == maxBet);
            if (user == null)
            {
                return "nothing";
            }
            return $"Для: {user.Users.Email} \n" +
                $"Ваша ставка на лот {betModel.Lotid} была перебита ценой {betModel.BetValue}";
        }
    }
}
