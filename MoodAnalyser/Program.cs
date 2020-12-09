using System;

namespace MoodAnalyser
{
    public class MoodAnalyser
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mood Analyser Project !");
        }
        public string analyseMood(string mood)
        {
            if (mood.Equals("Happy"))
            {
                return mood + " mood";
            }
            else
            {
                return mood + " mood";
            }
        }
    }
}