using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPX304_A3
{
    
    public static class XorCipher
    {
        /// <summary>
        /// Applies an XOR cipher to the input data using the given key.
        /// If you run it twice with the same key, it will decrypt what was encrypted.
        /// </summary>
        /// <param name="data">The input data (either plain or encrypted).</param>
        /// <param name="key">The key used for encryption/decryption.</param>
        /// <returns>The result as a new byte array.</returns>
        /// <exception cref="ArgumentNullException">Thrown if data or key is null.</exception>
        /// <exception cref="ArgumentException">Thrown if the key is empty.</exception>
        public static byte[] Apply(byte[] data, byte[] key)
        {
            // Make sure the key isn't null or empty
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (key.Length == 0)
            {
                throw new ArgumentException("Key must not be empty", nameof(key));
            }

            // Make sure the data isn't null
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            // Create an output array with the same length as the input data
            var output = new byte[data.Length];

            // Loop through each byte of data
            for (int i = 0; i < data.Length; i++)
            {
                // Loop over the key with modulo in case the key is shorter than the data
                byte k = key[i % key.Length];

                // XOR the data byte with the key byte
                int xored = data[i] ^ k;

                // Store the result as a byte in the output array
                output[i] = (byte)xored;
                
            }

            // Return the final encrypted or decrypted result
            return output;
        }
    }
}
