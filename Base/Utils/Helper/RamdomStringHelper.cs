namespace BufaloCargo.Utils.Helper
{
    public static class RamdomStringHelper
    {
        const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
        const string UPPER_CAES = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMBERS = "123456789";
        const string SPECIALS = @"!$*+&";

        public static string GeneratePassword(bool useLowercase, bool useUppercase, bool useNumbers, bool useSpecial,
        int passwordSize)
        {
            char[] _password = new char[passwordSize];
            string charSet = ""; // Initialise to blank
            System.Random _random = new Random();
            string pass = string.Empty;


            for (int i = 0; i < 3; i++)
            {
                charSet += LOWER_CASE[_random.Next(LOWER_CASE.Length - 1)];
            }

            for (int i = 0; i < 2; i++)
            {
                charSet += UPPER_CAES[_random.Next(UPPER_CAES.Length - 1)];
            }
            for (int i = 0; i < 2; i++)
            {
                charSet += NUMBERS[_random.Next(NUMBERS.Length - 1)];
            }
            for (int i = 0; i < 1; i++)
            {
                charSet += SPECIALS[_random.Next(SPECIALS.Length - 1)];
            }

            Random rnd = new Random();
            char[] mypass = charSet.OrderBy(x => rnd.Next()).ToArray();

            pass = String.Join(null, mypass);


            return pass;
        }
    }
}
