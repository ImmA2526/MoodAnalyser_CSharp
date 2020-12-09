using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
namespace MoodAnalyser
{
    [TestClass]
    public class UnitTest1
    {
        private readonly MoodAnalyser moodAnalyser;
        public UnitTest1()
        {
            moodAnalyser = new MoodAnalyser();
        }

        [TestMethod]
        public void givenMood_WhenHappy_ShouldReturnHappyMood()
        {
            var result = moodAnalyser.analyseMood("Happy");
            Assert.AreEqual("Happy mood", result);
        }
        [TestMethod]
        public void givenMood_WhenSad_ShouldReturnSadMood()
        {
            var result = moodAnalyser.analyseMood("Sad");
            Assert.AreEqual("Sad mood", result);
        }
    }
}