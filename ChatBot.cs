using System;

namespace CybersecurityChatbot.Classes
{
    /// <summary>
    /// Orchestrates the main chatbot conversation loop, user interaction, and input validation.
    /// </summary>
    public class ChatBot
    {
        private readonly ResponseEngine _engine;
        private string _userName = "User";

        public ChatBot()
        {
            _engine = new ResponseEngine();
        }

        // ──────────────────────────────────────────────────────────────
        //  Entry Point
        // ──────────────────────────────────────────────────────────────
        public void Start()
        {
            GreetUser();
            RunConversationLoop();
            ShowFarewell();
        }

        // ──────────────────────────────────────────────────────────────
        //  Greeting & Name Collection
        // ──────────────────────────────────────────────────────────────
        private void GreetUser()
        {
            DisplayHelper.PrintSectionHeader("Getting Started");
            DisplayHelper.PrintBot("Hello! Welcome to the Cybersecurity Awareness Bot.");
            DisplayHelper.PrintBot("I'm here to help you stay safe online.");
            Console.WriteLine();

            _userName = GetValidName();

            DisplayHelper.ShowWelcomeBanner(_userName);
        }

        private string GetValidName()
        {
            string name = string.Empty;

            while (string.IsNullOrWhiteSpace(name))
            {
                DisplayHelper.PrintUser("What is your name?");
                name = Console.ReadLine() ?? string.Empty;
                name = name.Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    DisplayHelper.PrintColored(
                        "  ⚠  Please enter a valid name to continue.",
                        ConsoleColor.Red);
                }
            }

            return name;
        }

        // ──────────────────────────────────────────────────────────────
        //  Main Conversation Loop
        // ──────────────────────────────────────────────────────────────
        private void RunConversationLoop()
        {
            DisplayHelper.PrintSectionHeader("Conversation");

            while (true)
            {
                DisplayHelper.PrintDivider();
                DisplayHelper.PrintUser(_userName);

                string userInput = Console.ReadLine() ?? string.Empty;

                // Exit check
                if (ResponseEngine.IsExitCommand(userInput))
                    break;

                // Input validation
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    DisplayHelper.PrintColored(
                        "  ⚠  I didn't receive any input. Please type a question or 'help'.",
                        ConsoleColor.DarkYellow);
                    continue;
                }

                // Get and display response
                string response = _engine.GetResponse(userInput);
                Console.WriteLine();
                DisplayHelper.PrintBot(response);
            }
        }

        // ──────────────────────────────────────────────────────────────
        //  Farewell
        // ──────────────────────────────────────────────────────────────
        private void ShowFarewell()
        {
            Console.WriteLine();
            DisplayHelper.PrintDivider();
            DisplayHelper.PrintColored(
                $"  👋  Goodbye, {_userName}! Stay safe online. Remember: think before you click!",
                ConsoleColor.Cyan);
            DisplayHelper.PrintDivider();
            Console.WriteLine();
        }
    }
}
