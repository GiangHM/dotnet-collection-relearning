namespace queue_relearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var myQueue = new Queue<Part>();
            myQueue.Enqueue(new Part { PartId = 1, PartName = "Orange" });
            myQueue.Enqueue(new Part { PartId = 2, PartName = "Green" });
            myQueue.Enqueue(new Part { PartId = 3, PartName = "Red" });

            Console.WriteLine("This my initial queue");
            PrintValues(myQueue);

            // Peek a element
            var firstElement = myQueue.Peek();
            Console.WriteLine("This is my first element: {0}", firstElement);

            // Check if the first element was remove by Peek Method
            Console.WriteLine("This my queue after peeking");
            PrintValues(myQueue);

            // Remove element from Queue
            var element = myQueue.Dequeue();
            Console.WriteLine("Dequeue: {0}", element);

            // Check Queue after dequeue
            Console.WriteLine("This my queue after dequeueing");
            PrintValues(myQueue);

            Console.ReadLine();
        }

        static void PrintValues(IEnumerable<Part> queueInformation)
        {
            foreach (var part in queueInformation)
            {
                Console.WriteLine(part);
            }
        }
    }

    public class Part
    {
        public string PartName { get; set; }

        public int PartId { get; set; }

        public override string ToString()
        {
            return "ID: " + PartId + "   Name: " + PartName;
        }
    }
}
