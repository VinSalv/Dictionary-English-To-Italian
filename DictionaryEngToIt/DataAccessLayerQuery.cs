/**
 *  @author Vincenzo Salvati - vincenzosalvati@hotmail.it
 *
 *  @file DataAccessLayerQuery.cs
 *
 *  @brief Queries to interact with the database.
 *
 *  Queries to interact with MySQL database.
 */

using DictionaryEngToIt;
using MySql.Data.MySqlClient;
using System.Data;
using static DictionaryEngToIt.Phrase;
using static DictionaryEngToIt.Word;

internal static class DataAccessLayerQuery
{
    /// <summary>
    /// Get all phrases from database.
    /// </summary>
    /// <param name="connection">Connection to MySQL database.</param>
    /// <returns>A collection of all phrases.</returns>
    /// <remarks>A sorted collection of all phrases.</remarks>
    public static SortedSet<Phrase>? GetPhrasesFrom(MySqlConnection connection)
    {
        try
        {
            MySqlCommand cmd = new()
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM phrase"
            };

            MySqlDataReader reader = cmd.ExecuteReader();
            var sortedPhrases = new SortedSet<Phrase>(new PhraseComparer());
            while (reader.Read())
            {
                string? englishPhrase = reader["englishPhrase"].ToString();
                string? italianPhrase = reader["italianPhrase"].ToString();
                if (englishPhrase is not null && italianPhrase is not null)
                    sortedPhrases.Add(new Phrase(englishPhrase, italianPhrase));
            }
            reader.Close();

            return sortedPhrases;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error getting phrases: " + ex.Message, "Error");
            return null;
        }
    }

    /// <summary>
    /// Get words from database which start from a specific letter and respects boolean constraints.
    /// </summary>
    /// <param name="connection">Connection to MySQL database.</param>    
    /// <param name="letter">Initial letter to consider.</param>
    /// <param name="isAdjective">Consider adjectives words.</param>    
    /// <param name="isVerb">Consider verbs words.</param>
    /// <returns>A collection of specific words.</returns>
    /// <remarks>A sorted collection of spacific words based on constraints.</remarks>
    public static SortedSet<Word>? GetWordsFrom(MySqlConnection connection, char letter, bool isAdjective = false, bool isVerb = false)
    {
        try
        {
            MySqlCommand cmd = new()
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM word WHERE englishWord LIKE '" + letter + "%' and isAdjective=@isAdjective and isVerb = @isVerb"
            };

            cmd.Parameters.AddWithValue("@isAdjective", isAdjective);
            cmd.Parameters.AddWithValue("@isVerb", isVerb);

            MySqlDataReader reader = cmd.ExecuteReader();
            var sortedWords = new SortedSet<Word>(new WordComparer());
            while (reader.Read())
            {
                string? englishWord = reader["englishWord"].ToString();
                string? italianWord = reader["italianWord"].ToString();
                if (englishWord is not null && italianWord is not null)
                    sortedWords.Add(new Word(englishWord, italianWord, isAdjective: isAdjective, isVerb: isVerb));
            }
            reader.Close();

            return sortedWords;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error getting words: " + ex.Message, "Error");
            return null;
        }
    }

    /// <summary>
    /// Get words from database which start from a specific letter.
    /// </summary>
    /// <param name="connection">Connection to MySQL database.</param>    
    /// <param name="letter">Initial letter to consider.</param>
    /// <returns>A collection of words which start from a specific letter.</returns>
    /// <remarks>A sorted collection of spacific words which start from a specific letter.</remarks>
    public static SortedSet<Word>? GetAllWordsFrom(MySqlConnection connection, char letter)
    {
        try
        {
            MySqlCommand cmd = new()
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM word WHERE englishWord LIKE '" + letter + "%'"
            };

            MySqlDataReader reader = cmd.ExecuteReader();
            var sortedWords = new SortedSet<Word>(new WordComparer());
            while (reader.Read())
            {
                string? englishWord = reader["englishWord"].ToString();
                string? italianWord = reader["italianWord"].ToString();
                bool isAdjective = Convert.ToBoolean(reader["isAdjective"]);
                bool isVerb = Convert.ToBoolean(reader["isVerb"]);
                if (englishWord is not null && italianWord is not null)
                    sortedWords.Add(new Word(englishWord, italianWord, isAdjective: isAdjective, isVerb: isVerb));
            }
            reader.Close();

            return sortedWords;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error getting words: " + ex.Message, "Error");
            return null;
        }
    }

    /// <summary>
    /// Get information related to a specific phrase from database.
    /// </summary>
    /// <param name="connection">Connection to MySQL database.</param>
    /// <param name="englishPhrase">String to search.</param>
    /// <returns>Information releted to a phrase.</returns>
    public static Phrase? GetPhraseFrom(MySqlConnection connection, string englishPhrase)
    {
        try
        {
            MySqlCommand cmd = new()
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM phrase WHERE englishPhrase = @englishPhrase"
            };

            cmd.Parameters.AddWithValue("@englishPhrase", englishPhrase);

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string? italianPhrase = reader["italianPhrase"].ToString();
            reader.Close();

            if (italianPhrase is not null)
                return new Phrase(englishPhrase, italianPhrase);
            else
                return null;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error getting phrase: " + ex.Message, "Error");
            return null;
        }
    }

    /// <summary>
    /// Get information related to a specific word from database.
    /// </summary>
    /// <param name="connection">Connection to MySQL database.</param>
    /// <param name="englishWord">String to search.</param>
    /// <returns>Information releted to a word.</returns>
    public static Word? GetWordFrom(MySqlConnection connection, string englishWord)
    {
        try
        {
            MySqlCommand cmd = new()
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM word WHERE englishWord = @englishWord"
            };

            cmd.Parameters.AddWithValue("@englishWord", englishWord);

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string? italianWord = reader["italianWord"].ToString();
            bool isAdjective = Convert.ToBoolean(reader["isAdjective"]);
            bool isVerb = Convert.ToBoolean(reader["isVerb"]);
            reader.Close();

            if (italianWord is not null)
                return new Word(englishWord, italianWord, isAdjective, isVerb);
            else
                return null;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error getting word: " + ex.Message, "Error");
            return null;
        }
    }

    /// <summary>
    /// Get the id of a category from database.
    /// </summary>
    /// <param name="connection">Connection to MySQL database.</param>    
    /// <param name="isWord">Consider a word.</param>
    /// <returns>An entity's id of category table from the database</returns>
    private static int? FetchCategoryIdFrom(MySqlConnection connection, bool isWord = false)
    {
        try
        {
            MySqlCommand cmd = new()
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = "SELECT (id) FROM category WHERE isWord = @isWord"
            };

            cmd.Parameters.AddWithValue("@isWord", isWord);

            object result = cmd.ExecuteScalar();

            if (result is not null)
                return Convert.ToInt32(result);
            else
                return null;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error retrieving categoryId from database: " + ex.Message, "Error");
            return null;
        }
    }

    /// <summary>
    /// Insert a phrase into the database.
    /// </summary>
    /// <param name="connection">Connection to MySQL database.</param>    
    /// <param name="englishPhrase">String to insert.</param>
    /// <param name="italianPhrase">String to insert.</param>
    /// <returns>Boolean to confirm successful insertion</returns>
    public static bool AddPhraseFrom(MySqlConnection connection, string englishPhrase, string italianPhrase)
    {
        try
        {
            MySqlCommand cmd = new()
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = "INSERT INTO phrase (englishPhrase, italianPhrase, categoryId) VALUES (@englishPhrase, @italianPhrase, @categoryId)"
            };

            cmd.Parameters.AddWithValue("@englishPhrase", englishPhrase);
            cmd.Parameters.AddWithValue("@italianPhrase", italianPhrase);

            int? categoryId = FetchCategoryIdFrom(connection);
            if (categoryId is null)
            {
                MessageBox.Show("categoryId has not been fetched correctly", "Error");
                return false;
            }
            else 
                cmd.Parameters.AddWithValue("@categoryId", categoryId);

            cmd.ExecuteNonQuery();

            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error adding phrase to database: " + ex.Message, "Error");
            return false;
        }
    }

    /// <summary>
    /// Insert a word into the database.
    /// </summary>
    /// <param name="connection">Connection to MySQL database.</param>    
    /// <param name="englishWord">String to insert.</param>
    /// <param name="italianWord">String to insert.</param>
    /// <param name="isAdjective">Bool to insert.</param>
    /// <param name="isVerb">Bool to insert.</param>
    /// <returns>Boolean to confirm successful insertion</returns>
    public static bool AddWordFrom(MySqlConnection connection, string englishWord, string italianWord, bool isAdjective = false, bool isVerb = false)
    {
        try
        {
            MySqlCommand cmd = new()
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = "INSERT INTO word (englishWord, italianWord, isAdjective, isVerb, categoryId) VALUES (@englishWord, @italianWord, @isAdjective, @isVerb, @categoryId)"
            };

            cmd.Parameters.AddWithValue("@englishWord", englishWord);
            cmd.Parameters.AddWithValue("@italianWord", italianWord);
            cmd.Parameters.AddWithValue("@isAdjective", isAdjective);
            cmd.Parameters.AddWithValue("@isVerb", isVerb);

            int? categoryId = FetchCategoryIdFrom(connection, isWord: true);
            if (categoryId is null)
            {
                MessageBox.Show("categoryId has not been fetched correctly", "Error");
                return false;
            }
            else 
                cmd.Parameters.AddWithValue("@categoryId", categoryId);

            cmd.ExecuteNonQuery();

            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error adding word to database: " + ex.Message, "Error");
            return false;
        }
    }

    /// <summary>
    /// Edit a phrase into the database.
    /// </summary>
    /// <param name="connection">Connection to MySQL database.</param>    
    /// <param name="oldEnglishPhrase">String to search.</param>
    /// <param name="englishPhrase">String to insert.</param>
    /// <param name="italianPhrase">String to insert.</param>
    /// <returns>Boolean to confirm successful editing</returns>
    public static bool EditPhraseFrom(MySqlConnection connection, string oldEnglishPhrase, string englishPhrase, string italianPhrase)
    {
        try
        {
            MySqlCommand cmd = new()
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = "UPDATE phrase SET englishPhrase = @englishPhrase, italianPhrase = @italianPhrase WHERE englishPhrase = @oldEnglishPhrase"
            };

            cmd.Parameters.AddWithValue("@englishPhrase", englishPhrase);
            cmd.Parameters.AddWithValue("@italianPhrase", italianPhrase);
            cmd.Parameters.AddWithValue("@oldEnglishPhrase", oldEnglishPhrase);

            var rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error editing phrase in database: " + ex.Message, "Error");
            return false;
        }
    }

    /// <summary>
    /// Edit a word into the database.
    /// </summary>
    /// <param name="connection">Connection to MySQL database.</param>    
    /// <param name="oldEnglishWord">String to search.</param>
    /// <param name="englishWord">String to insert.</param>
    /// <param name="italianWord">String to insert.</param>
    /// <param name="isAdjective">Bool to insert.</param>
    /// <param name="isVerb">Bool to insert.</param>
    /// <returns>Boolean to confirm successful editing</returns>
    public static bool EditWordFrom(MySqlConnection connection, string oldEnglishWord, string englishWord, string italianWord, bool isAdjective = false, bool isVerb = false)
    {
        try
        {
            MySqlCommand cmd = new()
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = "UPDATE word SET englishWord = @englishWord, italianWord = @italianWord, isVerb = @isVerb, isAdjective = @isAdjective WHERE englishWord = @oldEnglishWord"
            };

            cmd.Parameters.AddWithValue("@englishWord", englishWord);
            cmd.Parameters.AddWithValue("@italianWord", italianWord);
            cmd.Parameters.AddWithValue("@isAdjective", isAdjective);
            cmd.Parameters.AddWithValue("@isVerb", isVerb);
            cmd.Parameters.AddWithValue("@oldEnglishWord", oldEnglishWord);

            var rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error editing word in database: " + ex.Message, "Error");
            return false;
        }
    }

    /// <summary>
    /// Remove a phrase into the database.
    /// </summary>
    /// <param name="connection">Connection to MySQL database.</param>    
    /// <param name="englishPhrase">String to search.</param>
    /// <returns>Boolean to confirm successful removal</returns>
    public static bool RemovePhraseFrom(MySqlConnection connection, string englishPhrase)
    {
        try
        {
            MySqlCommand cmd = new()
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = "DELETE FROM phrase WHERE englishPhrase = @englishPhrase"
            };

            cmd.Parameters.AddWithValue("@englishPhrase", englishPhrase);

            var rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error removing phrase from database: " + ex.Message, "Error");
            return false;
        }
    }

    /// <summary>
    /// Remove a word into the database.
    /// </summary>
    /// <param name="connection">Connection to MySQL database.</param>    
    /// <param name="englishWord">String to search.</param>
    /// <returns>Boolean to confirm successful removal</returns>
    public static bool RemoveWordFrom(MySqlConnection connection, string englishWord)
    {
        try
        {
            MySqlCommand cmd = new()
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = "DELETE FROM word WHERE englishWord = @englishWord"
            };

            cmd.Parameters.AddWithValue("@englishWord", englishWord);

            var rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error removing word from database: " + ex.Message, "Error");
            return false;
        }
    }
}