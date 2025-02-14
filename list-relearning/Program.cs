
namespace list_relearning
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Collections.ObjectModel;

    // Simple business object. A PartId is used to identify the type of part
    // but the part name can change.
    public class Part : IEquatable<Part>, IComparable<Part>
    {
        public string PartName { get; set; }

        public int PartId { get; set; }

        public override string ToString()
        {
            return "ID: " + PartId + "   Name: " + PartName;
        }
        public override int GetHashCode()
        {
            return PartId;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Part objAsPart) return false;
            else return Equals(objAsPart);
        }
        // Implementation for IEquatable<T>
        public bool Equals(Part? other)
        {
            if (other == null) return false;
            return (this.PartId.Equals(other.PartId));
        }
        //Implementation for IComparable<T>
        public int CompareTo(Part? other)
        {
            // A null value means that this object is greater.
            if (other == null)
                return 1;
            else
                return this.PartId.CompareTo(other.PartId);
        }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-collections-generic-list%7Bt%7D
    /// https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-9.0#definition
    /// </summary>
    internal static class Example
    {
        internal static void Main()
        {
            // Create a list of parts.
            List<Part> parts =
            [
                // Add parts to the list.
                new Part() { PartName = "regular seat", PartId = 1434 },
                new Part() { PartName = "crank arm", PartId = 1234 },
                new Part() { PartName = "shift lever", PartId = 1634 },
                new Part() { PartName = "chain ring", PartId = 1334 },
                new Part() { PartName = "banana seat", PartId = 1444 },
                new Part() { PartName = "cassette", PartId = 1534 },
            ];

            WorkWithList(parts);

            WorkWithReadOnlyList(parts);

            WorkWithImmutableList(parts);

            Console.ReadLine();
        }

        private static void WorkWithList(List<Part> parts)
        {
            // Write out the parts in the list. This will call the overridden ToString method
            // in the Part class.
            Console.WriteLine();
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }
            // Check the list for part #1734. This calls the IEquatable.Equals method
            // of the Part class, which checks the PartId for equality.
            Console.WriteLine("\nContains(\"1734\"): {0}",
            parts.Contains(new Part { PartId = 1734, PartName = "" }));

            // Insert a new item at position 2.
            Console.WriteLine("\nInsert(2, \"1834\")");
            parts.Insert(2, new Part() { PartName = "brake lever", PartId = 1834 });

            // Sort use IComparable<T>, compare the part id
            parts.Sort();

            Console.WriteLine("\n After sort by comparing part id");
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }

            // Sort by provide a comparison
            parts.Sort((x, y) =>
            {
                if (x.PartName == null && y.PartName == null)
                    return 0;
                else if (x.PartName == null)
                    return -1;
                else if (y.PartName == null)
                    return 1;
                else 
                    return x.PartName.CompareTo(y.PartName);
            });

            Console.WriteLine("\n After sort by comparing part name");
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }

            Console.WriteLine("\nParts[3]: {0}", parts[3]);

            Console.WriteLine("\nRemove(\"1534\")");

            // This will remove part 1534 even though the PartName is different,
            // because the Equals method only checks PartId for equality.
            parts.Remove(new Part() { PartId = 1534, PartName = "cogs" });

            Console.WriteLine();
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }
            Console.WriteLine("\nRemoveAt(3)");
            // This will remove the part at index 3.
            parts.RemoveAt(3);

            Console.WriteLine();
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }
        }

        private static void WorkWithReadOnlyList(List<Part> parts)
        {
            // Work with ReadOnlyList
            IReadOnlyList<Part> myReadOnlyList = parts.AsReadOnly();

            Console.WriteLine("\n Print values from IReadOnlyList");
            PrintValue(myReadOnlyList);

            // Change data of List
            parts.Add(new Part { PartId = 1734, PartName = "Add 1734 part - ReadOnlyList Sample" });

            Console.WriteLine("\n Print values from IReadOnlyList after changing underlying List");

            PrintValue(myReadOnlyList);
        }

        private static void WorkWithImmutableList(List<Part> parts)
        {
            // ImmutableList
            IImmutableList<Part> myImmutableList = parts.ToImmutableList<Part>();
            Console.WriteLine("\n Print values from IImmutableList");
            PrintValue(myImmutableList);            // Change data of List
            parts.Add(new Part { PartId = 1834, PartName = "Add 1834 part - ImmutableList sample" });

            Console.WriteLine("\n Print values from IImmutableList after changing underlying List");
            PrintValue(myImmutableList);

            Console.WriteLine("\n Print values from underlying List");
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }

        }

        static void PrintValue(IReadOnlyList<Part> inputParts)
        {
            foreach (Part aPart in inputParts)
            {
                Console.WriteLine(aPart);
            }
        }

        static void PrintValue(IImmutableList<Part> inputParts)
        {
            foreach (Part aPart in inputParts)
            {
                Console.WriteLine(aPart);
            }
        }
    }
}

// List<T> is a generic type, which means you specify the type of elements in the list when you create it.
// Type safe
// Size dynamically grows as needed.
// Contains, IndexOf, LastIndexOf, and Remove => use IEquatable<T> to compare
// Sort, BinarySearch => use IComparable<T> to compare

// Peformance considerations <> ArrayList
// Value type: be aware of boxing and unboxing when use ArrayList
// Value type => should implement IEquatable -> prevent boxing
// Value type => should implement IComparable -> prevent boxing
