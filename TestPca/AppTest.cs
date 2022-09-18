using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Classwork;


namespace TestProject
{
    [TestClass]
    public class AppTest
    {
        [TestMethod]
        public void CalcTest()
        {
            // Спроба створити об'єкт головного класу
            Classwork.Calc calc = new();
            // Твердження - маємо одержати не-null результат
            Assert.IsNotNull(calc);
        }

        [TestMethod]
        public void RomanNumberParse1Digit()
        {
            Assert.AreEqual(1, Rumnumber.Parse("I"));
            Assert.AreEqual(5, Rumnumber.Parse("V"));
            Assert.AreEqual(10, Rumnumber.Parse("X"));
            Assert.AreEqual(50, Rumnumber.Parse("L"));
            Assert.AreEqual(100, Rumnumber.Parse("C"));
            Assert.AreEqual(500, Rumnumber.Parse("D"));
            Assert.AreEqual(1000, Rumnumber.Parse("M"));
        }

        [TestMethod]
        public void RomanNumberParse2Digits()
        {
            Assert.AreEqual(4, Rumnumber.Parse("IV"));
            Assert.AreEqual(15, Rumnumber.Parse("XV"));
            Assert.AreEqual(900, Rumnumber.Parse("CM"));
            Assert.AreEqual(400, Rumnumber.Parse("CD"));
            Assert.AreEqual(55, Rumnumber.Parse("LV"));
            Assert.AreEqual(40, Rumnumber.Parse("XL"));
        }

        [TestMethod]
        public void RomanNumberParse3MoreDigits()
        {
            Assert.AreEqual(30, Rumnumber.Parse("XXX"));
           // Assert.AreEqual(401, Rumnumber.Parse("CDI"));
            Assert.AreEqual(1999, Rumnumber.Parse("MCMXCIX"));
        }
        [TestMethod]
        public void RomanNumberParseInvalidDigit()

        {
            var exc = Assert.ThrowsException<ArgumentException>(() => { Rumnumber.Parse("XXA"); });
            Assert.ThrowsException<Exception>(() => { Rumnumber.Parse("CDI"); });
            var exp = new ArgumentException("Invalid char A");



            Assert.AreEqual(exp, exc);


            exc = Assert.ThrowsException<ArgumentException>(() => { Rumnumber.Parse("X11"); });
            exp = new ArgumentException("Invalid char 11");

            Assert.AreEqual(exp.Message, exc.Message);
            exc = Assert.ThrowsException<ArgumentException>(() => { Rumnumber.Parse("1"); });
            exp = new ArgumentException("Invalid char 1");
            Assert.AreEqual(exp.Message, exc.Message);

            exc = Assert.ThrowsException<ArgumentException>(() => { Rumnumber.Parse("X X"); });

            exp = new ArgumentException("Invalid char X X");
            Assert.AreEqual(exc.Message.StartsWith(exp.Message), true);



        }
        [TestMethod]
        public void RomanNumberParseEmpty()
        { Rumnumber.Parse("");


            Rumnumber.Parse(null!);
            var exp = new ArgumentException("Empty string is not allowed");
            var exc = Assert.ThrowsException<Exception>(() => Rumnumber.Parse(""), exp.Message);
            exc = Assert.ThrowsException<Exception>(() => Rumnumber.Parse(null!), exp.Message);


        }

        //- Додати тест для числа "N" - 0
        [TestMethod]
        public void RomNumberNTest()
        {
            Assert.AreEqual(0, Rumnumber.Parse("N"));
        }
        [TestMethod]
        public void RomanNumberCtor()
        {
            Rumnumber rum = new();
            rum = new(10);
            rum = new(0);
        }
        [TestMethod]
        public void RomanNumberToString()
        {
            Rumnumber romanNumber = new();
            Assert.AreEqual("N", romanNumber.ToString());



            romanNumber = new(10);
            Assert.AreEqual("X", romanNumber.ToString());



            romanNumber = new(90);
            Assert.AreEqual("XC", romanNumber.ToString());



            romanNumber = new(20);
            Assert.AreEqual("XX", romanNumber.ToString());



            romanNumber = new(1999);
            Assert.AreEqual("MCMXCIX", romanNumber.ToString());
        }
        [TestMethod]
        public void RomanNumberTostringParse()
        {
            Rumnumber num = new();
            for (int n = 0; n <= 100; n++)
            {
                num.a = n;
                Assert.AreEqual(n, Rumnumber.Parse(num.ToString()));
            }
        }
        [TestMethod]
        public void RomanNumbTypeTest()
        {


            Rumnumber rm1 = new(10);
            Rumnumber rm2 = rm1;
            Assert.AreSame(rm1, rm2);
            Rumnumber rm3 = rm1 with { };
            Assert.AreNotSame(rm3, rm1);
            Assert.AreEqual(rm3, rm1);
            Assert.IsTrue(rm3 == rm1);

            Rumnumber rm4 = rm1 with { a = 10 };

            Assert.AreNotSame(rm4, rm1);
            Assert.IsFalse(rm4 == rm1);
            Assert.AreNotEqual(rm4, rm1);
            Assert.IsFalse(rm1.Equals(rm4));
        }
        [TestMethod]
        public void rumanNegative()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => { Rumnumber.Parse("XXA"); });

            var expect = new ArgumentException("Invalid char A");

            Assert.AreEqual(expect.Message, exception.Message);

            exception = Assert.ThrowsException<ArgumentException>(() => { Rumnumber.Parse("MCMBCIX"); });
            expect = new ArgumentException("Invalid char B");
            Assert.AreEqual(expect.Message, exception.Message);

            exception = Assert.ThrowsException<ArgumentException>(() => { Rumnumber.Parse("WIII"); });
            expect = new ArgumentException("Invalid char W");
            Assert.AreEqual(expect.Message, exception.Message);

            exception = Assert.ThrowsException<ArgumentException>(() => { Rumnumber.Parse("DCCS"); });
            expect = new ArgumentException("Invalid char S");
            Assert.AreEqual(expect.Message, exception.Message);


            exception = Assert.ThrowsException<ArgumentException>(() => { Rumnumber.Parse("X X"); });
            Assert.AreEqual(exception.Message.StartsWith("Invalid char"), true);
        }

        [TestMethod]
        public void  AddvaluesTest()
        {
           // Rumnumber a = new() { a = 10 };



            Rumnumber romanNumber = new Rumnumber(10);
           Assert.AreEqual(20, romanNumber.Add(10).a);
           Assert.AreEqual("V", romanNumber.Add(-5).ToString());
           Assert.AreEqual(romanNumber, romanNumber.Add(0));

        }
        [TestMethod]
        public void AddstringTest()
        {
           

            Assert.AreEqual(-10, Rumnumber.Parse("-X"));
            Assert.AreEqual(-400, Rumnumber.Parse("-CD"));
            Assert.AreEqual(-1900, Rumnumber.Parse("-MCM"));

            Rumnumber rn = new() { a = -10 };
            Assert.AreEqual("-X", rn.ToString());
            rn.a = -90;
            Assert.AreEqual("-XC", rn.ToString());

            Assert.ThrowsException<ArgumentException>(() => Rumnumber.Parse("M-CM"));
            Assert.ThrowsException<ArgumentException>(() => Rumnumber.Parse("M-"));
            Assert.ThrowsException<ArgumentException>(() => Rumnumber.Parse("-"));
            Assert.ThrowsException<ArgumentException>(() => Rumnumber.Parse("-N"));
            Assert.ThrowsException<ArgumentException>(() => Rumnumber.Parse("--X"));
            Assert.ThrowsException<ArgumentException>(() => Rumnumber.Parse("-C-X"));
            Assert.ThrowsException<ArgumentException>(() => Rumnumber.Parse("--"));



        }
        [TestMethod]
        public void AddStaticTest()
        {
            Rumnumber rn5 = Rumnumber.Add(2, 3);
            Rumnumber rn8 = Rumnumber.Add(rn5, 3);
            Rumnumber rn10 = Rumnumber.Add("I", "IX");
            Rumnumber rn9 = Rumnumber.Add(rn5, "IV");
            Rumnumber rn13 = Rumnumber.Add(rn5, rn8);
  
            Assert.AreEqual(5, rn5.a);
            Assert.AreEqual(8, rn8.a);
            Assert.AreEqual(9, rn9.a);
            Assert.AreEqual(10, rn10.a);
            Assert.AreEqual(13, rn13.a);
        }
        [TestMethod]
        public void SubstractionTest()
        {
            Rumnumber rn10 = new(10);
            Rumnumber rn3 = new(3);
            Rumnumber rn15 = new(15);
            Rumnumber rn_7 = new(-7);
            Rumnumber rn_9 = new(-9);

            Assert.AreEqual(-7, rn3.Sub(rn10).a);
            Assert.AreEqual(5, rn15.Sub(rn10).a);
            Assert.AreEqual(22, rn15.Sub(rn_7).a);
            Assert.AreEqual(2, rn_7.Sub(rn_9).a);
            Assert.AreEqual(7, rn10.Sub(rn3).a);
        }
        [TestMethod]
        public void RomanNumberPraseInvalid()
        {
            var exc = Assert.ThrowsException<ArgumentException>(()=> { Rumnumber.Parse("XXA"); });
            var exp = new ArgumentException(Resorces.GetInvalidc('a'));
        
        }

    }


    [TestClass]
    public class OperationTest
    {
    }
 }

/* TDD - Test Driven Development - розроблення кероване тестами
* Суть - спочатку пишуться тести, потім створюється ПЗ, яке
* задовольняє цим тестам. XP додає - мінімальним шляхом (без
*  "запасів")
*
*/