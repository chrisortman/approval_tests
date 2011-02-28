using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ____ = System.String;
namespace TestProject1
{
    [TestClass]
    public class Lesson1Numbers
    {
        /*
         * How to Run: Press Ctrl+R,T (go ahead, try it now)
         * Step 1: find the 1st method that fails
         * Step 2: Fill in the blank ____ to make it pass
         * Step 3: run it again
         * Note: Do not change anything other than the blank
         */
        [TestMethod]
        public void NumbersDontNeedQuotes()
        {
            Assert.AreEqual(___, 42);
            
        }
        [TestMethod]
        public void NumbersCanHaveDecimals()
        {
            Assert.AreEqual(___, 4.2);
        }

        [TestMethod]
        public void IntegerTypes()
        {
            Assert.AreEqual(typeof(int), ___.GetType());
        }
        [TestMethod]
        public void DoubleTypes()
        {
            Assert.AreEqual(typeof(double), ___.GetType());
        }
        [TestMethod]
        public void WhichTypeIs8()
        {
            Assert.IsInstanceOfType(8, (typeof(____)));
        }
        [TestMethod]
        public void IsThisTheSameType()
        {
            Assert.IsInstanceOfType(8.0, (typeof(____)));
        }
        [TestMethod]
        public void IntegerHaveLimits()
        {
            Assert.AreEqual(___, int.MaxValue);
        }
        [TestMethod]
        public void LongHaveBiggerLimits()
        {
            Assert.AreEqual(___, long.MaxValue);
        }
        [TestMethod]
        public void NegativeNumbers()
        {
            
            Assert.AreEqual(___, -9);
        }
        [TestMethod]
        public void NumbersAdd()
        {

            Assert.AreEqual(___, 2 + 3);
        }
        [TestMethod]
        public void NumbersSubtract()
        {

            Assert.AreEqual(___,  10 - 3);
        }
        [TestMethod]
        public void NumbersMultiply()
        {

            Assert.AreEqual(___, 5*5);
        }
        [TestMethod]
        public void NumbersDivide()
        {

            Assert.AreEqual(___, 10/2);
        }
        [TestMethod]
        public void DoublesDivideNormally()
        {

            Assert.AreEqual(___, 10.0 / 4);
        }
        [TestMethod]
        public void IntegersRoundDownWhenDivided()
        {

            Assert.AreEqual(___, 10 / 4);
        }
        [TestMethod]
        public void ButYouCanAlsoGetTheRemainer ()
        {

            Assert.AreEqual(___, 7 % 4);
        }
        [TestMethod]
        public void RemainerIsNotModulus()
        {

            Assert.AreEqual(___, -6 % 4);
        }
        #region Ignore
        public object ___ = "Please Fill in the blank";
        #endregion
    }
}
