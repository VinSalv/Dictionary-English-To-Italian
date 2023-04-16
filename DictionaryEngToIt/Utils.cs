/**
 *  @author Vincenzo Salvati - vincenzosalvati@hotmail.it
 *
 *  @file Utils.cs
 *
 *  @brief Useful constants and functions.
 *
 *  This file contiens constants and functions useful for other classes.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DictionaryEngToIt
{
    internal static class Utils
    {
        private static readonly string regexInitialSpaces = "^[\\s]*";
        private static readonly string regexFinalSpaces = "\\s+$";
        private static readonly string regexSpaces = "\\s+";
        private static readonly string empty = "";
        private static readonly string space = " ";

        public static string getEmptyString()
        {
            return empty;
        }

        public static string getSpaceString()
        {
            return space;
        }

        /// <summary>
        /// Format a string.
        /// </summary>
        /// <param name="text">String.</param>
        /// <returns>A formatted string.</returns>
        /// <remarks>Format string by using regex expressions.</remarks>
        public static string getFormatTextFrom(string text)
        {
            text = removeInitialSpacesFrom(text);
            text = removeFinalSpacesFrom(text);
            text = removeMultipleSpacesFrom(text);
            return text;
        }

        /// <summary>
        /// Remove initial spaces from a string.
        /// </summary>
        /// <param name="text">String.</param>
        /// <returns>A string without initial spaces.</returns>
        /// <remarks>Remove initial spaces from a string by using regex expression.</remarks>
        private static string removeInitialSpacesFrom(string text)
        {
            string replacement = getEmptyString();
            return Regex.Replace(text, regexInitialSpaces, replacement);
        }

        /// <summary>
        /// Remove final spaces from a string.
        /// </summary>
        /// <param name="text">String</param>
        /// <returns>A string without final spaces.</returns>
        /// <remarks>Remove final spaces from a string by using regex expression.</remarks>
        private static string removeFinalSpacesFrom(string text)
        {
            string replacement = getEmptyString();
            return Regex.Replace(text, regexFinalSpaces, replacement);
        }

        /// <summary>
        /// Remove multiple spaces from a string.
        /// </summary>
        /// <param name="text">String</param>
        /// <returns>A string without multiple spaces</returns>
        /// <remarks>Remove multiple spaces from a string by using regex expression.</remarks>
        private static string removeMultipleSpacesFrom(string text)
        {
            string replacement = getSpaceString();
            return Regex.Replace(text, regexSpaces, replacement);
        }
    }
}
