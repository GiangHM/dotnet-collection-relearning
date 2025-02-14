using System.Collections.Frozen;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace dictionary_relearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WorkWithDictionary_1();

            WorkWithSortedDictionary();

            WorkWithReadOnlyDictionary();

            WorkWithImmutableDictionary();

            WorkWithFrozenDictionary();

            Console.ReadLine();
        }

        private static void WorkWithDictionary_1()
        {
            // Create a new Dictionary of strings, with string keys
            // and a case-insensitive comparer for the current culture.
            Dictionary<string, string> openWith = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);

            // Add some elements to the dictionary.
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("DIB", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");

            // Try to add a fifth element with a key that is the same
            // except for case; this would be allowed with the default
            // comparer.
            try
            {
                openWith.Add("BMP", "paint.exe");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("\nBMP is already in the dictionary.");
            }

            // List the contents of the dictionary.
            Console.WriteLine();
            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key,
                    kvp.Value);
            }
        }
        private static void WorkWithSortedDictionary()
        {
            // Create a new Dictionary of strings, with string keys
            // and a case-insensitive comparer for the current culture.
            SortedDictionary<string, string> openWith = new SortedDictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);

            // Add some elements to the dictionary.
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("DIB", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");

            // List the contents of the sorted dictionary.
            Console.WriteLine();
            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key,
                    kvp.Value);
            }
        }

        private static void WorkWithReadOnlyDictionary()
        {
            var dict = CreateDictionary();
            var myReadOnlyDict = dict.AsReadOnly();

            for (int i = 0; i < 1000000; i++)
            {
                myReadOnlyDict.TryGetValue(i.ToString(), out var value);
                Console.WriteLine(value);
            }
        }

        private static void WorkWithImmutableDictionary()
        {
            var dict = CreateDictionary();
            var myImmutableDictionary = dict.ToImmutableDictionary();

            for (int i = 0; i < 1000000; i++)
            {
                myImmutableDictionary.TryGetValue(i.ToString(), out var value);
                Console.WriteLine(value);
            }
        }

        private static void WorkWithFrozenDictionary()
        {
            var dict = CreateDictionary();
            var myImmutableDictionary = dict.ToFrozenDictionary();

            for (int i = 0; i < 1000000; i++)
            {
                myImmutableDictionary.TryGetValue(i.ToString(), out var value);
                Console.WriteLine(value);
            }
        }

        public void Create_ImmutableDictionary_AddElementToDictionary()
        {
            var dictionnary = ImmutableDictionary.Create<string, Goat>();
            for (int i = 0; i < 10000; i++)
            {
                dictionnary = dictionnary.Add(i.ToString(), new Goat { Name = i.ToString() });
            }
            for (int i = 0; i < 1000000; i++)
            {
                dictionnary.TryGetValue(i.ToString(), out var value);
                Console.WriteLine(value);
            }
        }
        private static Dictionary<string, Goat> CreateDictionary()
        {
            var dictionnary = new Dictionary<string, Goat>();
            for (int i = 0; i < 1000000; i++)
            {
                dictionnary.Add(i.ToString(), new Goat { Name = i.ToString() });
            }
            return dictionnary;
        }

    }

    internal class Goat
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Goat: {Name}";
        }
    }
}
