Console.WriteLine("Hello, World!");

// Creates and initializes a new integer array and a new Object array.
int[] myIntArray = new int[5] { 1, 2, 3, 4, 5 };

// Prints the initial values of both arrays.
Console.WriteLine("Initially,");
Console.Write("Integer array:");
PrintValues(myIntArray);

try
{
    myIntArray[5] = 6;
}
catch (Exception e)
{
    Console.WriteLine("Cannot add more element since array is fixed size {0}", e.Message);
}

// Check if the int array can have new value
Console.Write("Integer array after tring to add new element:");
PrintValues(myIntArray);

// Since array is fixed size, we need to create a new array to resize it.
int[] myNewArray = new int[6];
// Copies the values of the first array to the new array.
myIntArray.CopyTo(myNewArray, 0);
// Add new elemnt to the new array.
myNewArray[5] = 6;

Console.Write("My new array with resizing:");
PrintValues(myNewArray);

static void PrintValues(int[] myArr)
{
    foreach (int i in myArr)
    {
        Console.Write("\t{0}", i);
    }
    Console.WriteLine();
}

// Benerfits
// Access element fast by index, memory efficient.
// Drawbacks
// Fixed size, it's challenging to resize it.