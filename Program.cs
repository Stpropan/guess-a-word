using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int guessCount = 0;
            string secretWord = "imagination";
            Console.WriteLine("Enter secret word");
            string newSecretWord = Console.ReadLine().ToLower();
            string pattern = "^[A-z]*$";
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            while (!r.Match(newSecretWord).Success)
            {
                Console.WriteLine("Try again. You can use only A-z symbols");
                newSecretWord = Console.ReadLine().ToLower();
            }
            if (!String.IsNullOrEmpty(newSecretWord))
            {
                secretWord = newSecretWord;
            }
            Console.Clear();
            Console.WriteLine("This is a game of guesses");
            Console.WriteLine("Rules are really simple");
            Console.WriteLine("Someone typed a secret word");
            Console.WriteLine("You must guess it");
            Console.WriteLine("_ - are showed under symbols that don't used in secret word");
            Console.WriteLine("* - are symbols that used in secret word but don't stand on right place");
            Console.WriteLine("[a-z] - are symbols that you really guessed");
            Console.WriteLine("Try guessing by typing any " + secretWord.Length + " symbols");
            string hint = Regex.Replace(secretWord, ".", "_");
            string guess = "";
            Console.WriteLine(hint);

            while (guess != secretWord)
            {
                char[] temporarySecretWord = secretWord.ToCharArray();
                Console.WriteLine("Enter your guess");
                guess = Console.ReadLine().ToLower();
                if (guess.Length != secretWord.Length)
                {
                    Console.WriteLine("You need to type exactly " + secretWord.Length + " symbols");
                }
                else
                {
                    string temporarySecretWordString = secretWord;
                    char[] hintChars = hint.ToCharArray();
                    for (int i = 0; i < guess.Length; i++)
                    {
                        if (guess[i] == char.ToLower(temporarySecretWord[i]))
                        {
                            temporarySecretWord[i] = char.ToUpper(temporarySecretWord[i]);
                            hintChars[i] = guess[i];
                            char[] guessChars = guess.ToCharArray();
                            guessChars[i] = char.ToUpper(guess[i]);
                            guess = new string(guessChars);
                        }
                    }
                    for (int i = 0; i < guess.Length; i++)
                    {
                        if (guess[i] == char.ToLower(guess[i]))
                        {
                            char letter = guess[i];
                            temporarySecretWordString = new string(temporarySecretWord);
                            int occurance = temporarySecretWordString.IndexOf(letter);
                            if (occurance >= 0)
                            {
                                temporarySecretWord[occurance] = char.ToUpper(temporarySecretWord[occurance]);
                                hintChars[i] = '*';
                            }
                        }
                    }
                    Console.WriteLine(hintChars);
                    guessCount++;
                }
                guess = guess.ToLower();
            }
            Console.WriteLine("Well done! You win in " + guessCount + " guesses");
        }
    }
}
