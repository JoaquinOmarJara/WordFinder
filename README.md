This problem was solved as follows:
*I have a class that handles all the processing.
*I have a testing project that tests some possible scenarios.

For better performance, I decided to analyze the words to be searched for, eliminating duplicates and those that don't fit the matrix size. For example, if my matrix is 10x10, it's clear that search words with more than 10 characters should not be considered.

To make the algorithm easier to understand, I created two methods in the WordFinder class that perform the word search. I separated them into row and column searches.

For optimal memory usage, I chose to use StringBuilder to avoid writing too many strings to memory and only use the same amount of memory space to build the words the algorithm is searching for.

Finally, to rank the most repeated words, I wrote a method that sorts them from most repeated to least repeated. I then take the top 10 and return them. I leave a "top" parameter to extend the functionality and allow for ranking different word counts.
