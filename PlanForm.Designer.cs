namespace GymGUI
{
    partial class PlanForm
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
            btnAdd = new Button();
            btnDelete = new Button();
            btnLoad = new Button();
            txtPrice = new TextBox();
            txtInvitations = new TextBox();
            txtDuration = new TextBox();
            txtInbody = new TextBox();
            txtFreeze = new TextBox();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 121);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(776, 331);
            dataGridView1.TabIndex = 0;
            // ADD THIS LINE INSTEAD:
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(210, 86);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(96, 29);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(312, 86);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(412, 86);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 3;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(12, 12);
            txtPrice.Name = "txtPrice";
            txtPrice.PlaceholderText = "Price";
            txtPrice.Size = new Size(125, 27);
            txtPrice.TabIndex = 4;
            // 
            // txtInvitations
            // 
            txtInvitations.Location = new Point(153, 12);
            txtInvitations.Name = "txtInvitations";
            txtInvitations.PlaceholderText = "Invitations";
            txtInvitations.Size = new Size(125, 27);
            txtInvitations.TabIndex = 5;
            // 
            // txtDuration
            // 
            txtDuration.Location = new Point(299, 12);
            txtDuration.Name = "txtDuration";
            txtDuration.PlaceholderText = "Duration";
            txtDuration.Size = new Size(125, 27);
            txtDuration.TabIndex = 6;
            // 
            // txtInbody
            // 
            txtInbody.Location = new Point(449, 12);
            txtInbody.Name = "txtInbody";
            txtInbody.PlaceholderText = "Inbody";
            txtInbody.Size = new Size(125, 27);
            txtInbody.TabIndex = 7;
            // 
            // txtFreeze
            // 
            txtFreeze.Location = new Point(597, 12);
            txtFreeze.Name = "txtFreeze";
            txtFreeze.PlaceholderText = "Freeze";
            txtFreeze.Size = new Size(125, 27);
            txtFreeze.TabIndex = 8;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(693, 86);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(69, 28);
            btnBack.TabIndex = 9;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // PlanForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(txtFreeze);
            Controls.Add(txtInbody);
            Controls.Add(txtDuration);
            Controls.Add(txtInvitations);
            Controls.Add(txtPrice);
            Controls.Add(btnLoad);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(dataGridView1);
            Name = "PlanForm";
            Text = "PlanForm";
            Load += PlanForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnLoad;
        private TextBox txtPrice;
        private TextBox txtInvitations;
        private TextBox txtDuration;
        private TextBox txtInbody;
        private TextBox txtFreeze;
        private Button btnBack;
    }
}