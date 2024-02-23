
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using WeatherForecastTelegramBot.BotControll;

var botClient = new TelegramBotClient("7070247258:AAFMIO09wIht9Mzpqhsh48fBkv607dwuAmo");

using CancellationTokenSource cts = new();

ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>()
};

botClient.StartReceiving(
    updateHandler: BotController.HandleUpdateAsync,
    pollingErrorHandler: BotController.HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);

var me = await botClient.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();
  
cts.Cancel();

