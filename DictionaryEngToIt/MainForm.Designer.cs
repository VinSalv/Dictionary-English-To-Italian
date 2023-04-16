namespace DictionaryEngToIt
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            addButton = new Button();
            exitButton = new Button();
            letterPhrasesComboBox = new ComboBox();
            allRadioButton = new RadioButton();
            nounsRadioButton = new RadioButton();
            adjectivesRadioButton = new RadioButton();
            phrasesWordsLabel = new Label();
            showGroupBox = new GroupBox();
            verbsRadioButton = new RadioButton();
            listView = new ListView();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            showGroupBox.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // addButton
            // 
            addButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            addButton.Location = new Point(12, 27);
            addButton.Name = "addButton";
            addButton.Size = new Size(189, 29);
            addButton.TabIndex = 1;
            addButton.Text = "Add . . .";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += AddButton_Click;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            exitButton.Location = new Point(12, 893);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(189, 56);
            exitButton.TabIndex = 2;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += ExitButton_Click;
            // 
            // letterPhrasesComboBox
            // 
            letterPhrasesComboBox.FormattingEnabled = true;
            letterPhrasesComboBox.Items.AddRange(new object[] { "Phrases", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" });
            letterPhrasesComboBox.Location = new Point(773, 27);
            letterPhrasesComboBox.Name = "letterPhrasesComboBox";
            letterPhrasesComboBox.Size = new Size(199, 29);
            letterPhrasesComboBox.TabIndex = 3;
            letterPhrasesComboBox.Text = "Select Letter or Phrases...";
            letterPhrasesComboBox.SelectedValueChanged += LetterPhrasesComboBox_SelectedValueChanged;
            // 
            // allRadioButton
            // 
            allRadioButton.AutoSize = true;
            allRadioButton.Checked = true;
            allRadioButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            allRadioButton.Location = new Point(8, 30);
            allRadioButton.Name = "allRadioButton";
            allRadioButton.Size = new Size(46, 25);
            allRadioButton.TabIndex = 4;
            allRadioButton.TabStop = true;
            allRadioButton.Text = "All";
            allRadioButton.UseVisualStyleBackColor = true;
            allRadioButton.CheckedChanged += AllRadioButton_CheckedChanged;
            // 
            // nounsRadioButton
            // 
            nounsRadioButton.AutoSize = true;
            nounsRadioButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            nounsRadioButton.Location = new Point(8, 80);
            nounsRadioButton.Name = "nounsRadioButton";
            nounsRadioButton.Size = new Size(74, 25);
            nounsRadioButton.TabIndex = 5;
            nounsRadioButton.Text = "Nouns";
            nounsRadioButton.UseVisualStyleBackColor = true;
            nounsRadioButton.CheckedChanged += NounsRadioButton_CheckedChanged;
            // 
            // adjectivesRadioButton
            // 
            adjectivesRadioButton.AutoSize = true;
            adjectivesRadioButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            adjectivesRadioButton.Location = new Point(8, 130);
            adjectivesRadioButton.Name = "adjectivesRadioButton";
            adjectivesRadioButton.Size = new Size(98, 25);
            adjectivesRadioButton.TabIndex = 6;
            adjectivesRadioButton.Text = "Adjectives";
            adjectivesRadioButton.UseVisualStyleBackColor = true;
            adjectivesRadioButton.CheckedChanged += AdjectivesRadioButton_CheckedChanged;
            // 
            // phrasesWordsLabel
            // 
            phrasesWordsLabel.AutoSize = true;
            phrasesWordsLabel.Location = new Point(222, 45);
            phrasesWordsLabel.Name = "phrasesWordsLabel";
            phrasesWordsLabel.Size = new Size(132, 21);
            phrasesWordsLabel.TabIndex = 7;
            phrasesWordsLabel.Text = "Phrases or Words";
            // 
            // showGroupBox
            // 
            showGroupBox.Controls.Add(verbsRadioButton);
            showGroupBox.Controls.Add(allRadioButton);
            showGroupBox.Controls.Add(nounsRadioButton);
            showGroupBox.Controls.Add(adjectivesRadioButton);
            showGroupBox.Enabled = false;
            showGroupBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            showGroupBox.Location = new Point(12, 216);
            showGroupBox.Name = "showGroupBox";
            showGroupBox.Size = new Size(189, 230);
            showGroupBox.TabIndex = 8;
            showGroupBox.TabStop = false;
            showGroupBox.Text = "Show:";
            // 
            // verbsRadioButton
            // 
            verbsRadioButton.AutoSize = true;
            verbsRadioButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            verbsRadioButton.Location = new Point(8, 180);
            verbsRadioButton.Name = "verbsRadioButton";
            verbsRadioButton.Size = new Size(67, 25);
            verbsRadioButton.TabIndex = 7;
            verbsRadioButton.Text = "Verbs";
            verbsRadioButton.UseVisualStyleBackColor = true;
            verbsRadioButton.CheckedChanged += VerbsRadioButton_CheckedChanged;
            // 
            // listView
            // 
            listView.Location = new Point(222, 69);
            listView.Name = "listView";
            listView.Size = new Size(750, 880);
            listView.TabIndex = 9;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(984, 24);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(93, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(107, 22);
            aboutToolStripMenuItem.Text = "&About";
            aboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 961);
            Controls.Add(listView);
            Controls.Add(showGroupBox);
            Controls.Add(phrasesWordsLabel);
            Controls.Add(letterPhrasesComboBox);
            Controls.Add(exitButton);
            Controls.Add(addButton);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            MaximizeBox = false;
            MaximumSize = new Size(1000, 1000);
            MinimumSize = new Size(1000, 1000);
            Name = "MainForm";
            Tag = "";
            Text = "Dictionary ENG to IT";
            showGroupBox.ResumeLayout(false);
            showGroupBox.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button addButton;
        private Button exitButton;
        private ComboBox letterPhrasesComboBox;
        private RadioButton allRadioButton;
        private RadioButton nounsRadioButton;
        private RadioButton adjectivesRadioButton;
        private Label phrasesWordsLabel;
        private GroupBox showGroupBox;
        private ListView listView;
        private ColumnHeader englishColumnHeader;
        private ColumnHeader italianColumnHeader;
        private RadioButton verbsRadioButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
    }
}