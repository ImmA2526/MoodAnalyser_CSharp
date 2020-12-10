using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    public class MoodAnalyser
    {
        private string message;
        static void Main(string[] args)
        {
        }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MoodAnalyser()
        {

        }
        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="message">The message for intialization of message</param>
        public MoodAnalyser(String message)
        {
            this.message = message;
        }
        /// <summary>
        /// Analyses the mood for happy,sad,handling exception for empty mood
        /// </summary>
        /// <returns>sad or happy when condtion is matched</returns>
        public string AnalyseMood()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.EMPTY_MESSAGE, "Mood Should Not Be Empty");

                }
                if (message.Contains("Sad"))
                {
                    return "Sad";
                }
                else
                {
                    return "Happy";
                }
            }
            catch (NullReferenceException)
            {
                return "Happy";
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NULL_MESSAGE, "Mood Should Not Be Null");
            }
        }
    }
}