namespace task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RabinKarp rk = new RabinKarp();

            Console.WriteLine("Enter pattern");
            string pattern = Console.ReadLine();
            Console.WriteLine("Enter text");
            string text = Console.ReadLine();
            var result = rk.FindOccurences(pattern, text);
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
