using Bot.Data;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Configurations;
using Shared.Data;
using Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    // Configurations

                    services.Configure<BotConfiguration>(hostContext.Configuration.GetSection(BotConfiguration.Section));

                    // Database

                    services.AddDbContext<DataContext, BotDataContext>(options => options.UseSqlite("Data Source = BotDatabase.db"));

                    // Worker

                    services.AddHostedService<Bot>()

                    // Discord

                    .AddSingleton<DiscordSocketClient>()
                    .AddSingleton<CommandService>()

                    // Services

                    .AddSingleton<SeedingService>()
                    .AddSingleton<CommandHandlingService>();
                });
    }
}
