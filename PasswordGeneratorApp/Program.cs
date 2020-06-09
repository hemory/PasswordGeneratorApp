namespace PasswordGeneratorApp
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a password.");
            string password = Console.ReadLine();

            bool hasNumbers = HasNumbers(password);
            bool hasLetters = HasLetters(password);
            bool hasSpecialCharacters = HasSpecialCharacters(password);

            Console.WriteLine(PasswordValidator(password, hasLetters, hasNumbers, hasSpecialCharacters));


            Console.ReadLine();
        }

        private static bool HasNumbers(string password)
        {

            // check for numbers first
            foreach (char character in password)
            {
                if (char.IsDigit(character))
                {
                    return true;
                }

            }

            return false;
        }

        private static bool HasLetters(string password)
        {

            // check for letters next
            foreach (char character in password)
            {
                if (char.IsLetter(character))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool HasSpecialCharacters(string password)
        {

            // now check for special characters
            foreach (char character in password)
            {
                if (char.IsLetterOrDigit(character) == false)
                {
                    return true;
                }
            }

            return false;
        }


        private static string PasswordValidator(string password, bool hasLetters, bool hasNumbers, bool hasSpecialCharacters)
        {
            bool hasAtLeast8Characters = password.Length >= 8;
            // now evaluate password strength
            if (hasAtLeast8Characters)
            {
                if (hasLetters && hasNumbers)
                {
                    if (hasSpecialCharacters)
                    {
                        return "very strong";
                    }

                    return "strong";
                }

                return "medium";
            }
            // less than 8 characters

            if (hasNumbers && hasLetters == false && hasSpecialCharacters == false)
            {
                return "very weak";
            }

            if (hasLetters && hasNumbers == false && hasSpecialCharacters == false)
            {
                return "weak";
            }

            return "medium";
        }
    }


}
