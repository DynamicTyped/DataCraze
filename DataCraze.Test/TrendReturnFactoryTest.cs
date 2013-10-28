using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataCraze.Test
{
    [TestClass]
    public class TrendReturnFactoryTest
    {
        [TestMethod]
        public void TrendUpTest()
        {
            const double buffer = 0d;
            var factory = new TrendReturnFactory(buffer);
            var expected = TrendType.Up;
            const double value = 7d;
            var actual = factory.Create(value);
            Assert.AreEqual(expected, actual.Trend);
            Assert.AreEqual(buffer, actual.Buffer);
            Assert.AreEqual(value, actual.Impact);
        }

        [TestMethod]
        public void TrendDownTest()
        {
            const double buffer = 0d;
            var factory = new TrendReturnFactory(buffer);
            var expected = TrendType.Down;
            const double value = -7d;
            var actual = factory.Create(value);
            Assert.AreEqual(expected, actual.Trend);
            Assert.AreEqual(buffer, actual.Buffer);
            Assert.AreEqual(value, actual.Impact);
        }

        [TestMethod]
        public void TrendNoChangeTest()
        {
            const double buffer = 0d;
            var factory = new TrendReturnFactory(buffer);
            var expected = TrendType.NoChange;
            const double value = 0d;
            var actual = factory.Create(value);
            Assert.AreEqual(expected, actual.Trend);
            Assert.AreEqual(buffer, actual.Buffer);
            Assert.AreEqual(value, actual.Impact);
        }

        [TestMethod]
        public void TrendNoChangeWithinBufferPositiveValueTest()
        {
            const double buffer = 1d;
            var factory = new TrendReturnFactory(buffer);
            var expected = TrendType.NoChange;
            const double value = .5d;
            var actual = factory.Create(value);
            Assert.AreEqual(expected, actual.Trend);
            Assert.AreEqual(buffer, actual.Buffer);
            Assert.AreEqual(value, actual.Impact);
        }

        [TestMethod]
        public void TrendNoChangeWithinBufferPositiveNegativeTest()
        {
            const double buffer = 1d;
            var factory = new TrendReturnFactory(buffer);
            var expected = TrendType.NoChange;
            const double value = -.5d;
            var actual = factory.Create(value);
            Assert.AreEqual(expected, actual.Trend);
            Assert.AreEqual(buffer, actual.Buffer);
            Assert.AreEqual(value, actual.Impact);
        }

        [TestMethod]
        public void TrendNoChangeNulLValueTest()
        {
            const double buffer = 0d;
            var factory = new TrendReturnFactory(buffer);
            var expected = TrendType.NoChange;
            double? value = null;
            var actual = factory.Create(value);
            Assert.AreEqual(expected, actual.Trend);
            Assert.AreEqual(buffer, actual.Buffer);
            Assert.AreEqual(value, actual.Impact);
        }
    }
}
