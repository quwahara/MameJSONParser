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
        public void ArgumentNull()
        {
            try
            {
                MameJSONParser.Parse(null);
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void ArgumentEmptyString1()
        {
            try
            {
                MameJSONParser.Parse("");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void ArgumentEmptyString2()
        {
            try
            {
                MameJSONParser.Parse("\n\r\t ");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void ArgumentTooMuch()
        {
            try
            {
                MameJSONParser.Parse("null t");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void T()
        {
            try
            {
                MameJSONParser.Parse("t");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void True()
        {
            Assert.AreEqual(true, MameJSONParser.Parse("true"));
        }
        [TestMethod]
        public void F()
        {
            try
            {
                MameJSONParser.Parse("f");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void False()
        {
            Assert.AreEqual(false, MameJSONParser.Parse("false"));
        }
        [TestMethod]
        public void N()
        {
            try
            {
                MameJSONParser.Parse("n");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void Null()
        {
            Assert.AreEqual(null, MameJSONParser.Parse("null"));
        }
        [TestMethod]
        public void StrControl()
        {
            try
            {
                MameJSONParser.Parse("\"\t\"");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void StrDQ()
        {
            try
            {
                MameJSONParser.Parse("\"");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void StrDQDQ()
        {
            Assert.AreEqual("", MameJSONParser.Parse("\"\""));
        }
        [TestMethod]
        public void StrESC()
        {
            try
            {
                MameJSONParser.Parse("\"\\");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void StrESCDQ()
        {
            Assert.AreEqual("\"", MameJSONParser.Parse("\"\\\"\""));
        }
        [TestMethod]
        public void StrESCRS()
        {
            Assert.AreEqual("\\", MameJSONParser.Parse("\"\\\\\""));
        }
        [TestMethod]
        public void StrESCSL()
        {
            Assert.AreEqual("/", MameJSONParser.Parse("\"\\/\""));
        }
        [TestMethod]
        public void StrESCBS()
        {
            Assert.AreEqual("\b", MameJSONParser.Parse("\"\\b\""));
        }
        [TestMethod]
        public void StrESCFF()
        {
            Assert.AreEqual("\f", MameJSONParser.Parse("\"\\f\""));
        }
        [TestMethod]
        public void StrESCNL()
        {
            Assert.AreEqual("\n", MameJSONParser.Parse("\"\\n\""));
        }
        [TestMethod]
        public void StrESCCR()
        {
            Assert.AreEqual("\r", MameJSONParser.Parse("\"\\r\""));
        }
        [TestMethod]
        public void StrESCHT()
        {
            Assert.AreEqual("\t", MameJSONParser.Parse("\"\\t\""));
        }
        [TestMethod]
        public void StrESCUNC()
        {
            Assert.AreEqual("が", MameJSONParser.Parse("\"\\u304C\""));
        }
        [TestMethod]
        public void StrXESCHTY()
        {
            Assert.AreEqual("X\tY", MameJSONParser.Parse("\"X\\tY\""));
        }
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
        [TestMethod]
        public void ObjCB()
        {
            try
            {
                MameJSONParser.Parse("{");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void ObjCBCB()
        {
            var ret = MameJSONParser.Parse("{}");
            Assert.IsTrue(ret is Dictionary<string, object>);
            var dic = (Dictionary<string, object>)ret;
            Assert.AreEqual(0, dic.Count);
        }
        [TestMethod]
        public void ObjCBName()
        {
            try
            {
                MameJSONParser.Parse("{\"n\"");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void ObjCBNameColon()
        {
            try
            {
                MameJSONParser.Parse("{ \"n\" : ");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void ObjCBNameColonValue()
        {
            try
            {
                MameJSONParser.Parse("{ \"n\" : \"v\" ");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void ObjCBNameColonValueCB()
        {
            var ret = MameJSONParser.Parse("{ \"n\" : \"v\" } ");
            Assert.IsTrue(ret is Dictionary<string, object>);
            var dic = (Dictionary<string, object>)ret;
            Assert.AreEqual(1, dic.Count);
            Assert.AreEqual("v", dic["n"]);
        }
        [TestMethod]
        public void ObjCBNameColonValueComma()
        {
            try
            {
                MameJSONParser.Parse("{ \"n\" : \"v\" , ");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void ObjCBNameColonValueCommaName()
        {
            try
            {
                MameJSONParser.Parse("{ \"n1\" : \"v1\" , \"n2\" ");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void ObjCBNameColonValueCommaNameColon()
        {
            try
            {
                MameJSONParser.Parse("{ \"n1\" : \"v1\" , \"n2\" : ");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void ObjCBNameColonValueCommaNameColonValue()
        {
            try
            {
                MameJSONParser.Parse("{ \"n1\" : \"v1\" , \"n2\" : \"v2\" ");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void ObjCBNameColonValueCommaNameColonValueCB()
        {
            var ret = MameJSONParser.Parse("{ \"n1\" : \"v1\" , \"n2\" : \"v2\" } ");
            Assert.IsTrue(ret is Dictionary<string, object>);
            var dic = (Dictionary<string, object>)ret;
            Assert.AreEqual(2, dic.Count);
            Assert.AreEqual("v1", dic["n1"]);
            Assert.AreEqual("v2", dic["n2"]);
        }
        [TestMethod]
        public void ArrSB()
        {
            try
            {
                MameJSONParser.Parse("[");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void ArrSBSB()
        {
            var ret = MameJSONParser.Parse("[ ]");
            Assert.IsTrue(ret is List<object>);
            var ls = (List<object>)ret;
            Assert.AreEqual(0, ls.Count);
        }
        [TestMethod]
        public void ArrSB0SB()
        {
            var ret = MameJSONParser.Parse("[ 0 ]");
            Assert.IsTrue(ret is List<object>);
            var ls = (List<object>)ret;
            Assert.AreEqual(1, ls.Count);
            Assert.AreEqual(0, ls[0]);
        }
        [TestMethod]
        public void ArrSB0Comma()
        {
            try
            {
                MameJSONParser.Parse("[ 0 , ");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void ArrSB0CommaSB()
        {
            try
            {
                MameJSONParser.Parse("[ 0 , ] ");
                Assert.Fail();
            }
            catch (Exception)
            {
            }
        }
        [TestMethod]
        public void ArrSB0Comma1SB()
        {
            var ret = MameJSONParser.Parse("[ 0 , 1 ]");
            Assert.IsTrue(ret is List<object>);
            var ls = (List<object>)ret;
            Assert.AreEqual(2, ls.Count);
            Assert.AreEqual(0, ls[0]);
            Assert.AreEqual(1, ls[1]);
        }
        [TestMethod]
        public void Complex1()
        {
            var ret = MameJSONParser.Parse("[ [ 0 , 1 ] , { \"n1\" : [ 0 , 1 ] , \"n2\" : { \"n2_1\" : \"v2_1\" } } ]");
            Assert.IsTrue(ret is List<object>);
            var ls = (List<object>)ret;
            Assert.AreEqual(2, ls.Count);
            Assert.IsTrue(ls[0] is List<object>);
            var ls1 = (List<object>)ls[0];
            Assert.AreEqual(2, ls1.Count);
            Assert.AreEqual(0, ls1[0]);
            Assert.AreEqual(1, ls1[1]);
            Assert.IsTrue(ls[1] is Dictionary<string, object>);
            var dic2 = (Dictionary<string, object>)ls[1];
            Assert.AreEqual(2, dic2.Count);
            Assert.IsTrue(dic2["n1"] is List<object>);
            var ls2_1 = (List<object>)dic2["n1"];
            Assert.AreEqual(0, ls2_1[0]);
            Assert.AreEqual(1, ls2_1[1]);
            var dic2_2 = (Dictionary<string, object>)dic2["n2"];
            Assert.AreEqual(1, dic2_2.Count);
            Assert.AreEqual("v2_1", dic2_2["n2_1"]);
        }
    }
}
