//class Program
//{
//    static async Task Main(string[] args)
//    {
//        await callMethod();
//        Console.ReadKey();
//    }

//    public static async Task callMethod()
//    {
//        Method2();
//        var count = await Method1();
//        Method3(count);
//    }

//    public static async Task<int> Method1()
//    {
//        int count = 0;
//        await Task.Run(() =>
//        {
//            for (int i = 0; i < 100; i++)
//            {
//                Console.WriteLine(" Method 1");
//                count += 1;
//            }
//        });
//        return count;
//    }

//    public static void Method2()
//    {
//        for (int i = 0; i < 25; i++)
//        {
//            Console.WriteLine(" Method 2");
//        }
//    }

//    public static void Method3(int count)
//    {
//        Console.WriteLine("Total count is " + count);
//    }
//}
class Program
{
    static void Main()
    {
        Task task = new Task(CallMethod);
        task.Start();
        task.Wait();
        Console.ReadLine();
    }

    static async void CallMethod()
    {
        string filePath = "E:\\sampleFile.txt";
        Task<int> task = ReadFile(filePath);

        Console.WriteLine(" Other Work 1");
        Console.WriteLine(" Other Work 2");
        Console.WriteLine(" Other Work 3");

        int length = await task;
        Console.WriteLine(" Total length: " + length);

        Console.WriteLine(" After work 1");
        Console.WriteLine(" After work 2");
    }

    static async Task<int> ReadFile(string file)
    {
        int length = 0;

        Console.WriteLine(" File reading is stating");
        using (StreamReader reader = new StreamReader(file))
        {
            // Reads all characters from the current position to the end of the stream asynchronously
            // and returns them as one string.
            string s = await reader.ReadToEndAsync();

            length = s.Length;
        }
        Console.WriteLine(" File reading is completed");
        return length;
    }
}