namespace Lab2
{
    static class Program
    {
        private static void Main()
        {
            var s= "good morning.";
            Console.WriteLine("String: " + s);
            Console.WriteLine("Inverted string: " + s.InvertString());
            Console.WriteLine("Amount of 'o' letters: " + s.SymbolCount('o'));
            Console.WriteLine();

            var array = new[] {1, 3, 3, 5, 3, 6, 7, 3, 9};
            array.PrintArray();
            Console.WriteLine("Amount of '3' in array: " + array.ArrayEntriesCount(3));
            Console.WriteLine("Array with removed copies: ");
            array.RemoveCopies().PrintArray();
            Console.WriteLine();

            string[] array2 = { "good", "morning", "good", "excelent", "morning" };
            array2.PrintArray();
            Console.WriteLine("Amount of 'morning' in array: " + array2.ArrayEntriesCount("morning"));
            Console.WriteLine("Array with removed copies: ");
            array2.RemoveCopies().PrintArray();
            Console.WriteLine();

            ExtendedDictionary<string, int, int> d = new ExtendedDictionary<string, int, int>
            {
                { "a", 12, 23 },
                { "b", 4, 10 },
            };

            d.Add("c", 4, 5);

            Console.WriteLine("COUNT: " + d.Count);

            Console.WriteLine($"{d[1].Key} {d[1].FirstValue} {d[1].SecondValue}");
            Console.WriteLine("Check if contain value 12 and 22: " + d.ContainsValue(12, 23));
            Console.WriteLine("Check if contain key 'c': " + d.ContainsKey("c"));
            Console.WriteLine("Check if contain key 'q': " + d.ContainsKey("q"));
            Console.WriteLine($"{d["a"].Key} {d["a"].FirstValue} {d["a"].SecondValue}");
            d["a"] = new ExtendedDictionaryElement<string, int, int> { Key = "a", FirstValue = 16, SecondValue = 7 };
            Console.WriteLine($"{d["a"].Key} {d["a"].FirstValue} {d["a"].SecondValue}");

            foreach (var item in d)
                Console.WriteLine($"Key: {item.Key} FirstValue: {item.FirstValue} SecondValue: {item.SecondValue}");

            d.Remove("c");
            Console.WriteLine("Removed element with key 'c'.");

            foreach (var item in d)
                Console.WriteLine($"Key: {item.Key} FirstValue: {item.FirstValue} SecondValue: {item.SecondValue}");


            Console.ReadKey();
        }

        private static string InvertString(this string s)
        { 
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }

        private static int SymbolCount(this string s, char c)
        {
            int count = 0;
            foreach (char symbol in s)
                if (symbol == c)
                    count++;

            return count;
        }
        
        private static int ArrayEntriesCount<T>(this T[] array, T o)
        {
            int count = array.Count(entry => entry.Equals(o));

            return count;
        }

        private static T[] RemoveCopies<T>(this T[] array)
        {
            return array.Distinct().ToArray();
        }

        private static void PrintArray<T>(this T[] array)
        {
            foreach(var item in array)
                Console.Write(item + " ");
                
            Console.WriteLine();
        }
    }
}