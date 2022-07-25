namespace Task.Helpers
{
    public static class HelperMethods
    {
        public static bool isCorrect(this List<string> stringList)
        {
            foreach (string el in stringList)
            {
                if (!el.All(char.IsDigit))
                {
                    return false;
                }
            }
            return true;
        }

        public static List<string> modifyInput(this string inputString)
        {

            char[] separators = { ' ', ','};

            var splitList = inputString.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();

            return splitList;
        }

        public static string Counter(this List<string> numbersList)
        {
            List<string> duplicates = numbersList.GroupBy(x => x)
                .Where(x => x.Count() > 2)
                .Select(x => x.Key)
                .OrderByDescending(x => x)
                .ToList();

            var outputString = String.Join(", ", duplicates);
            
            return outputString;
        }
    }
}