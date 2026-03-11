using System;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;

namespace CybersecurityChatbot.Classes
{
    /// <summary>
    /// Handles playing the voice greeting WAV file on startup.
    /// </summary>
    public static class AudioPlayer
    {
        private static readonly string AudioFileName = "greeting.wav";

        /// <summary>
        /// Plays the WAV greeting file if it exists and the OS supports it.
        /// </summary>
        public static void PlayGreeting()
        {
            try
            {
                string audioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AudioFileName);

                if (!File.Exists(audioPath))
                {
                    DisplayHelper.PrintColored(
                        "[Audio] Voice greeting file not found. Place 'greeting.wav' in the app folder.",
                        ConsoleColor.DarkYellow);
                    return;
                }

                // SoundPlayer only works on Windows
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    using SoundPlayer player = new SoundPlayer(audioPath);
                    player.PlaySync(); // Play synchronously so greeting finishes before text appears
                }
                else
                {
                    DisplayHelper.PrintColored(
                        "[Audio] Voice greeting is supported on Windows only.",
                        ConsoleColor.DarkYellow);
                }
            }
            catch (Exception ex)
            {
                DisplayHelper.PrintColored($"[Audio Error] {ex.Message}", ConsoleColor.Red);
            }
        }
    }
}
