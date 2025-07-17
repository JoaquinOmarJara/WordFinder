using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder
{
    public static class Util
    {
        public static IEnumerable<string> ConvertToIEnumerable(char[,] matrix)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                char[] row = new char[matrix.GetLength(0)];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    row[i] = matrix[j, i];
                }
                yield return new string(row);
            }
        }
    }

    public static class DictionaryExtensions
    {
        public static void AddWord(this Dictionary<string, int> dictionary, string word)
        {
            if (dictionary.ContainsKey(word))
            {
                dictionary[word] += 1;
            }
            else
            {
                dictionary.Add(word, 1);
            }
        }
    }
}
