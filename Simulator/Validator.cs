namespace Simulator
{
    public static class Validator
    {
        public static int Limiter(int value, int min, int max)
        {
            return Math.Clamp(value, min, max);
        }

        public static string Shortener(string value, int min, int max, char placeholder)
        {
            if (string.IsNullOrEmpty(value))
            {
                value = new string(placeholder, min); // Wypełnienie pustego ciągu
            }
            else
            {
                value = value.Trim(); // Usuń spacje na początku i końcu
                if (value.Length > max)
                {
                    value = value.Substring(0, max); // Przycięcie do maksymalnej długości
                }
                else if (value.Length < min)
                {
                    value = value.PadRight(min, placeholder); // Wypełnienie placeholderem
                }
            }

            // Konwersja pierwszej litery na wielką
            if (value.Length > 0)
            {
                value = char.ToUpper(value[0]) + value.Substring(1);
            }

            return value;
        }

    }
}
