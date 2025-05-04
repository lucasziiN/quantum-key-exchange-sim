using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPX304_A3
{
    class Program
    {
        static void Main()
        {
            // --- Quick Qubit checks ---
            var q = new Qubit(1, 0);                  
            Console.WriteLine($"Start: {q}");         

            // measuring in same basis should return 1 every time:
            Console.WriteLine("Measure(0): " + q.Measure(0));
            Console.WriteLine("Measure(0): " + q.Measure(0));

            // measuring in different basis should flip it randomly:
            int firstCollapse = q.Measure(1);
            Console.WriteLine($"Measure(1) collapsed to: {firstCollapse}");
            // now basis is 1, so this next read is stable:
            Console.WriteLine("Measure(1) again: " + q.Measure(1));

            Console.WriteLine();


            // --- Quick XOR cipher check ---
            string plain = "HELLO";
            string key = "WORLD";
            byte[] data = Encoding.UTF8.GetBytes(plain);
            byte[] keyB = Encoding.UTF8.GetBytes(key);

            // Encrypt
            byte[] cipher = XorCipher.Apply(data, keyB);
            Console.WriteLine("Cipher bytes: " + BitConverter.ToString(cipher));

            // Decrypt
            byte[] round = XorCipher.Apply(cipher, keyB);
            Console.WriteLine("Back to text: " + Encoding.UTF8.GetString(round));

            // Encrypt again
            cipher = XorCipher.Apply(data, keyB);
            Console.WriteLine("Cipher bytes: " + BitConverter.ToString(cipher));

            // Decrypt again
            round = XorCipher.Apply(cipher, keyB);
            Console.WriteLine("Back to text: " + Encoding.UTF8.GetString(round));


            // --- Quick QkeEmulator test ---
            var emulator = new QkeEmulator();

            string plain1 = "HELLO";
            int[] key1 = emulator.ExchangeKey(16);
            Console.WriteLine("Shared key length: " + key1.Length);
            Console.WriteLine("Bits: " + string.Join(",", key1));
            
            byte[] data1 = Encoding.UTF8.GetBytes(plain1);
            byte[] keyB1 = new byte[key1.Length];
            for (int i = 0; i< key1.Length; i++)
            {
                keyB1[i] = (byte)(key1[i]);
            }
            

            // Encrypt
            byte[] cipher1 = XorCipher.Apply(data1, keyB1);
            Console.WriteLine("Cipher bytes: " + BitConverter.ToString(cipher1));
            
            // Decrypt
            byte[] round1 = XorCipher.Apply(cipher1, keyB1);
            Console.WriteLine("Back to text: " + Encoding.UTF8.GetString(round1));

            // Verify
            var roundText = Encoding.UTF8.GetString(round1);
            Console.WriteLine("Round-trip OK? " + (roundText == plain1));

        }
    }
}
