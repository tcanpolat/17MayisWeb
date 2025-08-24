namespace _07_CustomHelpers.Helpers
{
    public static class StringHelper
    {
        public static string CapitalizeForFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input.Substring(1);
        }

        public static string CapitalizeWords(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            var words = input.Split(' ');

            for (int i = 0; i<words.Length; i++)
            {
                words[i] = CapitalizeForFirstLetter(words[i]);
            }

            return string.Join(" ", words);
        }
    }
}
