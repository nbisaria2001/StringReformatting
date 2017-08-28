using System;
using System.Text;

namespace FrontlineCodeChallenge_2017
{
    class Program
    {    
        static void Main(string[] args)
        {
            var inputString = "id, created, employee(id, firstname, employeeType(id), lastname),location";
            string[] stringArray = inputString.Split(',');
            Array.Sort(stringArray, StringComparer.InvariantCulture);
            var outerString = String.Join(",",stringArray);
            int index, length;
            var subString = findSubString(outerString, out index, out length);
            var finalSubString = "";
            var count = 0;
            var innerCount = 0;
            var hyphenedString = appendHyphen(subString, ++innerCount);

            if (index > 1)
            {
                int innerIndex, innerLength;
                var innerSubString = findSubString(hyphenedString, out innerIndex, out innerLength);
                if (innerIndex > 1)
                {
                    finalSubString = RemoveAndInsert(hyphenedString, innerSubString, innerIndex, innerLength, ++innerCount);
                }
            }
            
            var finalString = RemoveAndInsert(outerString, finalSubString, index, length, count);
            var finalArray = finalString.Split(',');

            foreach (var item in finalArray)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();   
        }

        private static string findSubString(string workingString, out int index, out int length)
        {
            var start = workingString.IndexOf('(');
            var end = workingString.LastIndexOf(')');
            var subString = workingString.Substring(start + 1, end - start - 1);
            var formattedString = " " + subString;
            string[] array = formattedString.Split(',');
            Array.Sort(array, StringComparer.InvariantCulture);
            var sortedString = string.Join(",", array);
            index = start;
            length = end - start + 1;
            return sortedString;
        }

        private static string appendHyphen(string str, int count)
        {
            var createString = "";
            for (int i = 0; i < count; i++)
            {
                createString += "-";
            }
            string[] strArray = str.Split(',');
            for (int i = 0; i < strArray.Length; i++)
            {
                strArray[i] = createString + strArray[i];
            }
            return string.Join(",", strArray);
        }

        private static string RemoveAndInsert(string providedString, string subString, int index, int length, int count)
        {            
            var bStringBuilder = new StringBuilder(providedString);
            bStringBuilder.Remove(index, length);            
            var insertString = appendHyphen(subString, count);
            insertString = insertString + ",";
            bStringBuilder.Insert(index + 1, insertString);
            return bStringBuilder.ToString();
        }
        
    }

}


























































































































































