using System;

namespace task_2
{
    public class RabinKarp
    {
        private readonly int _baseNumber;
        private readonly int _modulus;

        public RabinKarp(int baseNumber = 256, int modulus = 3673)
        {
            _baseNumber = baseNumber;
            _modulus = modulus;
        }

        public List<int> FindOccurences(string pattern, string text)
        {
            var patternSpan = pattern.AsSpan();
            var textSpan = text.AsSpan();

            int patternHash = GetHash(pattern);
            int textHash = GetHash(text.Substring(0, pattern.Length));
            int baseHash = PowMod(_baseNumber, pattern.Length - 1);
            List<int> result = new List<int>();

            for (int i = 0; i < text.Length - pattern.Length; i++)
            {
                if (textHash == patternHash && patternSpan.SequenceEqual(textSpan.Slice(i, pattern.Length)))
                {
                    result.Add(i);
                }

                textHash -= (text[i] * baseHash) % _modulus;
                textHash += _modulus;
                textHash *= _baseNumber;
                textHash += text[i + pattern.Length];
                textHash %= _modulus;
            }
            if (textHash == patternHash)
            {
                result.Add(text.Length - pattern.Length);
            }

            return result;
        }

        int GetHash(string str)
        {
            int hash = str[0] % _modulus;

            for (int i = 1; i < str.Length; i++)
            {
                hash *= _baseNumber;
                hash += str[i];
                hash %= _modulus;
            }

            return hash;
        }

        int PowMod(int x, int y)
        {
            int result = x;
            for (int i = 2; i <= y; i++)
            {
                result = result * x % _modulus;
            }
            return result;
        }
    }
}
