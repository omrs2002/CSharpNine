using System;
using System.Linq;

namespace CSHarpNineConsoleApp
{
    public static class Util
    {
        public static bool IsAnyValueZero((decimal, decimal) aTuple)
        {
            switch (aTuple)
            {
                case ValueTuple<decimal, decimal> t when t.Item1 == 0 || t.Item2 == 0:
                    return true;
                default:
                    break;
            }
            return false;
        }

        public static bool IsAnyValueZero2((decimal, decimal) aTuple)
        {
            switch (aTuple)
            {
                case (decimal i1, decimal i2) when i1 == 0 || i2 == 0:
                    return true;
            }
            return false;
        }



        public static string GenerateRandomPassword()
        {
            const string capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            const string specialChars = "!@#$%^&*()_+";

            var random = new Random();
            var passwordChars = new char[8];

            // Choose one random capital letter
            passwordChars[random.Next(0, passwordChars.Length)] = capitalLetters[random.Next(0, capitalLetters.Length)];

            // Choose one random number
            passwordChars[random.Next(0, passwordChars.Length)] = numbers[random.Next(0, numbers.Length)];

            // Choose one random special character
            passwordChars[random.Next(0, passwordChars.Length)] = specialChars[random.Next(0, specialChars.Length)];

            // Fill the rest of the password with random characters
            var remainingChars = passwordChars.Length - 3;
            for (var i = 0; i < remainingChars; i++)
            {
                char randomChar;
                do
                {
                    randomChar = (char)random.Next(33, 127); // ASCII printable characters
                } while (randomChar == ' ' || capitalLetters.Contains(randomChar) || numbers.Contains(randomChar) || specialChars.Contains(randomChar));

                passwordChars[i + 3] = randomChar; // Shift the index by 3 to account for the first 3 characters
            }

            // Shuffle the characters and return the password as a string
            return new string(passwordChars.OrderBy(c => random.Next()).ToArray());
        }




    }
}
