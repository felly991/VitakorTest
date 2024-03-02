using Microsoft.EntityFrameworkCore;
using VatakorTestCaseAPI.Data;
using VatakorTestCaseAPI.Interface;
using VatakorTestCaseAPI.Rabbit;


namespace VitakorTestCaseAPI.Services.BackgroundServices
{
    public class FalseMandarin : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        public FalseMandarin(IServiceProvider serviceProvider)
        {

            _serviceProvider = serviceProvider;

        }
        /// <summary>
        /// Срок жизни мандарина 5 минут, потом он умирает
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var _context = scope.ServiceProvider.GetRequiredService<DataContext>();
                    var _lotWinner = scope.ServiceProvider.GetRequiredService<ILotWinner>();
                    var _rabbit = scope.ServiceProvider.GetRequiredService<IRabbitMq>();
                    var mandarin = await _context.Lots.Where(x => x.Alive == true).ToListAsync();
                    foreach (var item in mandarin)
                    {
                        if (DateTime.UtcNow >= item.DateCreated.Value.AddMinutes(30))
                        {
                            _rabbit.SendMessage(_lotWinner.WinnerMessage(item).Result);
                            item.Alive = false;
                        }
                    }
                    await _context.SaveChangesAsync();
                }
                await Task.Delay(300000);
            }

        }
    }
}
