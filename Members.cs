using System;
using System.Data;
using System.Drawing;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace GymGUI

{


    public partial class Members : Form
    {
        SqlConnection con = new SqlConnection(
    @"Data Source=.;Initial Catalog=GymMembership;Integrated Security=True;TrustServerCertificate=True"
     );

        public Members()
        {
            InitializeComponent();
        }
        int selectedMemberID = -1;
        void StyleDatePicker(DateTimePicker dtp)
        {
            dtp.CalendarMonthBackground = Color.FromArgb(25, 25, 25);
            dtp.CalendarForeColor = Color.Goldenrod;
            dtp.CalendarTitleBackColor = Color.Goldenrod;
            dtp.CalendarTitleForeColor = Color.Black;
            dtp.CalendarTrailingForeColor = Color.Gray;
            dtp.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter(@"
        SELECT 
            MemberID,
            register_startdate,
            birthdate,
            MFname,
            MLname,
            Email,
            gender,
            T_ID,
            planID,
            N_ID
        FROM membr
        WHERE MFname LIKE @search
           OR MLname LIKE @search
           OR Email LIKE @search
           OR gender LIKE @search
           OR CAST(MemberID AS VARCHAR) LIKE @search", con);

            da.SelectCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvMembers.DataSource = dt;
        }
        private void Members_Load(object sender, EventArgs e)
        {
            ApplyStyle();

            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTrainer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNutrition.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPlan.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbGender.Items.Clear();
            cmbGender.Items.Add("Male");
            cmbGender.Items.Add("Female");
            cmbGender.SelectedIndex = -1;
            StyleDatePicker(dtpRegDate);
            StyleDatePicker(dtpBirthDate);
            StyleButton(btnSearch);
            StyleTextBox(txtSearch);


            StyleButton(btnUpdate);

            LoadTrainers();
            LoadNutrition();
            LoadPlans();
            ViewMembers();
        }
        private void dgvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvMembers.Rows[e.RowIndex];

            selectedMemberID = Convert.ToInt32(row.Cells["MemberID"].Value);

            txtFName.Text = row.Cells["MFname"].Value.ToString();
            txtLName.Text = row.Cells["MLname"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            cmbGender.Text = row.Cells["gender"].Value.ToString();

            cmbTrainer.SelectedValue = Convert.ToInt32(row.Cells["T_ID"].Value);
            cmbPlan.SelectedValue = Convert.ToInt32(row.Cells["planID"].Value);
            cmbNutrition.SelectedValue = Convert.ToInt32(row.Cells["N_ID"].Value);

            dtpRegDate.Value = Convert.ToDateTime(row.Cells["register_startdate"].Value);
            dtpBirthDate.Value = Convert.ToDateTime(row.Cells["birthdate"].Value);
        }
        void ViewMembers()
        {
            SqlDataAdapter da = new SqlDataAdapter(@"
                SELECT 
                    MemberID,
                    register_startdate,
                    birthdate,
                    MFname,
                    MLname,
                    Email,
                    gender,
                    T_ID,
                    planID,
                    N_ID
                FROM membr", con);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvMembers.DataSource = dt;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedMemberID == -1)
            {
                MessageBox.Show("Please select a member first", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. UPDATED VALIDATION
            if (string.IsNullOrWhiteSpace(txtFName.Text) ||
                string.IsNullOrWhiteSpace(txtLName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                cmbGender.SelectedIndex == -1 ||
                cmbPlan.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand(@"
            UPDATE membr
            SET register_startdate = @reg,
                birthdate = @birth,
                MFname = @f,
                MLname = @l,
                Email = @email,
                gender = @gender,
                T_ID = @trainer,
                planID = @plan,
                N_ID = @nutrition
            WHERE MemberID = @id", con);

                int selectedTrainer = cmbTrainer.SelectedIndex == -1 ? 0 : Convert.ToInt32(cmbTrainer.SelectedValue);
                int selectedNutrition = cmbNutrition.SelectedIndex == -1 ? 0 : Convert.ToInt32(cmbNutrition.SelectedValue);

                cmd.Parameters.AddWithValue("@reg", dtpRegDate.Value.Date);
                cmd.Parameters.AddWithValue("@birth", dtpBirthDate.Value.Date);
                cmd.Parameters.AddWithValue("@f", txtFName.Text);
                cmd.Parameters.AddWithValue("@l", txtLName.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@gender", cmbGender.Text);
                cmd.Parameters.AddWithValue("@plan", cmbPlan.SelectedValue);
                cmd.Parameters.AddWithValue("@id", selectedMemberID);

                // Add the safe defaults here
                cmd.Parameters.AddWithValue("@trainer", selectedTrainer);
                cmd.Parameters.AddWithValue("@nutrition", selectedNutrition);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Member updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ViewMembers();
                ClearFields();
            }
            catch (SqlException ex)
            {
                con.Close();

                if (ex.Number == 2627 || ex.Number == 2601)
                    MessageBox.Show("This email already exists", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void LoadTrainers()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT trainerID, TFname + ' ' + TLname AS TrainerName FROM Trainer", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbTrainer.DataSource = null;
                cmbTrainer.DataSource = dt;
                cmbTrainer.DisplayMember = "TrainerName";
                cmbTrainer.ValueMember = "trainerID";
                cmbTrainer.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Trainer dropdown error: " + ex.Message);
            }
        }

        void LoadNutrition()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT N_ID, NFname + ' ' + NLname AS NutritionName FROM Nutrition", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbNutrition.DataSource = dt;
            cmbNutrition.DisplayMember = "NutritionName";
            cmbNutrition.ValueMember = "N_ID";
            cmbNutrition.SelectedIndex = -1;
        }

        void LoadPlans()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT planID, 'Plan ' + CAST(planID AS VARCHAR) + ' - ' + CAST(price AS VARCHAR) AS PlanName FROM SubscriptionPlan", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbPlan.DataSource = dt;
            cmbPlan.DisplayMember = "PlanName";
            cmbPlan.ValueMember = "planID";
            cmbPlan.SelectedIndex = -1;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ViewMembers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 1. UPDATED VALIDATION (Removed Trainer and Nutrition checks)
            if (string.IsNullOrWhiteSpace(txtFName.Text) ||
                string.IsNullOrWhiteSpace(txtLName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                cmbGender.SelectedIndex == -1 ||
                cmbPlan.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all required fields (Name, Email, Gender, Plan)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("AddMember", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // 2. SAFE DEFAULTS: If they don't select anything (-1), it defaults to 0 ("No Trainer")
                int selectedTrainer = cmbTrainer.SelectedIndex == -1 ? 0 : Convert.ToInt32(cmbTrainer.SelectedValue);
                int selectedNutrition = cmbNutrition.SelectedIndex == -1 ? 0 : Convert.ToInt32(cmbNutrition.SelectedValue);

                cmd.Parameters.AddWithValue("@RegDate", dtpRegDate.Value.Date);
                cmd.Parameters.AddWithValue("@BirthDate", dtpBirthDate.Value.Date);
                cmd.Parameters.AddWithValue("@FName", txtFName.Text);
                cmd.Parameters.AddWithValue("@LName", txtLName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Gender", cmbGender.Text);
                cmd.Parameters.AddWithValue("@PlanID", cmbPlan.SelectedValue);

                // Add the safe defaults here
                cmd.Parameters.AddWithValue("@TrainerID", selectedTrainer);
                cmd.Parameters.AddWithValue("@NutritionID", selectedNutrition);

                // ... (keep your con.Open() and ExecuteNonQuery() logic the same)

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Member added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewMembers();
                ClearFields();
            }
            catch (SqlException ex)
            {
                con.Close();

                if (ex.Number == 2627 || ex.Number == 2601)
                    MessageBox.Show("This email already exists", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMembers.CurrentRow == null)
            {
                MessageBox.Show("Please select a member first", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvMembers.CurrentRow.Cells["MemberID"].Value);

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this member?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.No)
                return;

            try
            {
                SqlCommand cmd1 = new SqlCommand("DELETE FROM SIGNUP WHERE M_ID=@id", con);
                cmd1.Parameters.AddWithValue("@id", id);

                SqlCommand cmd2 = new SqlCommand("DELETE FROM membr WHERE MemberID=@id", con);
                cmd2.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Member deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewMembers();
                ClearFields();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Delete error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void ClearFields()
        {
            txtFName.Clear();
            txtLName.Clear();
            txtEmail.Clear();

            cmbGender.SelectedIndex = -1;
            cmbTrainer.SelectedIndex = -1;
            cmbPlan.SelectedIndex = -1;
            cmbNutrition.SelectedIndex = -1;

            dtpRegDate.Value = DateTime.Today;
            dtpBirthDate.Value = DateTime.Today;

            selectedMemberID = -1;
        }

        void ApplyStyle()
        {
            this.Text = "Member Management";
            this.BackColor = Color.Black;

            dgvMembers.BackgroundColor = Color.Black;
            dgvMembers.BorderStyle = BorderStyle.None;
            dgvMembers.GridColor = Color.FromArgb(60, 60, 60);

            dgvMembers.DefaultCellStyle.BackColor = Color.Black;
            dgvMembers.DefaultCellStyle.ForeColor = Color.Goldenrod;
            dgvMembers.DefaultCellStyle.SelectionBackColor = Color.Goldenrod;
            dgvMembers.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvMembers.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            dgvMembers.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod;
            dgvMembers.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvMembers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvMembers.EnableHeadersVisualStyles = false;
            dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMembers.RowHeadersVisible = false;
            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembers.MultiSelect = false;
            dgvMembers.ReadOnly = true;
            dgvMembers.AllowUserToAddRows = false;

            StyleButton(btnAdd);
            StyleButton(btnView);
            StyleButton(btnClear);
            StyleButton(btnBack);

            btnDelete.BackColor = Color.DarkRed;
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            StyleTextBox(txtFName);
            StyleTextBox(txtLName);
            StyleTextBox(txtEmail);

            StyleComboBox(cmbGender);
            StyleComboBox(cmbTrainer);
            StyleComboBox(cmbPlan);
            StyleComboBox(cmbNutrition);

            label1.ForeColor = Color.Goldenrod;
            label2.ForeColor = Color.Goldenrod;
        }

        void StyleButton(Button btn)
        {
            btn.BackColor = Color.Goldenrod;
            btn.ForeColor = Color.Black;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Width = 100;
            btn.Height = 35;
        }

        void StyleTextBox(TextBox txt)
        {
            txt.BackColor = Color.FromArgb(25, 25, 25);
            txt.ForeColor = Color.Goldenrod;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        void StyleComboBox(ComboBox cmb)
        {
            cmb.BackColor = Color.FromArgb(25, 25, 25);
            cmb.ForeColor = Color.Goldenrod;
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        private void btnView_Click_1(object sender, EventArgs e)
        {
            ViewMembers();
        }
    }
}