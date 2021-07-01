using Hangman.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        // Possible words the user has to guess
        private static readonly string[] HangmanWords = 
        {
            "HANGMAN", "SUBWAY", "LUCKY", "JACKPOT", 
            "APPLE", "BLITZ", "BANJO", "JUNE", "FLAPJACK", 
            "ZIPPER", "JAZZ", "WAVE", "DOG"
        };

        static void Main(string[] args)
        {
            var random = new Random();
            var hangmanInterface = new HangmanRepo();
            var game = new ProgramUI(hangmanInterface, HangmanWords[random.Next(HangmanWords.Length)]);
        }
    }
}
