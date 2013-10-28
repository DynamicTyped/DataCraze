using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCraze
{
    public interface ITrendReturn
    {
        double Buffer { get; }        
        double? Impact { get; }
        TrendType Trend { get; }
    }
}
