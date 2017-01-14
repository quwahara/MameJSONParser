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
        public void Number0()
        {
            Assert.AreEqual(0, MameJSONParser.Parse("0"));
        }
        [TestMethod]
        public void Number1()
        {
            Assert.AreEqual(1, MameJSONParser.Parse("1"));
        }
        [TestMethod]
        public void Number19()
        {
            Assert.AreEqual(19, MameJSONParser.Parse("19"));
        }
        [TestMethod]
        public void Number195()
        {
            Assert.AreEqual(195, MameJSONParser.Parse("195"));
        }
        [TestMethod]
        public void NumberNeg()
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
        public void NumberNeg1()
        {
            Assert.AreEqual(-1, MameJSONParser.Parse("-1"));
        }
        [TestMethod]
        public void Number0Dot()
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
        public void Number0Dot1()
        {
            Assert.AreEqual(0.1, MameJSONParser.Parse("0.1"));
        }
        [TestMethod]
        public void Number1e()
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
        public void Number1E()
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
        public void Number1e1()
        {
            Assert.AreEqual(1e1, MameJSONParser.Parse("1e1"));
        }
        [TestMethod]
        public void Number1E1()
        {
            Assert.AreEqual(1E1, MameJSONParser.Parse("1E1"));
        }
        public void Number1e12()
        {
            Assert.AreEqual(1e12, MameJSONParser.Parse("1e12"));
        }
        [TestMethod]
        public void Number1ePos()
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
        public void Number1eNeg()
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
        public void Number1ePos1()
        {
            Assert.AreEqual(1e+1, MameJSONParser.Parse("1e+1"));
        }
        [TestMethod]
        public void Number1ePos12()
        {
            Assert.AreEqual(1e+12, MameJSONParser.Parse("1e+12"));
        }
    }
}
