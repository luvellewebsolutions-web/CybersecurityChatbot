using System;
using System.Collections.Generic;

namespace CybersecurityChatbot.Classes
{
    /// <summary>
    /// Stores and retrieves predefined chatbot responses mapped to user keywords.
    /// </summary>
    public class ResponseEngine
    {
        // ──────────────────────────────────────────────────────────────
        //  Response Dictionary  (keyword → response)
        // ──────────────────────────────────────────────────────────────
        private readonly Dictionary<string, string> _responses;

        public ResponseEngine()
        {
            _responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                // ── General ──────────────────────────────────────────
                ["how are you"] =
                    "I'm fully operational and ready to help you stay safe online! " +
                    "Cybersecurity never sleeps, and neither do I. 😄",

                ["what's your purpose"] =
                    "My purpose is to educate you on cybersecurity topics like phishing, " +
                    "safe passwords, and safe browsing — so you can protect yourself online.",

                ["purpose"] =
                    "I exist to raise cybersecurity awareness. Ask me about phishing, " +
                    "passwords, malware, safe browsing, or two-factor authentication!",

                ["what can i ask you about"] =
                    "Great question! You can ask me about:\n" +
                    "   • Password safety\n" +
                    "   • Phishing scams\n" +
                    "   • Safe browsing\n" +
                    "   • Malware & viruses\n" +
                    "   • Two-factor authentication (2FA)\n" +
                    "   • Social engineering\n" +
                    "   • Public Wi-Fi risks",

                ["help"] =
                    "Here are topics I can help with:\n" +
                    "   🔑 'password'        – Password best practices\n" +
                    "   🎣 'phishing'        – How to spot phishing scams\n" +
                    "   🌐 'safe browsing'   – Staying safe while browsing\n" +
                    "   🦠 'malware'         – What malware is and how to avoid it\n" +
                    "   🔐 '2fa'             – Two-factor authentication\n" +
                    "   🤝 'social engineering' – Manipulation tactics hackers use\n" +
                    "   📶 'public wifi'     – Dangers of public Wi-Fi\n" +
                    "   🚪 'exit'            – Exit the chatbot",

                // ── Password Safety ───────────────────────────────────
                ["password"] =
                    "🔑 PASSWORD SAFETY TIPS:\n" +
                    "   • Use at least 12 characters with a mix of letters, numbers & symbols.\n" +
                    "   • Never reuse passwords across different sites.\n" +
                    "   • Use a reputable password manager (e.g., Bitwarden, 1Password).\n" +
                    "   • Change passwords immediately if a breach is suspected.\n" +
                    "   • Avoid personal info like your name or birthdate in passwords.",

                ["password safety"] =
                    "A strong password is your first line of defence. Make it long (12+ chars), " +
                    "unique per site, and consider a passphrase like 'Purple!Rain#Boots7'.",

                // ── Phishing ──────────────────────────────────────────
                ["phishing"] =
                    "🎣 PHISHING AWARENESS:\n" +
                    "   • Phishing emails pretend to be from trusted sources (banks, SARS, etc.).\n" +
                    "   • Check the sender's actual email address — not just the display name.\n" +
                    "   • Hover over links before clicking to see the real URL.\n" +
                    "   • Legitimate companies will NEVER ask for your password via email.\n" +
                    "   • When in doubt, contact the organisation directly through their official site.",

                ["phishing email"] =
                    "Phishing emails often create urgency ('Your account will be closed!'). " +
                    "Slow down, check the sender's address, and never click suspicious links.",

                // ── Safe Browsing ─────────────────────────────────────
                ["safe browsing"] =
                    "🌐 SAFE BROWSING TIPS:\n" +
                    "   • Always look for 'https://' and the padlock icon in the address bar.\n" +
                    "   • Avoid downloading software from unofficial websites.\n" +
                    "   • Keep your browser and extensions up to date.\n" +
                    "   • Use an ad blocker to reduce exposure to malicious ads.\n" +
                    "   • Clear cookies and browsing history regularly.",

                ["browsing"] =
                    "Safe browsing starts with HTTPS, keeping your browser updated, and being " +
                    "cautious about what you download and which links you click.",

                // ── Malware ───────────────────────────────────────────
                ["malware"] =
                    "🦠 MALWARE PROTECTION:\n" +
                    "   • Malware includes viruses, ransomware, spyware, and trojans.\n" +
                    "   • Install and maintain reputable antivirus software.\n" +
                    "   • Never open email attachments from unknown senders.\n" +
                    "   • Keep your operating system and apps fully patched/updated.\n" +
                    "   • Back up your data regularly to an offline or cloud location.",

                ["virus"] =
                    "A computer virus is a type of malware that replicates itself to spread. " +
                    "Use up-to-date antivirus software and avoid downloading files from untrusted sources.",

                // ── 2FA ───────────────────────────────────────────────
                ["2fa"] =
                    "🔐 TWO-FACTOR AUTHENTICATION (2FA):\n" +
                    "   • 2FA adds a second verification step beyond your password.\n" +
                    "   • Even if your password is stolen, 2FA blocks unauthorised access.\n" +
                    "   • Use an authenticator app (Google Authenticator, Authy) over SMS when possible.\n" +
                    "   • Enable 2FA on email, banking, and social media accounts.",

                ["two factor"] =
                    "Two-factor authentication (2FA) significantly increases your account security. " +
                    "Enable it wherever possible — it's one of the most effective defences available.",

                // ── Social Engineering ────────────────────────────────
                ["social engineering"] =
                    "🤝 SOCIAL ENGINEERING:\n" +
                    "   • Attackers manipulate people — not just systems — to gain access.\n" +
                    "   • Common tactics: pretexting, baiting, tailgating, and vishing (voice phishing).\n" +
                    "   • Always verify the identity of anyone requesting sensitive information.\n" +
                    "   • Be sceptical of unsolicited calls or messages claiming to be IT support.",

                // ── Public Wi-Fi ──────────────────────────────────────
                ["public wifi"] =
                    "📶 PUBLIC WI-FI RISKS:\n" +
                    "   • Public Wi-Fi networks are often unencrypted — attackers can eavesdrop.\n" +
                    "   • Avoid accessing banking or sensitive accounts on public Wi-Fi.\n" +
                    "   • Use a VPN (Virtual Private Network) to encrypt your traffic.\n" +
                    "   • Forget the network after use to prevent automatic reconnection.",

                ["wifi"] =
                    "Public Wi-Fi can be dangerous. Always use a VPN and avoid sensitive " +
                    "transactions (banking, login pages) on unsecured networks.",
            };
        }

        // ──────────────────────────────────────────────────────────────
        //  Public Method: GetResponse
        // ──────────────────────────────────────────────────────────────

        /// <summary>
        /// Returns a response for the given user input, or a default fallback message.
        /// </summary>
        public string GetResponse(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return "I noticed you didn't type anything. Please enter a question or type 'help'.";

            string trimmed = userInput.Trim();

            // Exact match first
            if (_responses.TryGetValue(trimmed, out string? exactResponse))
                return exactResponse;

            // Keyword/partial match
            foreach (var entry in _responses)
            {
                if (trimmed.Contains(entry.Key, StringComparison.OrdinalIgnoreCase))
                    return entry.Value;
            }

            // Default fallback
            return "I didn't quite understand that. Could you rephrase? " +
                   "Try typing 'help' to see the topics I can assist with.";
        }

        /// <summary>
        /// Returns true if the user wants to exit.
        /// </summary>
        public static bool IsExitCommand(string input) =>
            input.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase) ||
            input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase) ||
            input.Trim().Equals("bye", StringComparison.OrdinalIgnoreCase);
    }
}
