using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCraze
{
    /// <summary>
    /// Compares the last two items in the set to derive the trend
    /// </summary>
    public class PreviousPeriodTrendAnalysis : ITrendAnalysis 
    {
        private ITrendReturnFactory _factory;

        /// <summary>
        /// Generate the trend for the last two periods
        /// </summary>
        /// <param name="xData">Values found on the x-axis. Assumes the data is ordered as oldest in the first element to newest in the last.</param>
        /// <param name="yData">Values found on the y-axis. Assumes the data is ordered as oldest in the first element to newest in the last.</param>
        /// <returns></returns>
        public ITrendReturn GenerateTrend(IEnumerable<double?> xData, IEnumerable<double?> yData)
        {
            if (null == xData)
                throw new ArgumentNullException("xData");           
            var xDataCount = xData.Count();

            if (xDataCount != yData.Count())
                throw new ArgumentException("xData and yData must contain the same number of elements");

            // one or no elements give it no change
            if (xDataCount < 2)
            {
                return _factory.Create(0);
            }

            return _factory.Create(xData.Last() - xData.Reverse().Skip(1).First());
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public PreviousPeriodTrendAnalysis(ITrendReturnFactory factory)
        {
            _factory = factory;
        }
    }
}
