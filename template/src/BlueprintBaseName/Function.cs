using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace BlueprintBaseName
{
    public class Function
    {
        public char[] vowels = {'a', 'e', 'i', 'o', 'u', 'y'};
        public string ToPigLatin(string input) 
        {
            input = input.ToLower();
            var words = input.Split(new char[] {' '});
            for (int i=0; i < words.Length; i++)
            {
                // If the first letter is a consonant
                if (!vowels.Contains(words[i][0]))
                {
                    words[i] = words[i].Substring(1, words[i].Length - 1) + words[i][0];
                }
                if (vowels.Contains(words[i][words[i].Length - 1])) 
                {
                    words[i] += "yay";
                }
                else
                {
                    words[i] += "ay";
                }
            }
            return string.Join(" ", words);
        }
        
        /// <summary>
        /// Returns pig latin version of a string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(string input, ILambdaContext context)
        {
            return ToPigLatin(input);
        }
    }
}
