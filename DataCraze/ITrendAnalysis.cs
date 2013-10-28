using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCraze
{
    public interface ITrendAnalysis
    {
        /// <summary>
        /// Generates a trend direction of the data
        /// </summary>
        /// <param name="xData">Values found on the x-axis</param>
        /// <param name="yData">Values found on the y-axis</param>
        /// <returns>Trend result</returns>
        ITrendReturn GenerateTrend(IEnumerable<double?> xData, IEnumerable<double?> yData);        
        
    }
}
