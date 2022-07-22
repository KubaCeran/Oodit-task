namespace Task.Helpers
{
    public static class HelperMethods
    {
        public static bool isCorrect(string[] stringArray)
        {
            foreach (string el in stringArray)
            {
                if (!el.All(char.IsDigit))
                {
                    return false;
                }
            }
            return true;
            
        }

        public static string[] modifyInput(string inputString)
        {

            char[] separators = { ' ', ','};

            var splitArray = inputString.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return splitArray;
        }

        public static int[] modifyArray(string[] stringArray)
        {
            int[] numbers = Array.ConvertAll(stringArray, int.Parse);
            Array.Sort(numbers);
            Array.Reverse(numbers);
            return numbers;
        }

        public static string Counter(int[] intArray)
        {
            var prevNumber = intArray[0];
            int counter = 0;
            var outputList = new List<int>();
            for (var i = 1; i < intArray.Length; i++)
            {
                if (prevNumber == intArray[i])
                {
                    counter++;
                }
                else
                {
                    if (counter >= 2)
                    {
                        outputList.Add(prevNumber);
                    }
                    counter = 0;
                }
                prevNumber = intArray[i];
            }
            if (counter >= 2)
            {
                outputList.Add(prevNumber);
            }
            var outputString = String.Join(", ", outputList);

            return outputString;
        }
    }
}