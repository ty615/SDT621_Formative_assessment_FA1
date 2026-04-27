using System;
using System.Windows.Forms;

namespace Question3_LanguageManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Add Language button click
        private void btnAdd_Click(object sender, EventArgs e)   // Make sure button name matches
        {
            string newLang = txtLanguage.Text.Trim();

            if (string.IsNullOrEmpty(newLang))
            {
                MessageBox.Show("Please enter a programming language.", "Empty Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // *** IMPORTANT: Change 'firstLanguages' to your ListBox's actual name ***
            foreach (var item in firstLanguages.Items)
            {
                if (item.ToString().Equals(newLang, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"'{newLang}' already exists in the list.", "Duplicate Language",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            firstLanguages.Items.Add(newLang);  // *** Change 'firstLanguages' here too ***
            txtLanguage.Clear();
            txtLanguage.Focus();

            lblDateTime.Text = $"Added '{newLang}' at {DateTime.Now:dd MMM yyyy HH:mm:ss}";
        }

        // Remove button click
        private void btnRemove_Click(object sender, EventArgs e)  // Match button name
        {
            if (firstLanguages.SelectedItem != null)   // *** Change 'firstLanguages' ***
            {
                string removed = firstLanguages.SelectedItem.ToString();
                firstLanguages.Items.Remove(firstLanguages.SelectedItem);

                lblDateTime.Text = $"Removed '{removed}' at {DateTime.Now:dd MMM yyyy HH:mm:ss}";
            }
            else
            {
                MessageBox.Show("Please select a language to remove.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Fix for CS1061: provide the event handler referenced in the designer.
        private void label1_Click(object sender, EventArgs e)
        {
            // No action required; handler present to satisfy designer wiring.
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }
    }
}