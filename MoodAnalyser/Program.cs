using System;

namespace MoodAnalyser
{
    public class MoodAnalyser
    {
        public string message;
        public MoodAnalyser() : this("I am in Happy Mood")
        {

        }
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        static void Main(string[] args)
        {

        }
        public string AnalyseMood()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.EMPTY_MESSAGE, "Mood should not be empty");
                }
                if (this.message.Contains("Sad"))
                {
                    return "SAD";
                }
                else if (this.message.Contains("Happy"))
                {
                    return "HAPPY";
                }
                else if (this.message.Contains("Any"))
                {
                    return "HAPPY";
                }
                else
                {
                    return "Happy";
                }
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NULL_MESSAGE, "Message should not be null");
            }
        }
    }
}