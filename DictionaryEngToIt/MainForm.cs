/**
 *  @author Vincenzo Salvati - vincenzosalvati@hotmail.it
 *
 *  @file MainForm.cs
 *
 *  @brief Implementation of the class MainForm.
 *
 *  This file contains the implementation of the MainForm class.
 */

using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using static DictionaryEngToIt.Phrase;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DictionaryEngToIt
{
    public partial class MainForm : Form
    {
        private readonly MySqlConnection? connection;
        private readonly string phrases = "Phrases";
        private readonly string words = "Words";
        private readonly string nouns = "Nouns";
        private readonly string adjectives = "Adjectives";
        private readonly string verbs = "Verbs";
        private readonly string edit = "Edit";
        private readonly string delete = "Delete";
        private readonly string titleConnectionFaild = "Database";
        private readonly string textConnectionFaild = "Database connection failed.";
        private readonly string titleAbout = "About";
        private readonly string textAbout = "© 2023 Vincenzo Salvati Rights Reserved.";

        public MainForm()
        {
            InitializeComponent();

            // Init and check database connection
            if (!DataAccessLayer.Connect())
                MessageBox.Show(textConnectionFaild, titleConnectionFaild);
            connection = DataAccessLayer.GetConnection();

            // Init columns listView and attach event handler Mouse Down
            int columnWidth = listView.Width / 2 - 10;
            listView.Columns.Add("English", columnWidth);
            listView.Columns.Add("Italian", columnWidth);
            listView.MouseDown += ListView_MouseDown;
        }

        private void ListView_MouseDown(object? sender, MouseEventArgs eventArgs)
        {
            void EditItem(ListViewItem item)
            {
                if (connection is not null)
                {
                    string englishOldText = item.Text;
                    bool isPhrase = englishOldText.Contains(Utils.getSpaceString());
                    AddForm? addForm = null;

                    if (isPhrase)
                    {
                        // Get phrase's information from database
                        Phrase? phrase = DataAccessLayerQuery.GetPhraseFrom(connection, englishOldText);

                        // Edit phrase's information
                        if (phrase is not null)
                            addForm = new AddForm(connection, englishOldText, phrase.ItalianPhrase, isPhrase: isPhrase);
                    }
                    else
                    {
                        // Get word's information from database
                        Word? word = DataAccessLayerQuery.GetWordFrom(connection, englishOldText);

                        // Edit word's information
                        if (word is not null)
                            addForm = new AddForm(connection, englishOldText, word.ItalianWord, isAdjective: word.IsAdjective, isVerb: word.IsVerb);
                    }

                    if (addForm is not null)
                    {
                        // Attach close event to AddForm and show AddForm
                        addForm.FormClosed += new FormClosedEventHandler(AddFormClosed);
                        addForm.Show();
                    }
                }
            }

            void DeleteItem(ListViewItem item)
            {
                if (connection is not null)
                {
                    string englishText = item.Text;
                    bool isPhrase = englishText.Contains(Utils.getSpaceString());

                    if (isPhrase)
                        // Remove phrase from database
                        DataAccessLayerQuery.RemovePhraseFrom(connection, englishText);
                    else
                        // Remove word from database
                        DataAccessLayerQuery.RemoveWordFrom(connection, englishText);

                    listView?.Items.Remove(item);
                }
            }

            if (eventArgs.Button == MouseButtons.Right)
            {
                // Get the clicked ListViewItem and SubItem
                ListViewItem clickedItem = listView.GetItemAt(eventArgs.X, eventArgs.Y);

                // Make a context menu with edit and delete options
                ContextMenuStrip contextMenu = new();
                ToolStripMenuItem editMenuItem = new(edit);
                ToolStripMenuItem deleteMenuItem = new(delete);

                // Attach event handlers to the edit and delete menu items
                editMenuItem.Click += (sender, args) => EditItem(clickedItem);
                deleteMenuItem.Click += (sender, args) => DeleteItem(clickedItem);

                // Show a context menu with edit and delete options
                if (clickedItem is not null)
                {
                    contextMenu.Items.Add(editMenuItem);
                    contextMenu.Items.Add(deleteMenuItem);
                    contextMenu.Show(listView, eventArgs.Location);
                }
            }
        }

        private void AddButton_Click(object sender, EventArgs eventArgs)
        {
            if (connection is not null)
            {
                AddForm addForm = new(connection);

                // Attach close event to AddForm and show AddForm
                addForm.FormClosed += new FormClosedEventHandler(AddFormClosed);
                addForm.Show();
            }
        }

        private void UpdateListView()
        {
            if (connection is not null)
            {

                if (letterPhrasesComboBox.SelectedItem is not null)
                {
                    string? selectedValue = letterPhrasesComboBox.SelectedItem.ToString();

                    if (selectedValue is not null)
                    {
                        // Define string arrays
                        string[]? englishArray = null;
                        string[]? italianArray = null;

                        // Fetch data from database
                        bool isPhrase = selectedValue == phrases;
                        if (isPhrase)
                        {
                            // Set MainForm's components
                            showGroupBox.Enabled = false;
                            phrasesWordsLabel.Text = phrases;

                            // Fetch phrases from database
                            SortedSet<Phrase>? sortedPhrases = DataAccessLayerQuery.GetPhrasesFrom(connection);
                            if (sortedPhrases is not null)
                            {
                                englishArray = sortedPhrases.Select(obj => obj.EnglishPhrase).ToArray();
                                italianArray = sortedPhrases.Select(obj => obj.ItalianPhrase).ToArray();
                            }
                        }
                        else
                        {
                            // Set MainForm's components
                            showGroupBox.Enabled = true;
                            phrasesWordsLabel.Text = words;

                            // Fetch words from database
                            SortedSet<Word>? sortedWords = null;
                            bool considerAllWords = allRadioButton.Checked;
                            if (considerAllWords)
                                sortedWords = DataAccessLayerQuery.GetAllWordsFrom(connection, selectedValue[0]);
                            else
                                sortedWords = DataAccessLayerQuery.GetWordsFrom(connection, selectedValue[0], isAdjective: adjectivesRadioButton.Checked, isVerb: verbsRadioButton.Checked);
                            if (sortedWords is not null)
                            {
                                englishArray = sortedWords.Select(obj => obj.EnglishWord).ToArray();
                                italianArray = sortedWords.Select(obj => obj.ItalianWord).ToArray();
                            }
                        }


                        // Clean and update listView
                        listView.Items.Clear();
                        if (englishArray is not null && italianArray is not null)
                        {
                            int rowCount = englishArray.Length;
                            for (int i = 0; i < rowCount; i++)
                            {
                                ListViewItem item = new(englishArray[i]);
                                item.SubItems.Add(italianArray[i]);
                                listView.Items.Add(item);
                            }
                        }
                    }
                }
            }
        }

        private void AddFormClosed(object sender, FormClosedEventArgs eventArgs)
        {
            UpdateListView();
        }

        private void LetterPhrasesComboBox_SelectedValueChanged(object sender, EventArgs eventArgs)
        {
            UpdateListView();
        }

        private void AllRadioButton_CheckedChanged(object sender, EventArgs eventArgs)
        {
            UpdateListView();
        }

        private void NounsRadioButton_CheckedChanged(object sender, EventArgs eventArgs)
        {
            UpdateListView();

            // Set MainForm's label
            phrasesWordsLabel.Text = nouns;
        }

        private void AdjectivesRadioButton_CheckedChanged(object sender, EventArgs eventArgs)
        {
            UpdateListView();

            // Set MainForm's label
            phrasesWordsLabel.Text = adjectives;
        }

        private void VerbsRadioButton_CheckedChanged(object sender, EventArgs eventArgs)
        {
            UpdateListView();

            // Set MainForm's label
            phrasesWordsLabel.Text = verbs;
        }

        private void ExitButton_Click(object sender, EventArgs eventArgs)
        {
            Close();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs eventArgs)
        {
            Close();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs eventArgs)
        {
            MessageBox.Show(textAbout, titleAbout);
        }
    }
}
