using DataCraze.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCraze
{
    /// <summary>
    /// Mechanism for deciding what way the trend is going based on the value and buffer.
    /// Buffer is read from the configure file
    /// </summary>
    public class TrendReturnFactory : ITrendReturnFactory
    {
        private double _buffer;

        public ITrendReturn Create(double? value)
        {
            TrendType trend = TrendType.NoChange;
            if (value > _buffer)
                trend = TrendType.Up;
            if (value < 0 - _buffer)
                trend = TrendType.Down;
            if (value == null)
                trend = TrendType.NoChange;

            return new TrendReturn() { Buffer = _buffer, Impact = value, Trend = trend };
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public TrendReturnFactory()
        {
            // read from config for buffer;
            var buffer = TrendReturnSection.GetSection().Buffer;

            if (buffer < 0d)
                throw new ArgumentOutOfRangeException("Buffer must be 0 or greater");

            _buffer = buffer;
        }

        /// <summary>
        /// Internal constructor for testing
        /// </summary>
        /// <param name="buffer"></param>
        internal TrendReturnFactory(double buffer)
        {
            _buffer = buffer;
        }
    }
}
