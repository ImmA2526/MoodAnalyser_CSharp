using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MoodAnalyser;

namespace MoodAnalyser
{
    [TestClass]
    public class UnitTest1
    {
        MoodAnalyser MoodAnalyser = null;
        ///<summary>
        /// Default constructor
        ///</summary>
        public UnitTest1()
        {

        }
        ///<summary>
        /// TC 1.1 Given i am in sad mood should return sad mood.
        ///</summary>
        [TestMethod]
        public void GivenMood_WhenSad_ThenShouldReturnSadMood()
        {
            string Expected = "Sad";
            MoodAnalyser = new MoodAnalyser("I am in Sad Mood");
            string mood = MoodAnalyser.AnalyseMood();
            Assert.AreEqual(Expected, mood);
        }
        ///<summary>
        /// TC 1.2 Given i am in Happy mood should return Happy mood.
        ///</summary>
        [TestMethod]
        public void GivenMood_WhenHappy_ThenShouldReturnHappyMood()
        {
            string Expected = "Happy";
            MoodAnalyser = new MoodAnalyser("I am in happy Mood");
            string mood = MoodAnalyser.AnalyseMood();
            Assert.AreEqual(Expected, mood);
        }
        ///<summary>
        /// TC 2.1 Given null mood should return happy mood.
        ///</summary>
        [TestMethod]
        [DataRow(null)]
        public void GivenMood_WhenNull_ThenShouldReturnHappyMood(string message)
        {
            string Expected = "Happy";
            MoodAnalyser = new MoodAnalyser(message);
            string mood = MoodAnalyser.AnalyseMood();
            Assert.AreEqual(Expected, mood);
        }
        /// <summary>
        /// TC 3.1 Given Mood when null should throw mood analysis exception
        /// </summary>
        [TestMethod]
        public void GivenMood_WhenNull_ThenShouldThrowMoodAnalyserException()
        {
            try
            {
                string message = null;
                MoodAnalyser = new MoodAnalyser(message);
                string mood = MoodAnalyser.AnalyseMood();
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual("Mood Should Not Be Null", e.Message);
            }
        }
        /// <summary>
        /// TC 3.2 Given Empty Mood Should Throw MoodAnalysisException indicating Empty Mood
        /// </summary>
        [TestMethod]
        public void GivenMood_WhenEmpty_ThenShouldThrowMoodAnalyserException()
        {
            try
            {
                string message = "";
                MoodAnalyser = new MoodAnalyser(message);
                string mood = MoodAnalyser.AnalyseMood();
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual("Mood Should Not Be Empty", e.Message);
            }
        }
        /// <summary>
        ///  TC 4.1 Given Mood Analyser class name should return MoodAnalyser object
        ///  MoodAnalyser<<-this is nameSpace
        ///  MoodAnalyser<<-this is for class name and constructor name
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyser_WhenClassName_ShouldReturnMoodAnalyserObject()
        {
            string message = null;
            object expected = new MoodAnalyser(message);
            object obj = MoodAnalyserFactory.CreateMoodAnalyser("MoodAnalyser.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }
        /// <summary>
        /// TC 4.2 Given class name  when not proper then throw mood analyzer exception
        /// </summary>
        [TestMethod]
        public void GivenClassName_WhenImproper_ThenShouldThrowMoodAnalyserException()
        {
            string expected = "Class Not Found";
            try
            {
                object obj = MoodAnalyserFactory.CreateMoodAnalyser("MoodAnalyser.WrongClass", "WrongClass");
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }
        /// <summary>
        /// TC 4.3 Given class when constructor not proper then throw mood analyzer exception
        /// </summary>
        [TestMethod]
        public void GivenClass_WhenConstructorNotProper_ThenShouldThrowMoodAnalyserException()
        {
            string expected = "Constructor is Not Found";
            try
            {
                object obj = MoodAnalyserFactory.CreateMoodAnalyser("MoodAnalyser.MoodAnalyser", "WrongConstructor");
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }
        /// <summary>
        ///  TC 5.1 Given Mood Analyser when class name with parameterized constructor should return object
        ///  MoodAnalyser<<-this is nameSpace
        ///  MoodAnalyser<<-this is for class
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyser_WhenClassName_ShouldReturnMoodAnalyserObjectUsingParameterizedConstructor()
        {
            object expected = new MoodAnalyser("Happy");
            object obj = MoodAnalyserFactory.CreateMoodAnalyserUsingParameterizedConstructor("MoodAnalyser.MoodAnalyser", "MoodAnalyser", "Happy");
            expected.Equals(obj);
        }
        /// <summary>
        /// TC 5.2 Given class name  when not proper then throw no such class exception
        /// </summary>
        [TestMethod]
        public void GivenClassName_WhenImproper_ThenShouldThrowNoSuchClassException()
        {
            string expected = "Class Not Found";
            try
            {
                object obj = MoodAnalyserFactory.CreateMoodAnalyserUsingParameterizedConstructor("MoodAnalyser.WrongClass", "MoodAnalyser", "Happy");
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }
        /// <summary>
        /// TC 5.3 Given class when constructor not proper then throw no such constructor exception
        /// </summary>
        [TestMethod]
        public void GivenClass_WhenConstructorNotProper_ThenShouldThrowNoSuchConstructorException()
        {
            string expected = "Constructor is Not Found";
            try
            {
                object obj = MoodAnalyserFactory.CreateMoodAnalyserUsingParameterizedConstructor("MoodAnalyser.MoodAnalyser", "WrongConstructor", "Happy");
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }
    }
}