using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPX304_A3
{
    class QkeEmulator
    {
        private readonly Random _rng = new Random();

        public int[] ExchangeKey(int streamLength)
        {
            // 1) Prepare storage...
            int[] tValue = new int[streamLength];
            int[] tBasis = new int[streamLength];
            int[] rValue = new int[streamLength];
            int[] rBasis = new int[streamLength];
            
            var sharedKey = new List<int>();

            // 2) Transmiter (Alice) picks bits & bases...
            for (int i = 0; i < streamLength; i++)
            {
                tValue[i] = _rng.Next(0, 2);
                tBasis[i] = _rng.Next(0, 2);
            }

            // 3) Receiver (Bob) measures...
            for (int i = 0; i < streamLength; i++)
            {
                rBasis[i] = _rng.Next(0, 2);
                var qubit = new Qubit(tValue[i], tBasis[i]);
                rValue[i] = qubit.Measure(rBasis[i]);
            }

            // 4) Sift matches...
            for (int i = 0; i < streamLength; i++)
            {
                if (tBasis[i] == rBasis[i])
                {
                    sharedKey.Add(tValue[i]);
                }
            }

            // 5) return sharedKey array
            return sharedKey.ToArray();
        }
    }
}
    