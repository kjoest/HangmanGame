using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.View
{
    public interface HangmanInterface
    {
        void WelcomeScreen();
        void RefreshGameScreen(IEnumerable<char> word, IEnumerable<char> incorrectGuesses);
        void LoseScreen(IEnumerable<char> word);
        void WinScreen(IEnumerable<char> word, int incorrectGuessesCount);
        void RequestGuess();
        void AlreadyGuessed();
        void InvalidGuess();
    }
}


