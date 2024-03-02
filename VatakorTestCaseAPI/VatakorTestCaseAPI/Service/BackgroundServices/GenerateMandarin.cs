using VatakorTestCaseAPI.Data;
using VatakorTestCaseAPI.Models;


namespace VitakorTestCaseAPI.Services.BackgroundServices
{
    public class GenerateMandarin : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        public GenerateMandarin(IServiceProvider serviceProvider)
        {

            _serviceProvider = serviceProvider;

        }
        /// <summary>
        /// Создание мандаринок промежутком в 1 минуту
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
                    var lot = new Lot() { Name = "Мандарин", StartBet = 0 };
                    _context.Lots.Add(lot);
                    await _context.SaveChangesAsync();
                }
                await Task.Delay(120000);
            }

        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
            
        }
    }
}
