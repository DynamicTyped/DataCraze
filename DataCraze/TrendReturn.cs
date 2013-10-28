using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCraze
{
    public class TrendReturn : ITrendReturn
    {
        public double Buffer { get; internal set; }        
        public double? Impact { get; internal set; }
        public TrendType Trend { get; internal set;}
    }
}
