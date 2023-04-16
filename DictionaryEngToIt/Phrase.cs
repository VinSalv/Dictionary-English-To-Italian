/**
 *  @author Vincenzo Salvati - vincenzosalvati@hotmail.it
 *
 *  @file Phrase.cs
 *
 *  @brief Implementation of the class Phrase.
 *
 *  This file contains the implementation of the Phrase class.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEngToIt
{
    internal class Phrase
    {
        private string italianPhrase;
        private string englishPhrase;

        public Phrase(string englishPhrase, string italianPhrase)
        {
            EnglishPhrase = Utils.getFormatTextFrom(englishPhrase);
            ItalianPhrase = Utils.getFormatTextFrom(italianPhrase);
        }

        public string EnglishPhrase
        {
            get { return englishPhrase; }
            set { englishPhrase = Utils.getFormatTextFrom(value); }
        }

        public string ItalianPhrase
        {
            get { return italianPhrase; }
            set { italianPhrase = Utils.getFormatTextFrom(value); }
        }

        public class PhraseComparer : IComparer<Phrase>
        {
            public int Compare(Phrase phrase1, Phrase phrase2)
            {
                // Use String.Compare to compare the attribute strings
                return String.Compare(phrase1.EnglishPhrase, phrase2.EnglishPhrase, StringComparison.InvariantCulture);
            }
        }
    }
}
