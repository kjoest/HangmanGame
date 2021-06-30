using Hangman.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hangman
{
    public class ProgramUI
    {
        private List<char> wordToGuess;
        private List<char> wordGuessed;
        private List<char> incorrectGuesses;

        private HangmanInterface _hangmanInterface;
        private bool isRunning = false;

        public ProgramUI(HangmanInterface hangmanInterface, string word)
        {
            _hangmanInterface = hangmanInterface;
            wordToGuess = new List<char>();
            wordGuessed = new List<char>();
            incorrectGuesses = new List<char>();

            // Setup the game with the new word.
            wordToGuess.AddRange(word);

            for (int x = 0; x < wordToGuess.Count; x++)
            {
                wordGuessed.Add('_');
            }

            _hangmanInterface.WelcomeScreen();

            if (!isRunning)
            {
                GameLoop();
            }
        }

        // Runs and handles the hangman game.
        private void GameLoop()
        {
            isRunning = true;

            while (wordGuessed.Contains('_'))
            {
                Console.Clear();

                _hangmanInterface.RefreshGameScreen(wordGuessed, incorrectGuesses);

                // Request the users next guess.
                _hangmanInterface.RequestGuess();

                string playerGuess = Console.ReadLine().ToUpper();

                if (ValidateGuess(playerGuess))
                {
                    char guess = Convert.ToChar(playerGuess);

                    if (!wordGuessed.Contains(guess) && !incorrectGuesses.Contains(guess))
                    {
                        if (wordToGuess.Contains(guess))
                        {
                            // Handle a correct guess.
                            for (int lives = 0; lives < wordToGuess.Count; lives++)
                            {
                                if (wordToGuess[lives] == guess)
                                {
                                    wordGuessed[lives] = guess;
                                }
                            }
                        }
                        else
                        {
                            // Handle an incorrect guess.
                            incorrectGuesses.Add(guess);

                            if (incorrectGuesses.Count >= 6)
                            {
                                _hangmanInterface.LoseScreen(wordToGuess);
                            }
                        }
                    }
                    else
                    {
                        _hangmanInterface.AlreadyGuessed();
                    }
                }
                else
                {
                    _hangmanInterface.InvalidGuess();
                }
            }

            // The player has won.
            _hangmanInterface.WinScreen(wordToGuess, incorrectGuesses.Count);
        }

        private static bool ValidateGuess(string guess)
        {
            return (guess.Length == 1) && Regex.IsMatch(guess, @"^[a-zA-Z]+$");
        }
    }
}

