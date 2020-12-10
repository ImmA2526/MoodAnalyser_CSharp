using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyser
{
    public class MoodAnalyserFactory
    {
        /// <summary>
        /// Creates the mood analyzer.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="constructorName">Name of the constructor.</param>
        /// <returns>it returns null</returns>
        /// <exception cref="MoodAnalyserException">
        /// Class Not Found exception is throw when condtion is not matched
        /// or
        /// Constructor is Not Found exception is throw when condtion is not matched
        /// </exception>
        public static object CreateMoodAnalyser(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUBH_CLASS, "Class Not Found");
                }
            }
            else
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "Constructor is Not Found");
            }
        }/// <summary>
         /// create mood analyzer using parameteized constructor
         /// </summary>
         /// <param name="className">class name is nothing but name of class</param>
         /// <param name="constructorName">constructor name is the constructor used in class</param>
         /// <param name="message">message will be any</param>
         /// <returns>message</returns>
        public static object CreateMoodAnalyserUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                    object instance = constructorInfo.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "Constructor is Not Found");
                }
            }
            else
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUBH_CLASS, "Class Not Found");
            }
        }
        /// <summary>
        /// Invokes the analyse mood.
        /// </summary>
        /// <param name="message">The message will be any its depend on user</param>
        /// <param name="methodeName">create mood analyzer using parameterized constructor</param>
        /// <returns>message</returns>
        /// <exception cref="MoodAnalyserException">Method is not found</exception>
        public static string InvokeAnalyseMood(string message, string methodeName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyser.MoodAnalyser");
                object moodAnalyseObject = MoodAnalyserFactory.CreateMoodAnalyserUsingParameterizedConstructor("MoodAnalyser.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo methodeInfo = type.GetMethod(methodeName);
                object mood = methodeInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString();
            }
            catch
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "Method is not found");
            }
        }
        /// <summary>
        /// creating Sets the field.
        /// </summary>
        /// <param name="message">The message contain happy.</param>
        /// <param name="fieldName">Name of the field that is message.</param>
        /// <returns>message of mood analyzer class</returns>
        /// <exception cref="MoodAnalyserException">
        /// Message should not be null
        /// or
        /// Field is not found
        /// </exception>
        public static string SetField(string message, string fieldName)
        {
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser();
                Type type = typeof(MoodAnalyser);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_FIELD, "Message should not be null");
                }
                field.SetValue(moodAnalyser, message);
                return moodAnalyser.message;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_FIELD, "Field is not found");
            }
        }
    }
}