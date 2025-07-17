using System.Text;
using WordFinder;

char[,] matriz = new char[10, 10] { { 'j', 'q', 'z', 'b', 'c', 'a', 't', 'm', 'b', 'x' },
                                    { 'k', 'h', 'd', 'o', 'g', 'w', 'o', 'r', 'a', 'p' },
                                    { 'r', 'n', 'f', 't', 'y', 'l', 'p', 'a', 's', 'e' },
                                    { 'l', 'g', 'v', 'r', 'i', 'c', 'a', 'm', 'e', 'i' },
                                    { 't', 'u', 'm', 'o', 'u', 's', 'e', 'a', 'e', 'f' },
                                    { 't', 'i', 'q', 'x', 'y', 'z', 'b', 'o', 'a', 'r' },
                                    { 'a', 'q', 'z', 'e', 'g', 'j', 'c', 'k', 'e', 'y' },
                                    { 'b', 'b', 'l', 'm', 'e', 'l', 't', 'y', 'o', 'e' },
                                    { 'l', 'n', 'c', 'i', 'm', 'e', 'r', 'a', 's', 't' },
                                    { 'e', 'p', 'l', 'c', 'a', 't', 's', 't', 'u', 'd' } };

IEnumerable<string> wordsToSearch = new List<string> { "cat", "dog", "laptop", "mouse", "board", "mic", "camera", "key", "table", "international", "dog", "cat" };

var matrix = Util.ConvertToIEnumerable(matriz);
var wordFinder = new WordFinder.WordFinder(matrix);
var wordsFounded = wordFinder.Find(wordsToSearch);
foreach (var word in wordsFounded)
{
    Console.WriteLine(word);
}
Console.ReadLine();



