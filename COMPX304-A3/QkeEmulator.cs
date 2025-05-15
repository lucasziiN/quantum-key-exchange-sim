using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPX304_A3
{
    public class QkeEmulator
    {
        // Random number generator used for bit and basis selection
        private readonly Random _rng = new Random();

        /// <summary>
        /// Simulates the exchange of a key using a basic quantum key exchange approach.
        /// Returns the shared key as an array of bits.
        /// </summary>
        public int[] ExchangeKey(int streamLength)
        {
            // 1) Create arrays to hold transmitter and receiver data
            int[] tValue = new int[streamLength];  // Transmitter's bits
            int[] tBasis = new int[streamLength];  // Transmitter's bases
            int[] rValue = new int[streamLength];  // Receiver's measured bits
            int[] rBasis = new int[streamLength];  // Receiver's chosen bases

            // List to hold bits that will form the shared key
            var sharedKey = new List<int>();

            // 2) Transmitter (Alice) randomly picks bits and bases
            for (int i = 0; i < streamLength; i++)
            {
                tValue[i] = _rng.Next(0, 2);   // Random bit (0 or 1)
                tBasis[i] = _rng.Next(0, 2);   // Random basis (0 = circular, 1 = linear)
            }

            // 3) Receiver (Bob) picks bases and measures the qubits
            for (int i = 0; i < streamLength; i++)
            {
                rBasis[i] = _rng.Next(0, 2);                    // Bob picks a random basis
                var qubit = new Qubit(tValue[i], tBasis[i]);    // Alice's qubit
                rValue[i] = qubit.Measure(rBasis[i]);           // Bob measures using his basis
            }

            // 4) Sift phase: keep bits where Alice and Bob used the same basis
            for (int i = 0; i < streamLength; i++)
            {
                if (tBasis[i] == rBasis[i])
                {
                    sharedKey.Add(tValue[i]);
                }
            }

            // 5) Return the shared key as an array
            return sharedKey.ToArray();
        }
    }
}
    