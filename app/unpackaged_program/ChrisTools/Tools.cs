namespace ChrisTools
{
    public class Funcs
    {
        private static char[] charsToTrim = { ' ', '.', '!' };

        public static string trim(string x) // trim selected characters
        {
            return x.Trim(charsToTrim);
        }

        public static string CapitalizeFirstLetter(string x)
        {
            return x.Substring(0, 1).ToUpper() + x.Substring(1);
        }

        public static string Title(string x) // named this because of python func
        {
            return string.Join(" ", x.Split(' ').ToList()
                .ConvertAll(word =>
                    word.Substring(0, 1).ToUpper() + word.Substring(1)
                ));
        }
    }
}