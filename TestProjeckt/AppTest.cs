using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Classwork;
namespace TestProjeckt
{
    class AppTest
    {
        [TestMethod]
        public void ClacTest()
        {
Classwork.Calck calc = new();
            // Твердження - маємо одержати не-null результат
            Assert.IsNotNull(calc);

        }
        [TestMethod]
        public void RomNumberTest()
        {
            Assert.AreEqual(Rumnumber.Parse("I"), 1, "I==1");
            Assert.AreEqual(Rumnumber.Parse("V"), 5, "V==5");
            Assert.AreEqual(Rumnumber.Parse("IV"), 4, "IV==4");
            Assert.AreEqual(Rumnumber.Parse("XV"), 15);
            Assert.AreEqual(Rumnumber.Parse("XXX"), 30);
            Assert.AreEqual(Rumnumber.Parse("CM"), 900);
            Assert.AreEqual(Rumnumber.Parse("MCMXCIX"), 1999);
            Assert.AreEqual(Rumnumber.Parse("CD"), 400);
            Assert.AreEqual(Rumnumber.Parse("CDI"), 401);
            Assert.AreEqual(Rumnumber.Parse("LV"), 55);
            Assert.AreEqual(Rumnumber.Parse("XL"), 40);
        }

        //- Додати тест для числа "N" - 0
        [TestMethod]
        public void RomNumberTest()
        {
            Assert.AreEqual(0, Rumnumber.Parse("N"));
        }

    }
}
