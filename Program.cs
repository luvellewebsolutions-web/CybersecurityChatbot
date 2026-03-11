using System;
using CybersecurityChatbot.Classes;

namespace CybersecurityChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Play voice greeting
            AudioPlayer.PlayGreeting();

            // Display ASCII art logo
            DisplayHelper.ShowLogo();

            // Start the chatbot
            ChatBot bot = new ChatBot();
            bot.Start();
        }
    }
}
