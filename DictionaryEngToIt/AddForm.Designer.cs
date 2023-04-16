namespace DictionaryEngToIt
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            addGroupBox = new GroupBox();
            phraseRadioButton = new RadioButton();
            nounRadioButton = new RadioButton();
            adjectiveRadioButton = new RadioButton();
            englishRichTextBox = new RichTextBox();
            englishLabel = new Label();
            italianLabel = new Label();
            italianRichTextBox = new RichTextBox();
            cancelButton = new Button();
            okButton = new Button();
            verbRadioButton = new RadioButton();
            addGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // addGroupBox
            // 
            addGroupBox.Controls.Add(verbRadioButton);
            addGroupBox.Controls.Add(phraseRadioButton);
            addGroupBox.Controls.Add(nounRadioButton);
            addGroupBox.Controls.Add(adjectiveRadioButton);
            addGroupBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            addGroupBox.Location = new Point(30, 40);
            addGroupBox.Margin = new Padding(4);
            addGroupBox.Name = "addGroupBox";
            addGroupBox.Padding = new Padding(4);
            addGroupBox.Size = new Size(180, 230);
            addGroupBox.TabIndex = 9;
            addGroupBox.TabStop = false;
            addGroupBox.Text = "What to add:";
            // 
            // phraseRadioButton
            // 
            phraseRadioButton.AutoSize = true;
            phraseRadioButton.Checked = true;
            phraseRadioButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            phraseRadioButton.Location = new Point(8, 30);
            phraseRadioButton.Margin = new Padding(4);
            phraseRadioButton.Name = "phraseRadioButton";
            phraseRadioButton.Size = new Size(75, 25);
            phraseRadioButton.TabIndex = 4;
            phraseRadioButton.TabStop = true;
            phraseRadioButton.Text = "Phrase";
            phraseRadioButton.UseVisualStyleBackColor = true;
            // 
            // nounRadioButton
            // 
            nounRadioButton.AutoSize = true;
            nounRadioButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            nounRadioButton.Location = new Point(8, 80);
            nounRadioButton.Margin = new Padding(4);
            nounRadioButton.Name = "nounRadioButton";
            nounRadioButton.Size = new Size(67, 25);
            nounRadioButton.TabIndex = 5;
            nounRadioButton.Text = "Noun";
            nounRadioButton.UseVisualStyleBackColor = true;
            // 
            // adjectiveRadioButton
            // 
            adjectiveRadioButton.AutoSize = true;
            adjectiveRadioButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            adjectiveRadioButton.Location = new Point(8, 130);
            adjectiveRadioButton.Margin = new Padding(4);
            adjectiveRadioButton.Name = "adjectiveRadioButton";
            adjectiveRadioButton.Size = new Size(91, 25);
            adjectiveRadioButton.TabIndex = 6;
            adjectiveRadioButton.Text = "Adjective";
            adjectiveRadioButton.UseVisualStyleBackColor = true;
            // 
            // englishRichTextBox
            // 
            englishRichTextBox.Location = new Point(240, 70);
            englishRichTextBox.Margin = new Padding(4);
            englishRichTextBox.Name = "englishRichTextBox";
            englishRichTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            englishRichTextBox.Size = new Size(350, 150);
            englishRichTextBox.TabIndex = 10;
            englishRichTextBox.Text = "";
            // 
            // englishLabel
            // 
            englishLabel.AutoSize = true;
            englishLabel.Location = new Point(240, 38);
            englishLabel.Margin = new Padding(4, 0, 4, 0);
            englishLabel.Name = "englishLabel";
            englishLabel.Size = new Size(60, 21);
            englishLabel.TabIndex = 12;
            englishLabel.Text = "English";
            // 
            // italianLabel
            // 
            italianLabel.AutoSize = true;
            italianLabel.Location = new Point(610, 38);
            italianLabel.Margin = new Padding(4, 0, 4, 0);
            italianLabel.Name = "italianLabel";
            italianLabel.Size = new Size(52, 21);
            italianLabel.TabIndex = 14;
            italianLabel.Text = "Italian";
            // 
            // italianRichTextBox
            // 
            italianRichTextBox.Location = new Point(610, 69);
            italianRichTextBox.Margin = new Padding(4);
            italianRichTextBox.Name = "italianRichTextBox";
            italianRichTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            italianRichTextBox.Size = new Size(350, 150);
            italianRichTextBox.TabIndex = 13;
            italianRichTextBox.Text = "";
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(748, 254);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(103, 35);
            cancelButton.TabIndex = 15;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButton_Click;
            // 
            // okButton
            // 
            okButton.Location = new Point(857, 254);
            okButton.Name = "okButton";
            okButton.Size = new Size(103, 35);
            okButton.TabIndex = 16;
            okButton.Text = "Ok";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += OkButton_Click;
            // 
            // verbRadioButton
            // 
            verbRadioButton.AutoSize = true;
            verbRadioButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            verbRadioButton.Location = new Point(8, 180);
            verbRadioButton.Margin = new Padding(4);
            verbRadioButton.Name = "verbRadioButton";
            verbRadioButton.Size = new Size(60, 25);
            verbRadioButton.TabIndex = 7;
            verbRadioButton.Text = "Verb";
            verbRadioButton.UseVisualStyleBackColor = true;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 311);
            Controls.Add(okButton);
            Controls.Add(cancelButton);
            Controls.Add(italianLabel);
            Controls.Add(italianRichTextBox);
            Controls.Add(englishLabel);
            Controls.Add(englishRichTextBox);
            Controls.Add(addGroupBox);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            MaximizeBox = false;
            MaximumSize = new Size(1000, 350);
            MinimumSize = new Size(1000, 350);
            Name = "AddForm";
            Text = "Add to Dictionary";
            addGroupBox.ResumeLayout(false);
            addGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox addGroupBox;
        private RadioButton phraseRadioButton;
        private RadioButton nounRadioButton;
        private RadioButton adjectiveRadioButton;
        private RichTextBox englishRichTextBox;
        private RichTextBox italianRichTextBox;
        private Label englishLabel;
        private Label italianLabel;
        private Button cancelButton;
        private Button okButton;
        private RadioButton verbRadioButton;
    }
}