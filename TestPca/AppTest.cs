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
            Assert.AreEqual(401, Rumnumber.Parse("CDI"));
            Assert.AreEqual(1999, Rumnumber.Parse("MCMXCIX"));
        }
       public void RomanNumberParseInvalidDigit()

        {
          var exc=  Assert.ThrowsException<ArgumentException>(() => { Rumnumber.Parse("XXA"); });
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
            Assert.AreEqual(exc.Message.StartsWith(exp.Message),true);



        }
        [TestMethod]
        public void RomanNumberParseEmpty()
        { Rumnumber.Parse("");


            Rumnumber.Parse(null!);
            var exp = new ArgumentException("Invalid char ");
            var exc = Assert.ThrowsException<Exception>(() => Rumnumber.Parse(""), exp.Message);
                exc = Assert.ThrowsException<Exception>(() => Rumnumber.Parse(null!),exp.Message);
           
           
        }

        //- Додати тест для числа "N" - 0
        [TestMethod]
        public void RomNumberNTest()
        {
            Assert.AreEqual(0, Rumnumber.Parse("N"));
        }

    }
}

/* TDD - Test Driven Development - розроблення кероване тестами
* Суть - спочатку пишуться тести, потім створюється ПЗ, яке
* задовольняє цим тестам. XP додає - мінімальним шляхом (без
*  "запасів")
*
*/