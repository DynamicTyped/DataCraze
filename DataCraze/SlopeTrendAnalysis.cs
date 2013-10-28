using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCraze
{
    /// <summary>
    /// Generates the trend direction based on the same logic as Excel's slope function
    /// </summary>
    public class SlopeTrendAnalysis : ITrendAnalysis
    {
        private ITrendReturnFactory _factory;
        internal ITrendReturnFactory Factory { get { return _factory; } }
        /// <summary>
        /// Generates the trend direction based on the same logic as Excel's slope function
        /// </summary>
        /// <param name="xData">Values found on the x-axis.</param>
        /// <param name="yData">Values found on the y-axis.</param>
        /// <returns>Trend</returns>
        public ITrendReturn GenerateTrend(IEnumerable<double?> xData, IEnumerable<double?> yData)
        {
            if (null == xData)
                throw new ArgumentNullException("xData");
            if (null == yData)
                throw new ArgumentNullException("yData");
            if (xData.Count() != yData.Count())
                throw new ArgumentException("xData and yData must contain the same number of elements");

            var count = xData.Count();

            var xSquared = xData.Select(a => a * a);
            var xy = xData.Select((a, i) => a * yData.Skip(i).First());
            var xDataSum = xData.Sum();

            var slope = (count * xy.Sum() - xDataSum * yData.Sum()) 
                            / 
                        (count * xSquared.Sum() - xDataSum * xDataSum);
            
            return _factory.Create(slope);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public SlopeTrendAnalysis(ITrendReturnFactory factory)
        {
            _factory = factory;
        }

    }
}
