using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StringCalculatorTry11
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void Construct_ShouldNotThrow()
        {
            //---------------Arrange----------------------
            //----------------Act-------------------------
            //---------------Assert-----------------------
            Assert.DoesNotThrow(()=>CreateStringCalculator());
        }

        [Test]
        public void Add_GivenInputOfNull_ShouldReturn0()
        {
            //---------------Arrange----------------------
            var stringCalculator = CreateStringCalculator();
            //----------------Act-------------------------
            var actual = stringCalculator.Add("");
            var expected = 0;
            //---------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenInputOf1_ShouldReturnInput()
        {
            //---------------Arrange----------------------
            var stringCalculator = CreateStringCalculator();
            //----------------Act-------------------------
            var actual = stringCalculator.Add("");
            var expected = 0;
            //---------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenInputWithDelimeterAnd2Numbers_ShouldAdd()
        {
            //---------------Arrange----------------------
            var stringCalculator = CreateStringCalculator();
            //----------------Act-------------------------
            var actual = stringCalculator.Add("1,2");
            var expected = 3;
            //---------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenInputWithDelimeterAnd3Numbers_ShouldAdd()
        {
            //---------------Arrange----------------------
            var stringCalculator = CreateStringCalculator();
            //----------------Act-------------------------
            var actual = stringCalculator.Add("1,2,3");
            var expected = 6;
            //---------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenInputWithNewLineSeperatorDelimeter_ShouldAdd()
        {
            //---------------Arrange----------------------
            var stringCalculator = CreateStringCalculator();
            //----------------Act-------------------------
            var actual = stringCalculator.Add("1,2,3\n2");
            var expected = 8;
            //---------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenInputWithCustomSeperatorDelimeter_ShouldAdd()
        {
            //---------------Arrange----------------------
            var stringCalculator = CreateStringCalculator();
            //----------------Act-------------------------
            var actual = stringCalculator.Add("//;\n1;2;3;2");
            var expected = 8;
            //---------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenInputWithNegativeNumber_ShouldThrow()
        {
            //---------------Arrange----------------------
            var stringCalculator = CreateStringCalculator();
            //----------------Act-------------------------
            //---------------Assert-----------------------
            var ex = Assert.Throws<ApplicationException>(() => stringCalculator.Add("-1,2"));
            Assert.AreEqual("negatives not allowed: -1", ex.Message);
        }

        [Test]
        public void Add_GivenInputWithNumberGreaterThan1000_ShouldIgnoreNumberAndAdd()
        {
            //---------------Arrange----------------------
            var stringCalculator = CreateStringCalculator();
            //----------------Act-------------------------
            var actual = stringCalculator.Add("1,2,1001");
            var expected = 3;
            //---------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenInputWithCustomDelimeter_ShouldAdd()
        {
            //---------------Arrange----------------------
            var stringCalculator = CreateStringCalculator();
            //----------------Act-------------------------
            var actual = stringCalculator.Add("//[***]\n1***2");
            var expected = 3;
            //---------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenInputWithMultipleCustomDelimeters_ShouldAdd()
        {
            //---------------Arrange----------------------
            var stringCalculator = CreateStringCalculator();
            //----------------Act-------------------------
            var actual = stringCalculator.Add("//[***][^]\n1***2^2");
            var expected = 5;
            //---------------Assert-----------------------
            Assert.AreEqual(expected, actual);
        }

        private static StringCalculator CreateStringCalculator()
        {
            var stringCalculator = new StringCalculator();
            return stringCalculator;
        }

    }
}
