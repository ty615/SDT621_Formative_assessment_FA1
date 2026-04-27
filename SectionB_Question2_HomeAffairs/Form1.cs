using System;
using System.Windows.Forms;

namespace SectionB_Question2_HomeAffairs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set default ComboBox selection
            cmbCitizenship.SelectedIndex = 0;
        }

        // Validate ID button
        private void btnValidate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string id = txtID.Text.Trim();
            string citizenship = cmbCitizenship.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrEmpty(name))
            {
                txtResults.Text = "ERROR: Please enter a name.";
                txtResults.BackColor = System.Drawing.Color.LightCoral;
                return;
            }
            if (string.IsNullOrEmpty(id))
            {
                txtResults.Text = "ERROR: Please enter an ID number.";
                txtResults.BackColor = System.Drawing.Color.LightCoral;
                return;
            }
            if (string.IsNullOrEmpty(citizenship))
            {
                txtResults.Text = "ERROR: Please select a citizenship status.";
                txtResults.BackColor = System.Drawing.Color.LightCoral;
                return;
            }

            CitizenProfile profile = new CitizenProfile(name, id, citizenship);
            string validationMsg = profile.ValidateID();

            // Clear any error background
            txtResults.BackColor = System.Drawing.Color.White;

            txtResults.Text = $"VALIDATION RESULT:\n{validationMsg}\n\n";
            txtResults.AppendText($"Name: {name}\n");
            txtResults.AppendText($"ID: {id}\n");
            txtResults.AppendText($"Age: {profile.Age} years\n");
            txtResults.AppendText($"Citizenship: {citizenship}");
        }

        // Generate Profile button
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string id = txtID.Text.Trim();
            string citizenship = cmbCitizenship.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrEmpty(name))
            {
                txtResults.Text = "ERROR: Please enter a name.";
                return;
            }
            if (string.IsNullOrEmpty(id))
            {
                txtResults.Text = "ERROR: Please enter an ID number.";
                return;
            }
            if (string.IsNullOrEmpty(citizenship))
            {
                txtResults.Text = "ERROR: Please select a citizenship status.";
                return;
            }

            CitizenProfile profile = new CitizenProfile(name, id, citizenship);
            string validationMsg = profile.ValidateID();
            DateTime now = DateTime.Now;

            string fullProfile = profile.GenerateProfileSummary(validationMsg, now);
            txtResults.Text = fullProfile;
            txtResults.BackColor = System.Drawing.Color.White;
        }
    }
}