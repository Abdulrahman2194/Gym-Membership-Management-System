using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace GymGUI
{
    partial class Nutrition
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
            btnViewAll = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dgvNutrition = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtNFname = new TextBox();
            txtNLname = new TextBox();
            txtNPN = new TextBox();
            btnBack = new Button();
            cmbFirstName = new ComboBox();
            cmbLastName = new ComboBox();
            cmbPhone = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnViewFirstName = new Button();
            btnViewLastName = new Button();
            btnViewPhone = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvNutrition).BeginInit();
            SuspendLayout();
            // 
            // btnViewAll
            // 
            btnViewAll.Location = new Point(535, 310);
            btnViewAll.Name = "btnViewAll";
            btnViewAll.Size = new Size(211, 29);
            btnViewAll.TabIndex = 0;
            btnViewAll.Text = "View All";
            btnViewAll.UseVisualStyleBackColor = true;
            btnViewAll.Click += Nutrition_Load_1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(101, 310);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(211, 29);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add Nutritionist";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(318, 310);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(211, 29);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete Nutritionist";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(1, 310);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear Fields";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // dgvNutrition
            // 
            dgvNutrition.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNutrition.Location = new Point(1, 345);
            dgvNutrition.Name = "dgvNutrition";
            dgvNutrition.RowHeadersWidth = 51;
            dgvNutrition.Size = new Size(923, 194);
            dgvNutrition.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 8);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 7;
            label1.Text = "First Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 41);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 8;
            label2.Text = "Last Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 78);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 9;
            label3.Text = "Phone:";
            // 
            // txtNFname
            // 
            txtNFname.Location = new Point(222, 8);
            txtNFname.Name = "txtNFname";
            txtNFname.PlaceholderText = "Enter Your First Name";
            txtNFname.Size = new Size(194, 27);
            txtNFname.TabIndex = 11;
            // 
            // txtNLname
            // 
            txtNLname.Location = new Point(222, 41);
            txtNLname.Name = "txtNLname";
            txtNLname.PlaceholderText = "Enter Your Last Name";
            txtNLname.Size = new Size(194, 27);
            txtNLname.TabIndex = 12;
            // 
            // txtNPN
            // 
            txtNPN.Location = new Point(222, 78);
            txtNPN.Name = "txtNPN";
            txtNPN.PlaceholderText = "Enter Your Phone Number";
            txtNPN.Size = new Size(194, 27);
            txtNPN.TabIndex = 13;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(821, 310);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 14;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // cmbFirstName
            // 
            cmbFirstName.FormattingEnabled = true;
            cmbFirstName.Location = new Point(12, 133);
            cmbFirstName.Name = "cmbFirstName";
            cmbFirstName.Size = new Size(177, 28);
            cmbFirstName.TabIndex = 15;
            // 
            // cmbLastName
            // 
            cmbLastName.FormattingEnabled = true;
            cmbLastName.Location = new Point(12, 187);
            cmbLastName.Name = "cmbLastName";
            cmbLastName.Size = new Size(177, 28);
            cmbLastName.TabIndex = 15;
            // 
            // cmbPhone
            // 
            cmbPhone.FormattingEnabled = true;
            cmbPhone.Location = new Point(12, 241);
            cmbPhone.Name = "cmbPhone";
            cmbPhone.Size = new Size(177, 28);
            cmbPhone.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 110);
            label4.Name = "label4";
            label4.Size = new Size(120, 20);
            label4.TabIndex = 16;
            label4.Text = "FirstNameSearch";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 164);
            label5.Name = "label5";
            label5.Size = new Size(119, 20);
            label5.TabIndex = 16;
            label5.Text = "LastNameSearch";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 218);
            label6.Name = "label6";
            label6.Size = new Size(94, 20);
            label6.TabIndex = 16;
            label6.Text = "PhoneSearch";
            // 
            // btnViewFirstName
            // 
            btnViewFirstName.Location = new Point(222, 132);
            btnViewFirstName.Name = "btnViewFirstName";
            btnViewFirstName.Size = new Size(184, 29);
            btnViewFirstName.TabIndex = 17;
            btnViewFirstName.Text = "View By First Name";
            btnViewFirstName.UseVisualStyleBackColor = true;
            btnViewFirstName.Click += btnViewFirstName_Click;
            // 
            // btnViewLastName
            // 
            btnViewLastName.Location = new Point(222, 187);
            btnViewLastName.Name = "btnViewLastName";
            btnViewLastName.Size = new Size(184, 28);
            btnViewLastName.TabIndex = 18;
            btnViewLastName.Text = "View By Last Name";
            btnViewLastName.UseVisualStyleBackColor = true;
            btnViewLastName.Click += btnViewLastName_Click;
            // 
            // btnViewPhone
            // 
            btnViewPhone.Location = new Point(222, 240);
            btnViewPhone.Name = "btnViewPhone";
            btnViewPhone.Size = new Size(184, 29);
            btnViewPhone.TabIndex = 19;
            btnViewPhone.Text = "View By Phone";
            btnViewPhone.UseVisualStyleBackColor = true;
            btnViewPhone.Click += btnViewPhone_Click;
            // 
            // Nutrition
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 551);
            Controls.Add(btnViewPhone);
            Controls.Add(btnViewLastName);
            Controls.Add(btnViewFirstName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(cmbPhone);
            Controls.Add(cmbLastName);
            Controls.Add(cmbFirstName);
            Controls.Add(btnBack);
            Controls.Add(txtNPN);
            Controls.Add(txtNLname);
            Controls.Add(txtNFname);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvNutrition);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnViewAll);
            Name = "Nutrition";
            Text = "Nutrition";
            Load += Nutrition_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvNutrition).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnViewAll;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvNutrition;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNFname;
        private TextBox txtNLname;
        private TextBox txtNPN;
        private Button btnBack;
        private ComboBox cmbFirstName;
        private ComboBox cmbLastName;
        private ComboBox cmbPhone;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnViewFirstName;
        private Button btnViewLastName;
        private Button btnViewPhone;
    }
}