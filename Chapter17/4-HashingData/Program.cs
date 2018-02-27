using System;
using System.Security.Cryptography;
using System.Text;

namespace HashingData
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashed = CalculateHash("Hello World!");
            Console.WriteLine(hashed);

            Console.ReadKey();
        }

        static string CalculateHash(string input)
        {
            using (var algorithm = SHA512.Create())
            {
                var b = algorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BitConverter.ToString(b).Replace("-", "").ToLower();
            }
        }
    }
}
