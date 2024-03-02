using VatakorTestCaseAPI.Interface;
using VatakorTestCaseAPI.Rabbit;
using VitakorTestCaseAPI.Services.BackgroundServices;

namespace VatakorTestCaseAPI.Service.Connection
{
    public class ConnectionService
    {
        /// <summary>
        /// Создание сервисов
        /// </summary>
        /// <param name="builder"></param>
        public static void ConnectService(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IGetAllLots, GetLotsService>();
            builder.Services.AddScoped<IUser, UserService>();
            builder.Services.AddScoped<IBet, BetService>();
            builder.Services.AddScoped<IRabbitMq, RabbitMqService>();
            builder.Services.AddScoped<IMoreBet, MoreBetService>();
            builder.Services.AddScoped<ILotWinner, LotWinnerService>();
            builder.Services.AddHostedService<GenerateMandarin>();
            builder.Services.AddHostedService<FalseMandarin>();
            builder.Services.AddHostedService<RabbitMqListener>();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
        }
    }
}
