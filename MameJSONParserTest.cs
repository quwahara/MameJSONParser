using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MameJSONParser.UnitTest
{
    [TestClass]
    public class MameJSONParserTest
    {
        [TestMethod]
        public void Digit0()
        {
            Assert.AreEqual(0, MameJSONParser.Parse("0"));
        }
        [TestMethod]
        public void Digit1()
        {
            Assert.AreEqual(1, MameJSONParser.Parse("1"));
        }
        [TestMethod]
        public void Digit19()
        {
            Assert.AreEqual(19, MameJSONParser.Parse("19"));
        }
        [TestMethod]
        public void Digit195()
        {
            Assert.AreEqual(195, MameJSONParser.Parse("195"));
        }
        [TestMethod]
        public void DigitNeg()
        {
            try
            {
                MameJSONParser.Parse("-");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void DigitNeg1()
        {
            Assert.AreEqual(-1, MameJSONParser.Parse("-1"));
        }
        [TestMethod]
        public void Digit0Dot()
        {
            try
            {
                MameJSONParser.Parse("0.");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void Digit0Dot1()
        {
            Assert.AreEqual(0.1, MameJSONParser.Parse("0.1"));
        }
        [TestMethod]
        public void Digit1e()
        {
            try
            {
                MameJSONParser.Parse("1e");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void Digit1E()
        {
            try
            {
                MameJSONParser.Parse("1E");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void Digit1e1()
        {
            Assert.AreEqual(1e1, MameJSONParser.Parse("1e1"));
        }
        [TestMethod]
        public void Digit1E1()
        {
            Assert.AreEqual(1E1, MameJSONParser.Parse("1E1"));
        }
        public void Digit1e12()
        {
            Assert.AreEqual(1e12, MameJSONParser.Parse("1e12"));
        }
        [TestMethod]
        public void Digit1ePos()
        {
            try
            {
                MameJSONParser.Parse("1e+");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void Digit1eNeg()
        {
            try
            {
                MameJSONParser.Parse("1e-");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void Digit1ePos1()
        {
            Assert.AreEqual(1e+1, MameJSONParser.Parse("1e+1"));
        }
        [TestMethod]
        public void Digit1ePos12()
        {
            Assert.AreEqual(1e+12, MameJSONParser.Parse("1e+12"));
        }
    }
}
