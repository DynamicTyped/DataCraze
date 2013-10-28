using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DataCraze.Test
{
    [TestClass]
    public class PreviousPeriodTrendAnalysisTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullXdataTest()
        {
            var trend = new PreviousPeriodTrendAnalysis(new TrendReturnFactory(0d));
            trend.GenerateTrend(null, new List<double?> { 1, 2, 3 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullYdataTest()
        {
            var trend = new PreviousPeriodTrendAnalysis(new TrendReturnFactory(0d));
            trend.GenerateTrend(new List<double?> { 1, 2, 3 }, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void XYListSizeMisMatchTest()
        {
            var trend = new PreviousPeriodTrendAnalysis(new TrendReturnFactory(0d));
            trend.GenerateTrend(new List<double?> { 1, 2, 3 }, new List<double?> { 1, 2 });
        }

        [TestMethod]
        public void OnePeriodTest()
        {
            var trend = new PreviousPeriodTrendAnalysis(new TrendReturnFactory(0d));
            double impact = 0d;
            TrendType trendType = TrendType.NoChange;
            var actual = trend.GenerateTrend(new List<double?> { 1,}, new List<double?> { 1});
            Assert.AreEqual(impact, actual.Impact);
            Assert.AreEqual(trendType, actual.Trend);
        }

        [TestMethod]
        public void GenerateTest()
        {
            var trend = new PreviousPeriodTrendAnalysis(new TrendReturnFactory());
            var expectedImpact = 10;
            var actual = trend.GenerateTrend(new List<double?>() { 4, 14 }, new List<double?> { 1, 2 });
            Assert.AreEqual(expectedImpact, actual.Impact);
        }
    }
}
