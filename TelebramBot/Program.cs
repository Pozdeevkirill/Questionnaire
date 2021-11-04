using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelebramBot
{
    class Program
    {
        private static string token { get; set; } = "";
        private static TelegramBotClient client;
        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler();
            Console.ReadLine();
            client.StartReceiving();
        }

        private static EventHandler<MessageEventArgs> OnMessageHandler()
        {
            var 
        }
    }
}
