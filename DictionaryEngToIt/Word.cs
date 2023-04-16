/**
 *  @author Vincenzo Salvati - vincenzosalvati@hotmail.it
 *
 *  @file Word.cs
 *
 *  @brief Implementation of the class Word.
 *
 *  This file contains the implementation of the Word class.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEngToIt
{
    internal class Word
    {
        private string englishWord;
        private string italianWord;

        public Word(string englishWord, string italianWord, bool isAdjective, bool isVerb)
        {
            EnglishWord = Utils.getFormatTextFrom(englishWord);
            ItalianWord = Utils.getFormatTextFrom(italianWord);
            IsAdjective = isAdjective;
            IsVerb = isVerb;
        }

        public string EnglishWord
        {
            get { return englishWord; }
            set { englishWord = Utils.getFormatTextFrom(value); }
        }

        public string ItalianWord
        {
            get { return italianWord; }
            set { italianWord = Utils.getFormatTextFrom(value); }
        }

        public bool IsAdjective { get; set; }

        public bool IsVerb { get; set; }

        public class WordComparer : IComparer<Word>
        {
            public int Compare(Word word1, Word word2)
            {
                // Use String.Compare to compare the attribute strings
                return String.Compare(word1.EnglishWord, word2.EnglishWord, StringComparison.InvariantCulture);
            }
        }
    }
}
