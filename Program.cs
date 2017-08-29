using System;
using System.Collections.Generic;
using System.Text;

namespace FrontlineCodeChallenge_2017
{
    public class Program
    {   
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter the string");
            var providedString = Console.ReadLine();
            if (providedString == "")
            {
                Console.WriteLine("Please enter the string");
                Console.ReadLine();
                Environment.Exit(0);
            }
            var outerString = ParseTheGivenString(providedString);
                       
            var finalArray = outerString.Split(',');

            foreach (var item in finalArray)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();   
        }

        //Parse the input string
        public static string ParseTheGivenString(string workingString)
        {
            StringBuilder inputString = new StringBuilder(workingString);
            if (inputString[0] == '(')
            {
                int length = workingString.LastIndexOf(')');
                var formattedString = inputString.Remove(0, 1);
                var formattedStringOutput = formattedString.Remove(length - 1, 1);
                inputString = formattedStringOutput;
            }
            inputString = inputString.Replace(", ", ",");
            var inputreformattedString = inputString.Replace("(", ",(,");
            inputreformattedString = inputreformattedString.Replace(")", ",)");
            string[] workingArray = inputreformattedString.ToString().Split(',');
            List<string> collection = new List<string>();
            int openBracketCounter = 0;
            int closeBracketCounter = 0;
            var intermediateString = "";
            foreach (var item in workingArray)
            {
                if (item.IndexOf("(") != -1)
                {
                    openBracketCounter++;
                    intermediateString += item;
                    continue;
                }
                if (item.IndexOf(")") != -1)
                {
                    closeBracketCounter++;
                    intermediateString += item + ",";
                    if (openBracketCounter == closeBracketCounter && closeBracketCounter != 0)
                    {
                        intermediateString = intermediateString.Replace(",(", "(");
                        intermediateString = intermediateString.Replace(",)", ")");

                        collection.Add(intermediateString);

                        openBracketCounter = 0;
                        closeBracketCounter = 0;
                        intermediateString = "";
                    }
                    continue;
                }

                if (item.IndexOf("(") == -1 && item.IndexOf(")") == -1)
                {
                    if (openBracketCounter == 0)
                    {
                        collection.Add(item);
                    }
                    else
                    {
                        if (openBracketCounter != closeBracketCounter)
                        {
                            intermediateString += item + ",";
                        }
                    }
                }

            }
            if (openBracketCounter != closeBracketCounter)
            {
                Console.WriteLine("Input String is not in a correct format, it is missing a bracket, Please check!");
                Console.ReadLine();
                Environment.Exit(0);
            }
            return CreateArrayOfProperties(collection);
        }

        //create array of properties 
        private static string CreateArrayOfProperties(List<string> stringsCollection)
        {
            int index = 0;
            List<string> properties = new List<string>();
            foreach (var item in stringsCollection)
            {
                index = stringsCollection.IndexOf(item);
                if(index < stringsCollection.Count - 1 && stringsCollection[index + 1].Contains("("))
                {
                    continue;
                }
                if (item.Contains("("))
                {
                    index = stringsCollection.IndexOf(item);
                    properties.Add(stringsCollection[index - 1] + item);
                }
                else
                {
                    properties.Add(item);
                }
            }
            properties.Sort();
            List<string> finalString = new List<string>();
            foreach (var property in properties)
            {
                int bracketIndex = property.IndexOf('(');
                int propertyIndex = properties.IndexOf(property);
                int innerIndex = 0, innerLength = 0, innerCount = 0;

                var workingProperty = property;

                int length = workingProperty.Length;
                int lastChar = workingProperty.LastIndexOf(',');
                if (lastChar == length - 1)
                {
                    workingProperty = workingProperty.Remove(lastChar, 1);
                }
                var subString = "";
                while (bracketIndex != -1)
                {
                    if (innerIndex > 1)
                    {
                    }
                    subString = findSubString(workingProperty, out innerIndex, out innerLength);
                    var finalSubString = RemoveAndInsert(workingProperty, subString, innerIndex, innerLength, ++innerCount);
                    bracketIndex = finalSubString.IndexOf('(');
                    workingProperty = finalSubString;
                }
                finalString.Add(workingProperty);
            }
            return string.Join(",", finalString.ToArray());
        }

        //find substring
        private static string findSubString(string workingString, out int index, out int length)
        {
            var start = workingString.IndexOf('(');
            var end = workingString.LastIndexOf(')');
            var subString = workingString.Substring(start + 1, end - start - 1);
            string[] array = subString.Split(',');
            Array.Sort(array, StringComparer.InvariantCulture);
            var sortedString = string.Join(",", array);
            index = start;
            length = end - start + 1;
            return sortedString;
        }

        //append Hyphen
        private static string appendHyphen(string str, int count)
        {
            var createString = "";
            StringBuilder createStr = new StringBuilder(createString);
            for (int i = 0; i < count; i++)
            {
                createStr.Append("-");
            }
            string[] strArray = str.Split(',');
            for (int i = 0; i < strArray.Length; i++)
            {
                strArray[i] = createStr.ToString() +" "+ strArray[i];
            }
            return string.Join(",", strArray);
        }

        //Replace the old string with the new one
        private static string RemoveAndInsert(string providedString, string subString, int index, int length, int count)
        {            
            var bStringBuilder = new StringBuilder(providedString);
            bStringBuilder.Remove(index, length);            
            var insertString = appendHyphen(subString, count);
            insertString = ","+insertString;
            bStringBuilder.Insert(index, insertString);
            return bStringBuilder.ToString();
        }
        
    }

}


























































































































































