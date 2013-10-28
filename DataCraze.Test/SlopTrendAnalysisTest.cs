using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCraze.Test
{
    [TestClass]
    public class SlopTrendAnalysisTest
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullXdataTest()
        {
            var trend = new SlopeTrendAnalysis(new TrendReturnFactory(0d));
            trend.GenerateTrend(null, new List<double?> { 1, 2, 3 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullYdataTest()
        {
            var trend = new SlopeTrendAnalysis(new TrendReturnFactory(0d));
            trend.GenerateTrend(new List<double?> { 1, 2, 3 }, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void XYListSizeMisMatchTest()
        {
            var trend = new SlopeTrendAnalysis(new TrendReturnFactory(0d));
            trend.GenerateTrend(new List<double?> { 1, 2, 3 }, new List<double?> { 1, 2 });
        }

        [TestMethod]
        public void ConstructorTest()
        {
            var factory = new TrendReturnFactory();
            var actual = new SlopeTrendAnalysis(factory);
            Assert.AreSame(factory, actual.Factory);
        }

        [TestMethod]
        public void GenerateTest()
        {
            var trend = new SlopeTrendAnalysis(new TrendReturnFactory(0));
            var expectedImpact = -0.0571d;
            var actual = trend.GenerateTrend(new List<double?>() { 87, 88, 90, 86 }, new List<double?> { 1, 2, 3, 4 });
            Assert.AreEqual(expectedImpact, actual.Impact.Value,.0001d);
            Assert.AreEqual(TrendType.Down, actual.Trend);
        }
    }
}
