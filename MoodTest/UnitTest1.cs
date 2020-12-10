using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyser;
namespace MoodAnalyser
{ 
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// This Test case ensure AnalyseMood() method will return when SAD when message contains Sad
        /// </summary>
        [TestMethod]
        public void GivenSadMessage_WhenSad_ShouldReturnSAD()
        {
            //Arrange
            string Expected = "SAD";
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in Sad Mood");
            //Act
            string result = moodAnalyser.AnalyseMood();
            //Assert//
            Assert.AreEqual(Expected, result);
        }

        /// <summary>
        /// This Test case ensure AnalyseMood() method will return when HAPPY when message contains Happy
        /// </summary>
        [TestMethod]
        public void GivenHappyMessage_WhenAnyMood_ShouldReturnHAPPY()
        {
            //Arrange
            string Expected = "HAPPY";
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in Happy Mood");
            //Act
            string result = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual(Expected, result);
        }

        /// <summary>
        /// This Test case ensure AnalyseMood() method will return when HAPPY when Any mood message is given
        /// </summary>
        [TestMethod]
        public void GivenAnyMessage_WhenAnyMood_ShouldReturnHAPPY()
        {
            //Arrange
            string Expected = "HAPPY";
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in Any Mood");
            //Act
            string result = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual(Expected, result);
        }

        /// <summary>
        /// This Test case ensure AnalyseMood() method will return when HAPPY when Null mood message is given
        /// </summary>
        [TestMethod]
        [DataRow("null")]
        public void GivenNULLMessage_WhenANULL_ShouldReturnHAPPY(string message)
        {
            //Arrange
            string Expected = "Happy";
            MoodAnalyser moodAnalyser = new MoodAnalyser(message);
            //Act
            string result = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual(Expected, result);
        }

        /// <summary>
        /// This Test case ensure when given empty message will throw an exception
        /// </summary>
        [TestMethod]
        [DataRow("")]
        public void GivenEmptyMessage_WhenEmpty_ShouldThrowException(string message)
        {
            try
            {
                //Arrange
                MoodAnalyser moodAnalyser = new MoodAnalyser(message);
                //Act
                string result = moodAnalyser.AnalyseMood();
            }
            catch (MoodAnalyserException e)
            {
                //Assert         
                Assert.AreEqual("Mood should not be empty", e.Message);
            }
        }

        /// <summary>
        /// UC4-TC4.1 Proper class details are provided and expected to return the MoodAnalyser Object
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyserObject()
        {
            object expected = new MoodAnalyser();
            object obj = MoodAnalyserFactory.CreateeMoodAnalyse("MoodAnalyser.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }

        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyserObject_UsingParameterizdConstructor()
        {
            object expected = new MoodAnalyser("HAPPY");
            object obj = MoodAnalyserFactory.CreateMoodAnalyserUsingParameterizedConstructor("MoodAnalyser.MoodAnalyser", "MoodAnalyser", "HAPPY");
            expected.Equals(obj);
        }

    }
}