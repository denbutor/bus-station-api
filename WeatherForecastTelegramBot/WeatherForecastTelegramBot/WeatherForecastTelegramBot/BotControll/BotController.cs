using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;

namespace WeatherForecastTelegramBot.BotControll;

public static class BotController
{
    public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { } message)
            return;

        if (message.Text is not { } messageText)
            return;

        if (message.Text is "/menu")
        {
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: MessagesContainer.MenuMessage
            );
        }
        else if (message.Text is "/start")
        {
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: MessagesContainer.StartMessage
            );
        }
        else if (message.Text is "/help")
        {
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: MessagesContainer.HelpMessage
            );
        }
        else
        {
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: await WeatherForecastRepository.GetWeatherForecast(message.Text), cancellationToken: cancellationToken);
        }
    }

    public static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }
}