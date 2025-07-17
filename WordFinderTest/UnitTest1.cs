using WordFinder;

namespace WordFinderTest
{
    public class Tests
    {
        char[,] charMatrix;
        [SetUp]
        public void Setup()
        {
            this.charMatrix = new char[10, 10] { { 'j', 'q', 'z', 'b', 'c', 'a', 't', 'm', 'b', 'x' },
                                             { 'k', 'h', 'd', 'o', 'g', 'w', 'o', 'r', 'a', 'p' },
                                             { 'r', 'n', 'f', 't', 'y', 'l', 'p', 'a', 's', 'e' },
                                             { 'l', 'g', 'v', 'r', 'i', 'c', 'a', 'm', 'e', 'i' },
                                             { 't', 'u', 'm', 'o', 'u', 's', 'e', 'a', 'e', 'f' },
                                             { 't', 'i', 'q', 'x', 'y', 'z', 'b', 'o', 'a', 'r' },
                                             { 'a', 'q', 'z', 'e', 'g', 'j', 'c', 'k', 'e', 'y' },
                                             { 'b', 'b', 'l', 'm', 'e', 'l', 't', 'y', 'o', 'e' },
                                             { 'l', 'n', 'c', 'i', 'm', 'e', 'r', 'a', 's', 't' },
                                             { 'e', 'p', 'l', 'c', 'a', 't', 's', 't', 'u', 'd' } };

        }

        [Test]
        public void HappyPath()
        {
            var matrix = Util.ConvertToIEnumerable(this.charMatrix);
            var wordFinder = new WordFinder.WordFinder(matrix);
            IEnumerable<string> wordsToSearch = new List<string> { "cat", "dog", "laptop", "mouse", "board", "mic", "camera", "key", "table" };
            var wordsFoundedExpected = new List<string> { "cat", "dog", "mouse", "key", "mic", "table"};
            var wordsFounded = wordFinder.Find(wordsToSearch);
            Assert.That(wordsFoundedExpected.Count, Is.EqualTo(wordsFounded.Count()));
            for (int i = 0; i < wordsFoundedExpected.Count; i++)
            {
                Assert.IsTrue(wordsFoundedExpected[i].Equals(wordsFounded.ElementAt(i)));
            }
        }

        [Test]
        public void InputFilter_CleanRepeatedWords()
        {
            var matrix = Util.ConvertToIEnumerable(this.charMatrix);
            var wordFinder = new WordFinder.WordFinder(matrix);

            IEnumerable<string> wordsToSearch = new List<string> { "cat", "dog", "laptop", "mouse", "board", "mic", "camera", "key", "table", "dog", "cat", "mouse" };
            var filteredInputExpected = new List<string> { "cat", "dog", "laptop", "mouse", "board", "mic", "camera", "key", "table" };
            var filteredInput = wordFinder.FilterInputWords(matrix, wordsToSearch);

            Assert.That(filteredInputExpected.Count, Is.EqualTo(filteredInput.Count()));
            for (int i = 0; i < filteredInputExpected.Count; i++)
            {
                Assert.IsTrue(filteredInputExpected[i].Equals(filteredInput.ElementAt(i)));
            }
        }

        [Test]
        public void InputFilter_CleanLongWords()
        {
            var matrix = Util.ConvertToIEnumerable(this.charMatrix);
            var wordFinder = new WordFinder.WordFinder(matrix);

            IEnumerable<string> wordsToSearch = new List<string> { "cat", "dog", "laptop", "understanding", "board", "international", "camera", "unbelievable", "table" };
            var filteredInputExpected = new List<string> { "cat", "dog", "laptop", "board", "camera", "table" };
            var filteredInput = wordFinder.FilterInputWords(matrix, wordsToSearch);

            Assert.That(filteredInputExpected.Count, Is.EqualTo(filteredInput.Count()));
            for (int i = 0; i < filteredInputExpected.Count; i++)
            {
                Assert.IsTrue(filteredInputExpected[i].Equals(filteredInput.ElementAt(i)));
            }
        }

        [Test]
        public void MostRepeatedWordsOrderByDescending()
        {
            var matrix = Util.ConvertToIEnumerable(this.charMatrix);
            var wordFinder = new WordFinder.WordFinder(matrix);

            IEnumerable<string> wordsToSearch = new List<string> { "cat", "dog", "laptop", "understanding", "board", "international", "camera", "unbelievable", "table" };
            var foundedWordsExpected = new List<string> { "cat", "dog", "table" };
            var foundedWords = wordFinder.Find(wordsToSearch);

            Assert.That(foundedWordsExpected.Count, Is.EqualTo(foundedWords.Count()));
            for (int i = 0; i < foundedWordsExpected.Count; i++)
            {
                Assert.IsTrue(foundedWordsExpected[i].Equals(foundedWords.ElementAt(i)));
            }
        }
    }
}