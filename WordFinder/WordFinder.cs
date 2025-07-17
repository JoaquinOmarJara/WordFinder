using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder
{
    public class WordFinder
    { 
        IEnumerable<string> matrix;

        public WordFinder(IEnumerable<string> matrix)
        {
            this.matrix = matrix;
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream, int top = 10)
        {
            var foundedWords = new Dictionary<string, int>();
            wordstream = this.FilterInputWords(this.matrix, wordstream);
            this.FindInRows(this.matrix, wordstream, foundedWords);
            this.FindInColumns(this.matrix, wordstream, foundedWords);
            var mostRepeatedWords = this.GetMostRepeatedWords(foundedWords, top);
            return mostRepeatedWords;
        }

        public IEnumerable<string> FilterInputWords(IEnumerable<string> matrix, IEnumerable<string> wordstream)
        {
            var filterWords = new HashSet<string>();
            var columnsLength = matrix.Count();
            var rowsLength = matrix.First().Length;
            foreach (var item in wordstream)
            {
                if (item.Length <= columnsLength || item.Length <= rowsLength)
                {
                    filterWords.Add(item);
                }
            }
            return filterWords;
        }

        private IEnumerable<string> GetMostRepeatedWords(Dictionary<string, int> words, int top)
        {
            var wordsOrdered = words.OrderByDescending(x => x.Value).ToList();
            var mostRepeatedWords = wordsOrdered.Take(top);
            return mostRepeatedWords.Select(x => x.Key);
        }

        private void FindInRows(IEnumerable<string> matrix, IEnumerable<string> wordstream, Dictionary<string, int> foundedWords)
        {
            var wordBuilder = new StringBuilder();
            for (int x = 0; x < wordstream.Count(); x++)
            {
                var wordToFind = wordstream.ElementAt(x);

                for (int i = 0; i < matrix.Count(); i++)
                {
                    var line = matrix.ElementAt(i);
                    var wordToFindCounter = 0;
                    wordBuilder.Clear();
                    for (int j = 0; j < line.Count(); j++)
                    {
                        var currentCharacter = line[j];
                        var characterToFind = wordToFind[wordToFindCounter];
                        if (currentCharacter == characterToFind)
                        {
                            wordBuilder.Append(currentCharacter);
                            wordToFindCounter++;
                        }
                        else
                        {
                            wordBuilder.Clear();
                            wordToFindCounter = 0;
                        }

                        if (wordToFind == wordBuilder.ToString())
                        {
                            foundedWords.AddWord(wordBuilder.ToString());
                            wordToFindCounter = 0;
                            wordBuilder.Clear();
                            break;
                        }
                    }
                }
            }
        }
        private void FindInColumns(IEnumerable<string> matrix, IEnumerable<string> wordstream, Dictionary<string, int> foundedWords)
        {
            var wordBuilder = new StringBuilder();
            for (int x = 0; x < wordstream.Count(); x++)
            {
                var wordToFind = wordstream.ElementAt(x);
                var columnsLength = matrix.Count();
                var rowsLength = matrix.First().Length;
                for (int i = 0; i < rowsLength; i++)
                {
                    var wordToFindCounter = 0;
                    wordBuilder.Clear();
                    for (int j = 0; j < columnsLength; j++)
                    {
                        var currentCharacter = matrix.ElementAt(j)[i];
                        var characterToFind = wordToFind[wordToFindCounter];

                        if (currentCharacter == characterToFind)
                        {
                            wordBuilder.Append(currentCharacter);
                            wordToFindCounter++;
                        }
                        else if (wordBuilder.Length >= 1)
                        {
                            wordBuilder.Clear();
                            wordBuilder.Append(currentCharacter);
                            wordToFindCounter = 1;
                        }
                        else
                        {
                            wordBuilder.Clear();
                            wordToFindCounter = 0;
                        }

                        if (wordToFind == wordBuilder.ToString())
                        {
                            foundedWords.AddWord(wordBuilder.ToString());
                            wordToFindCounter = 0;
                            wordBuilder.Clear();
                            break;
                        }
                    }
                }
            }
        }
    }
}
