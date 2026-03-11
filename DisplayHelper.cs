using System;
using System.Threading;

namespace CybersecurityChatbot.Classes
{
    /// <summary>
    /// Provides console UI helpers: ASCII logo, coloured output, borders, and typing effects.
    /// </summary>
    public static class DisplayHelper
    {
        // ──────────────────────────────────────────────────────────────
        //  ASCII Logo
        // ──────────────────────────────────────────────────────────────
        public static void ShowLogo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
  ██████╗██╗   ██╗██████╗ ███████╗██████╗      █████╗ ██╗    ██╗ █████╗ ██████╗ ███████╗
 ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗    ██╔══██╗██║    ██║██╔══██╗██╔══██╗██╔════╝
 ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝    ███████║██║ █╗ ██║███████║██████╔╝█████╗  
 ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗    ██╔══██║██║███╗██║██╔══██║██╔══██╗██╔══╝  
 ╚██████╗   ██║   ██████╔╝███████╗██║  ██║    ██║  ██║╚███╔███╔╝██║  ██║██║  ██║███████╗
  ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝    ╚═╝  ╚═╝ ╚══╝╚══╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝
");
            Console.ResetColor();

            PrintColored("  ╔══════════════════════════════════════════════════════════════╗", ConsoleColor.DarkCyan);
            PrintColored("  ║         CYBERSECURITY AWARENESS CHATBOT  v1.0               ║", ConsoleColor.DarkCyan);
            PrintColored("  ║         Keeping South Africa Safe Online                    ║", ConsoleColor.DarkCyan);
            PrintColored("  ╚══════════════════════════════════════════════════════════════╝", ConsoleColor.DarkCyan);
            Console.WriteLine();
        }

        // ──────────────────────────────────────────────────────────────
        //  Coloured Output
        // ──────────────────────────────────────────────────────────────
        public static void PrintColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void PrintBot(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("  🤖 Bot: ");
            Console.ResetColor();
            TypewriterEffect(message);
        }

        public static void PrintUser(string label)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\n  👤 {label}: ");
            Console.ResetColor();
        }

        public static void PrintDivider()
        {
            PrintColored("  ──────────────────────────────────────────────────────────────", ConsoleColor.DarkGray);
        }

        public static void PrintSectionHeader(string title)
        {
            Console.WriteLine();
            PrintColored($"  ┌─ {title.ToUpper()} ─", ConsoleColor.Magenta);
        }

        // ──────────────────────────────────────────────────────────────
        //  Typing / Conversational Effect
        // ──────────────────────────────────────────────────────────────
        public static void TypewriterEffect(string text, int delayMs = 18)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }

        // ──────────────────────────────────────────────────────────────
        //  Welcome Banner (shown after logo + name input)
        // ──────────────────────────────────────────────────────────────
        public static void ShowWelcomeBanner(string userName)
        {
            Console.WriteLine();
            PrintColored("  ╔══════════════════════════════════════════════════════════════╗", ConsoleColor.Green);
            PrintColored($"  ║  Welcome, {userName.PadRight(51)}║", ConsoleColor.Green);
            PrintColored("  ║  I'm here to help you stay safe online.                     ║", ConsoleColor.Green);
            PrintColored("  ║  Type 'help' to see what I know, or 'exit' to quit.         ║", ConsoleColor.Green);
            PrintColored("  ╚══════════════════════════════════════════════════════════════╝", ConsoleColor.Green);
            Console.WriteLine();
        }
    }
}
