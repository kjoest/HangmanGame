using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.View
{
    public class HangmanRepo : HangmanInterface
    {
        public void WelcomeScreen()
        {
            Console.Clear();

            Console.WriteLine("************************\n" +
                              "Welcome to Hangman!\n" +
                              "************************\n\n" +
                              "In Hangman your goal is to guess all the letters that make up\n" +
                              "the hidden word! If you get six incorrect guesses you lose.\n\n" +
                              "Each time you guess correctly, the letter is revealed in the word.\n" +
                              "A random word is chosen at the start of the game.\n\n\n\n\n" +
                              "Press ENTER to start the game...");

            Console.ReadLine();
        }

        public void RefreshGameScreen(IEnumerable<char> word, IEnumerable<char> incorrectGuesses)
        {
            Console.Write("\nWord: ");

            foreach (char letter in word)
            {
                Console.Write(letter + " ");
            }

            Console.Write("\nIncorrect Guesses: ");

            foreach (char letter in incorrectGuesses)
            {
                Console.Write(letter + ", ");
            }
        }

        public void LoseScreen(IEnumerable<char> word)
        {
            Console.Clear();

            Console.WriteLine("You're out of guesses! You Lose!\n\n" +
                              "The word was: ");

            foreach (char letter in word)
            {
                Console.Write(letter);
            }

            Console.WriteLine("\n\nPress ENTER to leave the game...");

            Console.ReadLine();

            Environment.Exit(0);
        }

        public void WinScreen(IEnumerable<char> word, int incorrectGuessesCount)
        {
            Console.Clear();

            Console.WriteLine("\nCongratulations! You Win!\n\n" +
                              "You had " + incorrectGuessesCount + " incorrect guesses!\n\n" +
                              "The final word was: ");

            foreach (char letter in word)
            {
                Console.Write(letter);
            }

            Console.WriteLine("\n\n\nPress ENTER to leave the game...");

            Console.ReadLine();
        }

        public void RequestGuess()
        {
            Console.WriteLine("\nEnter a guess");
        }

        public void AlreadyGuessed()
        {
            Console.WriteLine("\nYou have already guessed that letter!\n\n\n" +
                              "Press any key to continue...");

            Console.ReadKey();
        }

        public void InvalidGuess()
        {
            Console.WriteLine("\nInvalid Guess. Guesses must be a single alphabetical letter.\n\n\n" +
                              "Press any key to continue...");

            Console.ReadKey();
        }
    }
}
