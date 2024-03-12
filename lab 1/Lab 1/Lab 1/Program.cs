namespace task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] stringArray = new string[n];

            for (int i = 0;i < n; i++)
            {
                stringArray[i] = Console.ReadLine();
            }

            Dictionary<int, int> hashes = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                hashes.Add(i, getHash(stringArray[i]));
            }
            
            var groups = hashes.GroupBy(x => x.Value);

            foreach (var group in groups)
            {
                Console.WriteLine("equal string groups:" + string.Join(" ", group.Select(x => x.Key + 1)));
            }

            
        }

        public static int getHash(string str, int stringBase = 256, int modulus = 101)
        {
            int hash = 0;
            for (int i = 0; i < str.Length; i++)
            {
                hash += str[i] * (int)Math.Pow(stringBase, str.Length - i - 1) % modulus;
            }
            return hash;

        }
    }
}
