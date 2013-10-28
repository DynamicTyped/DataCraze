using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCraze
{
    public interface ITrendReturnFactory
    {
        /// <summary>
        /// Creates the trend return based on a value
        /// </summary>
        /// <param name="value">Value to compare</param>
        /// <returns></returns>
        ITrendReturn Create(double? value);
    }
}
