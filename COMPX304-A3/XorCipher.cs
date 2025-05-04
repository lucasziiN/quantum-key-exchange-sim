using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPX304_A3
{
    public static class XorCipher
    {
        // Applies the XOR operation to data[] using key[]
        public static byte[] Apply(byte[] data, byte[] key)
        {
            if (key.Length == 0 || key == null)
            {
                throw new ArgumentException("Key must not be empty", nameof(key));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var output = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                byte k = key[i % key.Length];

                int xored = data[i] ^ k;
                output[i] = (byte)xored;
                
            }
            return output;
        }
    }
}
