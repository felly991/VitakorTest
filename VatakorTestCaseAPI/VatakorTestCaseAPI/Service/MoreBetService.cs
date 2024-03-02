using Microsoft.EntityFrameworkCore;
using VatakorTestCaseAPI.Data;
using VatakorTestCaseAPI.Interface;
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
            var user = await _context.Bets.Include(u => u.Users)
                .FirstOrDefaultAsync(x => x.Lotid == betModel.Lotid);
            if (user == null)
            {
                return "nothing";
            }
            return $"Для: {user.Users.Email} \n" +
                $"Ваша ставка на лот {betModel.Lotid} была перебита ценой {betModel.BetValue}";
        }
    }
}
