using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataCraze.Configuration;
using System.Configuration;

namespace DataCraze.Test
{
    [TestClass]
    public class TrendReturnSectionTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            object target = new TrendReturnSection();
            Assert.IsInstanceOfType(target, typeof(TrendReturnSection));
        }

        [TestMethod]
        public void get_section()
        {
            var actual = TrendReturnSection.GetSection();
            Assert.IsInstanceOfType(actual, typeof(TrendReturnSection));
        }

        [TestMethod]
        public void BufferTest()
        {
            var target = TrendReturnSection.GetSection();
            const double expected = .2d;
            var actual = target.Buffer;
            Assert.AreEqual(expected, actual);
        }
    }
}
