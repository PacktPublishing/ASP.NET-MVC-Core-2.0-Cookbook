using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EncryptDecryptData
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = Guid.NewGuid().ToString("N");

            var original = "Hello World!";
            var encrypted = Encrypt(original, key);
            var decrypted = Decrypt(encrypted, key);

            Console.WriteLine(original);
            Console.WriteLine(encrypted);
            Console.WriteLine(decrypted);

            Console.ReadKey();
        }

        static string Encrypt(string text, string key)
        {
            var _key = Encoding.UTF8.GetBytes(key);

            using (var aes = Aes.Create())
            {
                using (var encryptor = aes.CreateEncryptor(_key, aes.IV))
                {
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (var sw = new StreamWriter(cs))
                            {
                                sw.Write(text);
                            }
                        }

                        var iv = aes.IV;

                        var encrypted = ms.ToArray();

                        var result = new byte[iv.Length + encrypted.Length];

                        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                        Buffer.BlockCopy(encrypted, 0, result, iv.Length, encrypted.Length);

                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        static string Decrypt(string encrypted, string key)
        {
            var b = Convert.FromBase64String(encrypted);

            var iv = new byte[16];
            var cipher = new byte[16];

            Buffer.BlockCopy(b, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(b, iv.Length, cipher, 0, iv.Length);

            var _key = Encoding.UTF8.GetBytes(key);

            using (var aes = Aes.Create())
            {
                using (var decryptor = aes.CreateDecryptor(_key, iv))
                {
                    var result = string.Empty;
                    using (var ms = new MemoryStream(cipher))
                    {
                        using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (var sr = new StreamReader(cs))
                            {
                                result = sr.ReadToEnd();
                            }
                        }
                    }

                    return result;
                }
            }
        }
    }
}
