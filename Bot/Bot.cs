using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shared.Configurations;
using Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bot
{
    public class Bot : BackgroundService
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _command;
        private readonly CommandHandlingService _commandHandling;
        private readonly SeedingService _seedingService;
        private readonly BotConfiguration _botConfiguration;

        public Bot(DiscordSocketClient client, CommandService command, CommandHandlingService commandHandling,
                   SeedingService seedingService, IOptions<BotConfiguration> botConfiguration)
        {
            _client = client;
            _command = command;
            _commandHandling = commandHandling;
            _seedingService = seedingService;
            _botConfiguration = botConfiguration.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _client.Log += LogAsync;
            _command.Log += LogAsync;

            // Tokens should be considered secret data and never hard-coded.
            // We can read from the environment variable to avoid hardcoding.
            await _client.LoginAsync(TokenType.Bot, _botConfiguration.Token);
            await _client.StartAsync();

            // Here we initialize the logic required to register our commands.
            await _commandHandling.InitializeAsync();
            await _seedingService.InitializeAsync();
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }
    }
}
