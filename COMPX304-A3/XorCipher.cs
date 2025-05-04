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
        /// Applies an XOR cipher to the input data with the given key.
        /// Running this twice with the same key decrypts what you encrypted.
        /// </summary>
        /// <param name="data">The plaintext or ciphertext bytes (must not be null).</param>
        /// <param name="key">The key bytes (must not be null or empty).</param>
        /// <returns>A fresh byte[] the same length as data, containing the result.</returns>
        /// <exception cref="ArgumentNullException">
        ///   Thrown if data or key is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///   Thrown if key.Length == 0.
        /// </exception>
        public static byte[] Apply(byte[] data, byte[] key)
        {
            // 1) Validate inputs
            if (key.Length == 0 || key == null)
            {
                throw new ArgumentException("Key must not be empty", nameof(key));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            // 2) Prepare the output buffer
            var output = new byte[data.Length];

            // 3) XOR loop: for each data byte, pick the corresponding key byte (wrapping via modulo)
            for (int i = 0; i < data.Length; i++)
            {
                // wrap-around behavior: once i >= key.Length, start back at key[0]
                byte k = key[i % key.Length];

                // XOR the two bytes; result is an int, so need to cast back to byte
                int xored = data[i] ^ k;
                output[i] = (byte)xored;
                
            }

            // 4) Return the encrypted/decrypted bytes
            return output;
        }
    }
}
