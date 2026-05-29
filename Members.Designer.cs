using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace GymGUI
{
    partial class Members
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
            dgvMembers = new DataGridView();
            txtFName = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            txtLName = new TextBox();
            btnView = new Button();
            txtEmail = new TextBox();
            btnClear = new Button();
            cmbGender = new ComboBox();
            cmbTrainer = new ComboBox();
            cmbPlan = new ComboBox();
            cmbNutrition = new ComboBox();
            dtpRegDate = new DateTimePicker();
            dtpBirthDate = new DateTimePicker();
            btnUpdate = new Button();
            label1 = new Label();
            label2 = new Label();
            btnBack = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).BeginInit();
            SuspendLayout();
            // 
            // dgvMembers
            // 
            dgvMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMembers.Location = new Point(12, 200);
            dgvMembers.Name = "dgvMembers";
            dgvMembers.RowHeadersWidth = 51;
            dgvMembers.Size = new Size(1002, 271);
            dgvMembers.TabIndex = 0;
            dgvMembers.CellClick += dgvMembers_CellClick;
            // 
            // txtFName
            // 
            txtFName.Location = new Point(12, 35);
            txtFName.Name = "txtFName";
            txtFName.PlaceholderText = "Enter Your First Name";
            txtFName.Size = new Size(190, 27);
            txtFName.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(25, 165);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(143, 165);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtLName
            // 
            txtLName.Location = new Point(12, 74);
            txtLName.Name = "txtLName";
            txtLName.PlaceholderText = "Enter Your Second Name";
            txtLName.Size = new Size(190, 27);
            txtLName.TabIndex = 3;
            // 
            // btnView
            // 
            btnView.Location = new Point(258, 165);
            btnView.Name = "btnView";
            btnView.Size = new Size(94, 29);
            btnView.TabIndex = 5;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click_1;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 118);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Enter Your Email";
            txtEmail.Size = new Size(190, 27);
            txtEmail.TabIndex = 6;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(385, 165);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // cmbGender
            // 
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Male ", "Female" });
            cmbGender.Location = new Point(322, 35);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(151, 28);
            cmbGender.TabIndex = 8;
            cmbGender.Text = "Gender";
            // 
            // cmbTrainer
            // 
            cmbTrainer.FormattingEnabled = true;
            cmbTrainer.Location = new Point(502, 35);
            cmbTrainer.Name = "cmbTrainer";
            cmbTrainer.Size = new Size(151, 28);
            cmbTrainer.TabIndex = 9;
            cmbTrainer.Text = "Trainer";
            // 
            // cmbPlan
            // 
            cmbPlan.FormattingEnabled = true;
            cmbPlan.Location = new Point(853, 35);
            cmbPlan.Name = "cmbPlan";
            cmbPlan.Size = new Size(151, 28);
            cmbPlan.TabIndex = 11;
            cmbPlan.Text = "Plan";
            // 
            // cmbNutrition
            // 
            cmbNutrition.FormattingEnabled = true;
            cmbNutrition.Location = new Point(678, 35);
            cmbNutrition.Name = "cmbNutrition";
            cmbNutrition.Size = new Size(151, 28);
            cmbNutrition.TabIndex = 10;
            cmbNutrition.Text = "Nutrition";
            // 
            // dtpRegDate
            // 
            dtpRegDate.Location = new Point(579, 101);
            dtpRegDate.MaxDate = new DateTime(2250, 12, 31, 0, 0, 0, 0);
            dtpRegDate.Name = "dtpRegDate";
            dtpRegDate.Size = new Size(250, 27);
            dtpRegDate.TabIndex = 12;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(579, 134);
            dtpBirthDate.MaxDate = new DateTime(2250, 12, 31, 0, 0, 0, 0);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(250, 27);
            dtpBirthDate.TabIndex = 13;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(502, 165);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(423, 106);
            label1.Name = "label1";
            label1.Size = new Size(131, 20);
            label1.TabIndex = 15;
            label1.Text = "Registeration date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(469, 136);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 16;
            label2.Text = "Birth date";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(920, 165);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 17;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(258, 130);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 18;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(208, 97);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Type here to Search..";
            txtSearch.Size = new Size(197, 27);
            txtSearch.TabIndex = 19;
            // 
            // Members
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1026, 483);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnBack);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnUpdate);
            Controls.Add(dtpBirthDate);
            Controls.Add(dtpRegDate);
            Controls.Add(cmbPlan);
            Controls.Add(cmbNutrition);
            Controls.Add(cmbTrainer);
            Controls.Add(cmbGender);
            Controls.Add(btnClear);
            Controls.Add(txtEmail);
            Controls.Add(btnView);
            Controls.Add(btnDelete);
            Controls.Add(txtLName);
            Controls.Add(btnAdd);
            Controls.Add(txtFName);
            Controls.Add(dgvMembers);
            Name = "Members";
            Text = "Members";
            Load += Members_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMembers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMembers;
        private TextBox txtFName;
        private Button btnAdd;
        private Button btnDelete;
        private TextBox txtLName;
        private Button btnView;
        private TextBox txtEmail;
        private Button btnClear;
        private ComboBox cmbGender;
        private ComboBox cmbTrainer;
        private ComboBox cmbPlan;
        private ComboBox cmbNutrition;
        private DateTimePicker dtpRegDate;
        private DateTimePicker dtpBirthDate;
        private Button btnUpdate;
        private Label label1;
        private Label label2;
        private Button btnBack;
        private Button btnSearch;
        private TextBox txtSearch;
    }
}