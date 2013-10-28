using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DataCraze.Configuration
{
    public class TrendReturnSection : ConfigurationSection
    {
        public const string SectionName = "TrendReturn";

        public static TrendReturnSection GetSection()
        {
            return (TrendReturnSection)ConfigurationManager.GetSection(SectionName);
        }

        private const string _bufferNameProperty = "buffer";
        [ConfigurationProperty(_bufferNameProperty, IsRequired=false, DefaultValue=0d)]
        public double Buffer
        {
            get { return (double)this[_bufferNameProperty];}
            set { this[_bufferNameProperty] = value; }
        }
    }
}
