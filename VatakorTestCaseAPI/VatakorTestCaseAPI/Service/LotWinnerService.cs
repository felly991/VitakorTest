using Microsoft.EntityFrameworkCore;
using VatakorTestCaseAPI.Data;
using VatakorTestCaseAPI.Interface;
using VatakorTestCaseAPI.Models;
using VatakorTestCaseAPI.Rabbit;

namespace VatakorTestCaseAPI.Service
{
    public class LotWinnerService : ILotWinner
    {
        private readonly DataContext _context;
        private readonly IRabbitMq _rabbit;
        public LotWinnerService(DataContext context, IRabbitMq rabbit)
        {
            _context = context;
            _rabbit = rabbit;
        }
        /// <summary>
        /// Сервис для выявления победителя,
        /// с дальнейшей отправкой сообщения в консоль при помощи раббита
        /// </summary>
        /// <param name="lot"></param>
        /// <returns></returns>
        public async Task<string> WinnerMessage(Lot lot)
        {
            var bets = await _context.Bets.Include(u => u.Users)
                .Where(x => x.Lotid == lot.Id).FirstOrDefaultAsync(x => x.Salary == lot.StartBet);
            if (bets == null)
            {
                return "nothing";
            }
            return ($"Для: {bets.Users.Email} \n" +
                $"Уважаемый {bets.Users.Name} {bets.Users.Surname} \n" +
                $"Ваша ставка на лот {bets.Lotid} выиграла с суммой {bets.Salary}");
        }
    }
}
