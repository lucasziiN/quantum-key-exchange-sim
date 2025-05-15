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

        // Shared random generator used when collapsing the qubit
        private static readonly Random _rng = new Random();

        /// <summary>
        /// Constructor for Qubit. Takes a value and a polarization.
        /// </summary>
        public Qubit(int value, int polarization)
        {
            Set(value, polarization);
        }

        /// <summary>
        /// Sets the value and polarization of the qubit.
        /// </summary>
        public void Set(int value, int polarization)
        {

            ValidateBit(value);
            ValidateBasis(polarization);
            _value = value;
            _polarization = polarization;

        }

        /// <summary>
        /// Measures the qubit with a given polarization.
        /// If the polarization matches, returns the current value.
        /// If not, collapses the qubit into the new polarization and randomizes the value.
        /// </summary>
        public int Measure(int polarization)
        {
            ValidateBasis(polarization);

            if (polarization == _polarization)
                return _value;

            // Collapse into new basis and generate a new random value (0 or 1)
            _polarization = polarization; 
            _value = _rng.Next(0, 2);
            return _value;
        
        }

        // Checks if the bit is valid (must be 0 or 1)
        private static void ValidateBit(int bit)
        {
            if (bit != 0 && bit != 1)
                throw new ArgumentOutOfRangeException(nameof(bit), "Value must be 0 or 1.");
        }

        // Checks if the polarization is valid (must be 0 or 1)
        private static void ValidateBasis(int basis)
        {
            if (basis != 0 && basis != 1)
                throw new ArgumentOutOfRangeException(nameof(basis),
                    "Polarization must be 0 (circular) or 1 (linear).");
        }

        // Outputs a string showing the current value and polarization
        public override string ToString()
        {
            return $"Qubit(Value={_value}, Basis={_polarization})";
        }

    }
}
