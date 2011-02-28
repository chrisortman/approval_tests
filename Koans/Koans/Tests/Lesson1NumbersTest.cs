using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class Lesson1NumbersTest
    {
        [TestMethod]
        public void TestTypeOfQuestions()
        {
            AssertTypeOf<Lesson1Numbers>(l => l.WhichTypeIs8(), typeof(int));
            AssertTypeOf<Lesson1Numbers>(l => l.IsThisTheSameType(), typeof(double));
           
        }

        private void AssertTypeOf<T>(Action<T> test, Type expected) where T : new()
        {
            var lesson = new T();
            string s = "Didn't Fail";
            try
            {
               test(lesson);

            }
            catch (Exception e)
            {
                s = e.Message;
            }
            var expectedMessage =
                String.Format(
                    "Assert.IsInstanceOfType failed.  Expected type:<System.String>. Actual type:<{0}>.",
                    expected);
            Assert.AreEqual(s,expectedMessage);


        }
        

        [TestMethod]
        public void TestAllQuestions()
        {
            Verify(l => l.NumbersDontNeedQuotes(),  42);
            Verify(l => l.NumbersCanHaveDecimals(), 4.2);
            Verify(l => l.IntegerTypes(), 42);
            Verify(l => l.DoubleTypes(), 4.2);
            Verify(l => l.IntegerHaveLimits(), 2147483647);
            Verify(l => l.NegativeNumbers(), -9);
            Verify(l => l.NumbersAdd(), 5);
            Verify(l => l.NumbersSubtract(), 7);
            Verify(l => l.NumbersMultiply(), 25);
            Verify(l => l.NumbersDivide(), 5);
            Verify(l => l.DoublesDivideNormally(), 2.5);
            Verify(l => l.IntegersRoundDownWhenDivided(), 2);
            Verify(l => l.ButYouCanAlsoGetTheRemainer(), 3);
            Verify(l => l.RemainerIsNotModulus(), -2);
        }


        public void Verify(Action<Lesson1Numbers> test, object answer)
        {
            AssertLesson(test, l => l.___ = answer);
        }

        public void AssertLesson<T>(Action<T> test, Action<T> answer) where T : new()
        {
            var l =  new T();
            var failed = false;
            try
            {
                test(l);
            }
            catch (Exception)
            {
                failed = true;
            }
            Assert.IsTrue(failed);
            answer(l);
            test(l);

        }

    }
}
