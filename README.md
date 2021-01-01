# Discord.Net-Template

Sample structure for [Discord.net](https://github.com/discord-net/Discord.Net) bots using a [Worker Service](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-5.0&tabs=visual-studio) and [EF Core](https://docs.microsoft.com/en-us/ef/core/)

## Structure

This repository follows the structure described below. While it would be much easier to merge all these different projects into one, I prefer to keep them separated for organization and to allow the creation of more bots that use the same underlying classes.

- Bot
    - Command modules
- Model
    - Data models
- Shared
    - Services
    - Data context
    - Shared resources

## Storing secrets

This project is set up to use a json file for configurations such as the bot token. However sensitive information should be kept secret, so the appsettings.Development.json file has been added to the .gitignore. Before using this template, you should recreate that file and move the “Bot” section in the appsettings.json file to the file created.

You also could use [other techniques](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows) to store the bot token, but I find this one convenient for quick prototyping.

## Other information

For more information on how to make a discord bot using Discord.net, check out the [documentation](https://docs.stillu.cc/guides/introduction/intro.html).
For more information on how to use Entity Framework, check out the [documentation](https://docs.microsoft.com/en-us/ef/core/).
This template is based on the [sample files](https://github.com/discord-net/Discord.Net/tree/dev/samples) accessible in the Discord.net repository.
