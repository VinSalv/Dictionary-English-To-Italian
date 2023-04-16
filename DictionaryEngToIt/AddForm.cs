/**
 *  @author Vincenzo Salvati - vincenzosalvati@hotmail.it
 *
 *  @file AddForm.cs
 *
 *  @brief Implementation of the class AddForm.
 *
 *  This file contains the implementation of the AddForm class.
 */

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryEngToIt
{
    public partial class AddForm : Form
    {
        private readonly MySqlConnection? connection;
        private readonly string? englishTextToDelete = null;
        private readonly string titleEdit = "Edit";
        private readonly string titleError = "Error";
        private readonly string textEnglishBoxEmpty = "English box is empty";
        private readonly string textNoPhrase = "English box is not set like a word";
        private readonly string textNoWord = "English box is not set like a phrase";
        private readonly string textItalianBoxEmpty = "Italian box is empty";

        public AddForm(MySqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        public AddForm(MySqlConnection connection, string englishText, string italianText, bool isPhrase = false, bool isAdjective = false, bool isVerb = false)
        {
            InitializeComponent();
            this.connection = connection;
            this.englishTextToDelete = englishText;

            // Set AddForm's components
            this.Text = titleEdit;
            englishRichTextBox.Text = englishText;
            italianRichTextBox.Text = italianText;

            phraseRadioButton.Checked = isPhrase;
            nounRadioButton.Checked = !isPhrase && !isAdjective && !isVerb;
            adjectiveRadioButton.Checked = isAdjective;
            verbRadioButton.Checked = isVerb;

            if (isPhrase)
            {
                nounRadioButton.Enabled = false;
                adjectiveRadioButton.Enabled = false;
                verbRadioButton.Enabled = false;
            }
            else
                phraseRadioButton.Enabled = false;

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (connection is not null)
            {
                // Format text and update text boxes
                string englishText = Utils.getFormatTextFrom(englishRichTextBox.Text);
                string italianText = Utils.getFormatTextFrom(italianRichTextBox.Text);
                englishRichTextBox.Text = englishText;
                italianRichTextBox.Text = italianText;

                // Check text boxes
                bool phraseWithoutSpaces = phraseRadioButton.Checked == true && !englishText.Contains(Utils.getSpaceString());
                bool wordWithSpaces = phraseRadioButton.Checked == false && englishText.Contains(Utils.getSpaceString());
                if (englishText == Utils.getEmptyString())
                {
                    MessageBox.Show(textEnglishBoxEmpty, titleError);
                    return;
                }
                else if (phraseWithoutSpaces)
                {
                    MessageBox.Show(textNoPhrase, titleError);
                    return;
                }
                else if (wordWithSpaces)
                {
                    MessageBox.Show(textNoWord, titleError);
                    return;
                }
                if (italianText == Utils.getEmptyString())
                {
                    MessageBox.Show(textItalianBoxEmpty, titleError);
                    return;
                }

                // Add or edit database's entity
                bool isUpdate = englishTextToDelete is not null;
                bool isPhrase = phraseRadioButton.Checked;
                bool isNoun = nounRadioButton.Checked;
                bool isAdjective = adjectiveRadioButton.Checked;
                if (!isUpdate)
                {
                    if (isPhrase)
                    {
                        if (DataAccessLayerQuery.AddPhraseFrom(connection, englishText, italianText)) Close();
                    }
                    else if (isNoun)
                    {
                        if (DataAccessLayerQuery.AddWordFrom(connection, englishText, italianText)) Close();
                    }
                    else if (isAdjective)
                    {
                        if (DataAccessLayerQuery.AddWordFrom(connection, englishText, italianText, isAdjective: true)) Close();
                    }
                    else
                    {
                        if (DataAccessLayerQuery.AddWordFrom(connection, englishText, italianText, isVerb: true)) Close();
                    }
                }
                else
                {
                    if (isPhrase)
                    {
                        if (DataAccessLayerQuery.EditPhraseFrom(connection, englishTextToDelete, englishText, italianText)) Close();
                    }
                    else if (isNoun)
                    {
                        if (DataAccessLayerQuery.EditWordFrom(connection, englishTextToDelete, englishText, italianText)) Close();
                    }
                    else if (isAdjective)
                    {
                        if (DataAccessLayerQuery.EditWordFrom(connection, englishTextToDelete, englishText, italianText, isAdjective: true)) Close();
                    }
                    else
                    {
                        if (DataAccessLayerQuery.EditWordFrom(connection, englishTextToDelete, englishText, italianText, isVerb: true)) Close();
                    }
                }
            }
        }
    }
}