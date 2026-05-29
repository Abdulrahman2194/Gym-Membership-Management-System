namespace GymGUI
{
    partial class TrainerForm
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
            dataGridView1 = new DataGridView();
            txtFName = new TextBox();
            txtLName = new TextBox();
            txtPhone = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            btnLoad = new Button();
            btnUpdate = new Button();
            btnBack = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.LavenderBlush;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 107);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(961, 331);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // txtFName
            // 
            txtFName.BackColor = Color.DarkGray;
            txtFName.Location = new Point(12, 1);
            txtFName.Name = "txtFName";
            txtFName.PlaceholderText = "First Name";
            txtFName.Size = new Size(125, 27);
            txtFName.TabIndex = 1;
            // 
            // txtLName
            // 
            txtLName.BackColor = Color.DarkGray;
            txtLName.Location = new Point(12, 34);
            txtLName.Name = "txtLName";
            txtLName.PlaceholderText = "Last Name";
            txtLName.Size = new Size(125, 27);
            txtLName.TabIndex = 2;
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.DarkGray;
            txtPhone.Location = new Point(12, 67);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Phone Number";
            txtPhone.Size = new Size(125, 27);
            txtPhone.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.ActiveCaption;
            btnAdd.Location = new Point(229, 73);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.ActiveCaption;
            btnDelete.Location = new Point(329, 73);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = SystemColors.ActiveCaption;
            btnLoad.ForeColor = SystemColors.InactiveCaptionText;
            btnLoad.Location = new Point(429, 72);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 6;
            btnLoad.Text = "View";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(229, 12);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(329, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 8;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(484, 14);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Type here to search...";
            txtSearch.Size = new Size(176, 27);
            txtSearch.TabIndex = 10;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(698, 14);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 11;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // TrainerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GrayText;
            ClientSize = new Size(985, 450);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnBack);
            Controls.Add(btnUpdate);
            Controls.Add(btnLoad);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(txtPhone);
            Controls.Add(txtLName);
            Controls.Add(txtFName);
            Controls.Add(dataGridView1);
            ForeColor = Color.Black;
            Name = "TrainerForm";
            Text = "TrainerForm";
            Load += TrainerForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtFName;
        private TextBox txtLName;
        private TextBox txtPhone;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnLoad;
        private Button btnUpdate;
        private Button btnBack;
        private TextBox txtSearch;
        private Button btnSearch;
    }
}