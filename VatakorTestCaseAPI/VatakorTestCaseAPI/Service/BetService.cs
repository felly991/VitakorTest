using Microsoft.EntityFrameworkCore;
using VatakorTestCaseAPI.Data;
using VatakorTestCaseAPI.Interface;
using VatakorTestCaseAPI.Models;
using VatakorTestCaseAPI.Rabbit;
using VitakorTestCaseAPI.DTOs;

namespace VatakorTestCaseAPI.Service
{
    public class BetService : IBet
    {
        private readonly DataContext _context;
        private readonly IRabbitMq _rabbit;
        private readonly IMoreBet _moreBet;
        public BetService(DataContext context, IRabbitMq rabbit, IMoreBet moreBet)
        {
            _context = context;
            _rabbit = rabbit;
            _moreBet = moreBet;
        }
        /// <summary>
        /// Ставка на конкретный лот с проверкой сумма ставки больше прошлой
        /// </summary>
        /// <param name="bet"></param>
        /// <returns></returns>
        public async Task<bool> UserBet(BetModel bet)
        {

            try
            {
                var lot = await _context.Lots
                    .Where(x => x.Alive == true)
                    .FirstOrDefaultAsync(x => x.Id == bet.Lotid);
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == bet.Userid);
                if (user == null || lot == null)
                {
                    return false;
                }
                if (await isMore(bet))
                {
                    Bet betModel = new Bet();
                    lot.StartBet = bet.BetValue;
                    _rabbit.SendMessage(_moreBet.Message(bet).Result);
                    betModel.Lot = lot;
                    betModel.Users = user;
                    betModel.Usersid = bet.Userid;
                    betModel.Lotid = bet.Lotid;
                    betModel.Salary = bet.BetValue;
                    _context.Bets.Add(betModel);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private async Task<bool> isMore(BetModel bet)
        {
            var bets = _context.Bets
                .Where(x => x.Lotid == bet.Lotid).Select(x => x.Salary).Max();
            if (bets == null)
            {
                bets = _context.Lots.Where(x => x.Id == bet.Lotid).Select(x => x.StartBet).Max();
            }
            return bet.BetValue - bets > 0;
        }
    }
}

