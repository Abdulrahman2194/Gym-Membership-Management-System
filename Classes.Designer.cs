using System.Drawing;
using System.Windows.Forms;

namespace GymGUI
{
    partial class Classes : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnLoadAll = new Button();
            btnViewByPlan = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            cmbPlanID = new ComboBox();
            txtClassName = new TextBox();
            txtCapacity = new TextBox();
            dgvClasses = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cmbName = new TextBox();
            cmbCapacity = new TextBox();
            label4 = new Label();
            label5 = new Label();
            btnViewByCapacity = new Button();
            btnViewByName = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClasses).BeginInit();
            SuspendLayout();
            // 
            // btnLoadAll
            // 
            btnLoadAll.Location = new Point(622, 323);
            btnLoadAll.Name = "btnLoadAll";
            btnLoadAll.Size = new Size(190, 30);
            btnLoadAll.TabIndex = 3;
            btnLoadAll.Text = "View All";
            btnLoadAll.UseVisualStyleBackColor = true;
            // 
            // btnViewByPlan
            // 
            btnViewByPlan.Location = new Point(214, 32);
            btnViewByPlan.Name = "btnViewByPlan";
            btnViewByPlan.Size = new Size(190, 30);
            btnViewByPlan.TabIndex = 2;
            btnViewByPlan.Text = "View By Plan";
            btnViewByPlan.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 323);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(190, 30);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add Class";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(214, 323);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(190, 30);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete Class";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(416, 323);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(190, 30);
            btnClear.TabIndex = 10;
            btnClear.Text = "Clear Fields";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // cmbPlanID
            // 
            cmbPlanID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPlanID.Location = new Point(12, 32);
            cmbPlanID.Name = "cmbPlanID";
            cmbPlanID.Size = new Size(190, 28);
            cmbPlanID.TabIndex = 1;
            // 
            // txtClassName
            // 
            txtClassName.Location = new Point(12, 223);
            txtClassName.Name = "txtClassName";
            txtClassName.Size = new Size(190, 27);
            txtClassName.TabIndex = 5;
            // 
            // txtCapacity
            // 
            txtCapacity.Location = new Point(12, 283);
            txtCapacity.Name = "txtCapacity";
            txtCapacity.Size = new Size(190, 27);
            txtCapacity.TabIndex = 7;
            // 
            // dgvClasses
            // 
            dgvClasses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClasses.Location = new Point(12, 359);
            dgvClasses.MultiSelect = false;
            dgvClasses.Name = "dgvClasses";
            dgvClasses.ReadOnly = true;
            dgvClasses.RowHeadersWidth = 51;
            dgvClasses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClasses.Size = new Size(845, 247);
            dgvClasses.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(56, 20);
            label1.TabIndex = 0;
            label1.Text = "Plan ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 200);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 4;
            label2.Text = "Class Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 260);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 6;
            label3.Text = "Capacity";
            // 
            // cmbName
            // 
            cmbName.Location = new Point(12, 97);
            cmbName.Name = "cmbName";
            cmbName.Size = new Size(190, 27);
            cmbName.TabIndex = 12;
            // 
            // cmbCapacity
            // 
            cmbCapacity.Location = new Point(12, 155);
            cmbCapacity.Name = "cmbCapacity";
            cmbCapacity.Size = new Size(190, 27);
            cmbCapacity.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 74);
            label4.Name = "label4";
            label4.Size = new Size(93, 20);
            label4.TabIndex = 0;
            label4.Text = "NameSearch";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 132);
            label5.Name = "label5";
            label5.Size = new Size(110, 20);
            label5.TabIndex = 0;
            label5.Text = "CapacitySearch";
            // 
            // btnViewByCapacity
            // 
            btnViewByCapacity.Location = new Point(214, 155);
            btnViewByCapacity.Name = "btnViewByCapacity";
            btnViewByCapacity.Size = new Size(190, 30);
            btnViewByCapacity.TabIndex = 2;
            btnViewByCapacity.Text = "View By Capacity";
            btnViewByCapacity.UseVisualStyleBackColor = true;
            // 
            // btnViewByName
            // 
            btnViewByName.Location = new Point(214, 97);
            btnViewByName.Name = "btnViewByName";
            btnViewByName.Size = new Size(190, 30);
            btnViewByName.TabIndex = 2;
            btnViewByName.Text = "View By Name";
            btnViewByName.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(11, 612);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 14;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // Classes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1353, 643);
            Controls.Add(btnBack);
            Controls.Add(cmbCapacity);
            Controls.Add(cmbName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(cmbPlanID);
            Controls.Add(btnViewByName);
            Controls.Add(btnViewByCapacity);
            Controls.Add(btnViewByPlan);
            Controls.Add(btnLoadAll);
            Controls.Add(label2);
            Controls.Add(txtClassName);
            Controls.Add(label3);
            Controls.Add(txtCapacity);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(dgvClasses);
            Name = "Classes";
            Text = "Classes Page";
            Load += Classes_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvClasses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnLoadAll;
        private Button btnViewByPlan;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnClear;
        private ComboBox cmbPlanID;
        private TextBox txtClassName;
        private TextBox txtCapacity;
        private DataGridView dgvClasses;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox cmbName;
        private TextBox cmbCapacity;
        private Label label4;
        private Label label5;
        private Button btnViewByCapacity;
        private Button btnViewByName;
        private Button btnBack;
    }
}