using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPX304_A3
{
    public class Qubit
    {
        // 0 for circular, 1 for linear
        private int _value;
        private int _polarization;

        private static readonly Random _rng = new Random();

        /// <summary>
        /// Constructor: + new(value, polarization)
        /// </summary>
        public Qubit(int value, int polarization)
        {
            Set(value, polarization);
        }

        /// <summary>
        /// + set(value, polarization)
        /// </summary>
        public void Set(int value, int polarization)
        {

            ValidateBit(value);
            ValidateBasis(polarization);
            _value = value;
            _polarization = polarization;

        }

        /// <summary>
        /// + measure(polarization): int
        /// Returns the stored value if polarizations match.
        /// Otherwise “collapses” the qubit into the new polarization,
        /// picks a random 0 or 1 (50/50) for the new value, and returns it.
        /// </summary>
        public int Measure(int polarization)
        {
            ValidateBasis(polarization);

            if (polarization == _polarization)
                return _value;

            // collapse into the new basis
            _polarization = polarization; 
            _value = _rng.Next(0, 2);
            return _value;
        
        }

        private static void ValidateBit(int bit)
        {
            if (bit != 0 && bit != 1)
                throw new ArgumentOutOfRangeException(nameof(bit), "Value must be 0 or 1.");
        }

        private static void ValidateBasis(int basis)
        {
            if (basis != 0 && basis != 1)
                throw new ArgumentOutOfRangeException(nameof(basis),
                    "Polarization must be 0 (circular) or 1 (linear).");
        }

        public override string ToString()
        {
            return $"Qubit(Value={_value}, Basis={_polarization})";
        }

    }
}
