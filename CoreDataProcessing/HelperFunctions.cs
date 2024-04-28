using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDataProcessing
{
    public static class HelperFunctions
    {
        public static string LatinToCyrillicUzbek(string input)
        {
            var latin = new string[] { "A", "B", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z", "Oʻ", "Gʻ", "Sh", "Ch",
                               "a", "b", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "x", "y", "z", "oʻ", "gʻ", "sh", "ch"};
            var cyrillic = new string[] { "А", "Б", "Д", "Е", "Ф", "Г", "Ҳ", "И", "Ж", "К", "Л", "М", "Н", "О", "П", "Қ", "Р", "С", "Т", "У", "В", "Х", "Й", "З", "Ў", "Ғ", "Ш", "Ч",
                                  "а", "б", "д", "е", "ф", "г", "ҳ", "и", "ж", "к", "л", "м", "н", "о", "п", "қ", "р", "с", "т", "у", "в", "х", "й", "з", "ў", "ғ", "ш", "ч"};
            for (int i = 0; i < latin.Length; i++)
            {
                input = input.Replace(latin[i], cyrillic[i]);
            }
            return input;
        }

        public static string RemovePunctuations(string input)
        {
            return Regex.Replace(input, @"\p{P}+", "");
        }

        public static string CyrillicToLatinUzbek(string input)
        {
            var cyrillic = new string[] {"А", "Б", "Д", "Е", "Ф", "Г", "Ҳ", "И", "Ж", "К", "Л", "М", "Н", "О", "П", "Қ", "Р", "С", "Т", "У", "В", "Х", "Й", "З", "Ў", "Ғ", "Ш", "Ч",
                                 "а", "б", "д", "е", "ф", "г", "ҳ", "и", "ж", "к", "л", "м", "н", "о", "п", "қ", "р", "с", "т", "у", "в", "х", "й", "з", "ў", "ғ", "ш", "ч"};
            var latin = new string[] {"A", "B", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "Z", "Oʻ", "Gʻ", "Sh", "Ch",
                              "a", "b", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "x", "y", "z", "oʻ", "gʻ", "sh", "ch"};
            for (int i = 0; i < cyrillic.Length; i++)
            {
                input = input.Replace(cyrillic[i], latin[i]);
            }
            return input;
        }

        /// <summary>
        /// Calculate percentage similarity of two strings
        /// <param name="source">Source String to Compare with</param>
        /// <param name="target">Targeted String to Compare</param>
        /// <returns>Return Similarity between two strings from 0 to 1.0</returns>
        /// </summary>
        public static double CalculateSimilarity(this string source, string target)
        {
            if ((source == null) || (target == null)) return 0.0;
            if ((source.Length == 0) || (target.Length == 0)) return 0.0;
            if (source == target) return 1.0;

            int stepsToSame = ComputeLevenshteinDistance(source, target);
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }
        /// <summary>
        /// Returns the number of steps required to transform the source string
        /// into the target string.
        /// </summary>
        static int ComputeLevenshteinDistance(string source, string target)
        {
            if ((source == null) || (target == null)) return 0;
            if ((source.Length == 0) || (target.Length == 0)) return 0;
            if (source == target) return source.Length;

            int sourceWordCount = source.Length;
            int targetWordCount = target.Length;

            // Step 1
            if (sourceWordCount == 0)
                return targetWordCount;

            if (targetWordCount == 0)
                return sourceWordCount;

            int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

            // Step 2
            for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

            for (int i = 1; i <= sourceWordCount; i++)
            {
                for (int j = 1; j <= targetWordCount; j++)
                {
                    // Step 3
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 4
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }

            return distance[sourceWordCount, targetWordCount];
        }
    }
}
