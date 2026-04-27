using System.Windows.Forms;

namespace SectionB_Question2_HomeAffairs
{
    partial class Form1 : Form
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
            lblTitle = new Label();
            lblName = new Label();
            txtName = new TextBox();
            lblID = new Label();
            txtID = new TextBox();
            label1 = new Label();
            cmbCitizenship = new ComboBox();
            btnValidate = new Button();
            btnGenerate = new Button();
            txtResults = new TextBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkGreen;
            lblTitle.Location = new Point(270, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(435, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Home Affairs Digital identity Processor\r\n";
            lblTitle.UseWaitCursor = true;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(252, 54);
            lblName.Name = "lblName";
            lblName.Size = new Size(132, 20);
            lblName.TabIndex = 1;
            lblName.Text = "Enter your Name:\r\n";
            lblName.UseWaitCursor = true;
            // 
            // txtName
            // 
            txtName.Location = new Point(455, 54);
            txtName.Name = "txtName";
            txtName.Size = new Size(250, 27);
            txtName.TabIndex = 2;
            txtName.UseWaitCursor = true;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblID.Location = new Point(252, 97);
            lblID.Name = "lblID";
            lblID.Size = new Size(106, 20);
            lblID.TabIndex = 3;
            lblID.Text = "Enter your ID:";
            lblID.UseWaitCursor = true;
            // 
            // txtID
            // 
            txtID.Location = new Point(455, 97);
            txtID.MaxLength = 13;
            txtID.Name = "txtID";
            txtID.Size = new Size(250, 27);
            txtID.TabIndex = 4;
            txtID.UseWaitCursor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(252, 138);
            label1.Name = "label1";
            label1.Size = new Size(180, 20);
            label1.TabIndex = 5;
            label1.Text = "Choose your Citizenship:\r\n";
            label1.UseWaitCursor = true;
            // 
            // cmbCitizenship
            // 
            cmbCitizenship.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCitizenship.FormattingEnabled = true;
            cmbCitizenship.Items.AddRange(new object[] { "Citizen ", "Permemanet Resident", "Vistitor" });
            cmbCitizenship.Location = new Point(455, 135);
            cmbCitizenship.Name = "cmbCitizenship";
            cmbCitizenship.Size = new Size(200, 28);
            cmbCitizenship.TabIndex = 6;
            cmbCitizenship.UseWaitCursor = true;
            // 
            // btnValidate
            // 
            btnValidate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnValidate.Location = new Point(455, 178);
            btnValidate.Name = "btnValidate";
            btnValidate.Size = new Size(100, 35);
            btnValidate.TabIndex = 7;
            btnValidate.Text = "Validate  ID\r\n";
            btnValidate.UseVisualStyleBackColor = true;
            btnValidate.UseWaitCursor = true;
            btnValidate.Click += btnValidate_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerate.Location = new Point(444, 479);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(130, 35);
            btnGenerate.TabIndex = 8;
            btnGenerate.Text = "Generate  Proflie";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.UseWaitCursor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // txtResults
            // 
            txtResults.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtResults.Location = new Point(342, 273);
            txtResults.Multiline = true;
            txtResults.Name = "txtResults";
            txtResults.ReadOnly = true;
            txtResults.ScrollBars = ScrollBars.Vertical;
            txtResults.Size = new Size(400, 200);
            txtResults.TabIndex = 9;
            txtResults.UseWaitCursor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSalmon;
            ClientSize = new Size(754, 526);
            Controls.Add(txtResults);
            Controls.Add(btnGenerate);
            Controls.Add(btnValidate);
            Controls.Add(cmbCitizenship);
            Controls.Add(label1);
            Controls.Add(txtID);
            Controls.Add(lblID);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home Affairs Digital Identity  Processor";
            UseWaitCursor = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblName;
        private TextBox txtName;
        private Label lblID;
        private TextBox txtID;
        private Label label1;
        private ComboBox cmbCitizenship;
        private Button btnValidate;
        private Button btnGenerate;
        private TextBox txtResults;
    }
}
