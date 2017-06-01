
using System;
using GreyhoundDsed_Portable.Factory;
using GreyhoundDsed_Portable.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AiPunterPopulateTest()
        {
            Punter[] punters = new Punter[3];

            var factory = new PunterFactory();

            for (int i = 0; i < punters.Length; i++)
            {
                punters[i] = factory.GetNewAiPunter(i);
            }

            Assert.IsNotNull(punters[1].Money);
        }

        [TestMethod]
        public void AiPunterRandomBets()
        {
            Punter[] punters1 = new Punter[3];
            Punter[] punters2 = new Punter[3];

            var factory = new PunterFactory();

            for (int i = 0; i < punters1.Length; i++)
            {
                punters1[i] = factory.GetNewAiPunter(i);
                punters2[i] = factory.GetNewAiPunter(i);
            }

            factory.SetRandomBetAmount(punters1);
            factory.SetRandomBetAmount(punters2);

            // possible equal values due to random number range being not that big
            Assert.AreNotEqual(punters1[0], punters2[0]);
        }
    }
}
