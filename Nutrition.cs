using System;
using System.Data;
using System.Drawing;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace GymGUI
{
    public partial class Nutrition : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=GymMembership;Integrated Security=True;TrustServerCertificate=True");

        public Nutrition()
        {
            InitializeComponent();
            // Re-linking the event safely here or via designer
            dgvNutrition.CellClick += dgvNutrition_CellClick;
        }

        private void Nutrition_Load_1(object sender, EventArgs e)
        {
            ApplyStyle();
            LoadData();
        }

        void LoadData()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Nutrition", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvNutrition.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show("Error loading data: " + ex.Message); }
        }

        // --- FIXED SELECTION LOGIC ---
        private void dgvNutrition_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNutrition.Rows[e.RowIndex];
                txtNFname.Text = row.Cells["NFname"].Value.ToString();
                txtNLname.Text = row.Cells["NLname"].Value.ToString();
                txtNPN.Text = row.Cells["NPN"].Value.ToString();
            }
        }

        // --- FIXED DELETE LOGIC ---
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvNutrition.CurrentRow == null) return;

            int nId = Convert.ToInt32(dgvNutrition.CurrentRow.Cells["N_ID"].Value);

            if (nId == 0)
            {
                MessageBox.Show("Cannot delete the system 'No Nutritionist' record.", "Protected Record");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this nutritionist? Members will be set to 'No Nutritionist'.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.No) return;

            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();

                // STEP 1: Unassign the nutritionist from all members first
                SqlCommand cmdUpdate = new SqlCommand("UPDATE membr SET N_ID = 0 WHERE N_ID = @id", con);
                cmdUpdate.Parameters.AddWithValue("@id", nId);
                cmdUpdate.ExecuteNonQuery();

                // STEP 2: Now delete the nutritionist
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM Nutrition WHERE N_ID = @id", con);
                cmdDelete.Parameters.AddWithValue("@id", nId);
                cmdDelete.ExecuteNonQuery();

                MessageBox.Show("Nutritionist deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting nutritionist: " + ex.Message);
            }
            finally
            {
                con.Close();
                LoadData();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNFname.Text) || txtNFname.Text == "Enter Your First Name") return;

            try
            {
                if (con.State == ConnectionState.Open) con.Close();

                // Matches the Nutrition table structure in SQLQuery1.sql[cite: 1]
                SqlCommand cmd = new SqlCommand("INSERT INTO Nutrition (NFname, NLname, NPN) VALUES (@f, @l, @p)", con);
                cmd.Parameters.AddWithValue("@f", txtNFname.Text);
                cmd.Parameters.AddWithValue("@l", txtNLname.Text);
                cmd.Parameters.AddWithValue("@p", txtNPN.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            finally
            {
                con.Close();
                LoadData();
            }
        }

        private void btnBack_Click(object sender, EventArgs e) => this.Close();

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNFname.Clear();
            txtNLname.Clear();
            txtNPN.Clear();
        }

        private void btnViewFirstName_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Nutrition WHERE NFname LIKE @search";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                // Assuming your ComboBox is named cmbFirstName and allows typing
                da.SelectCommand.Parameters.AddWithValue("@search", "%" + cmbFirstName.Text + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvNutrition.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show("Search error: " + ex.Message); }
        }

        private void btnViewLastName_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Nutrition WHERE NLname LIKE @search";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@search", "%" + cmbLastName.Text + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvNutrition.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show("Search error: " + ex.Message); }
        }

        private void btnViewPhone_Click(object sender, EventArgs e)
        {
            try
            {
                // Using CAST to handle the NPN (nchar) field properly
                string query = "SELECT * FROM Nutrition WHERE CAST(NPN AS VARCHAR) LIKE @search";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@search", "%" + cmbPhone.Text + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvNutrition.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show("Search error: " + ex.Message); }
        }
        void ApplyStyle()
        {
            this.Text = "Nutritionist Management";
            this.BackColor = Color.Black;

            dgvNutrition.BackgroundColor = Color.Black;
            dgvNutrition.BorderStyle = BorderStyle.None;
            dgvNutrition.GridColor = Color.FromArgb(60, 60, 60);

            dgvNutrition.DefaultCellStyle.BackColor = Color.Black;
            dgvNutrition.DefaultCellStyle.ForeColor = Color.Goldenrod;
            dgvNutrition.DefaultCellStyle.SelectionBackColor = Color.Goldenrod;
            dgvNutrition.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvNutrition.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            dgvNutrition.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod;
            dgvNutrition.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvNutrition.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvNutrition.EnableHeadersVisualStyles = false;
            dgvNutrition.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNutrition.RowHeadersVisible = false;
            dgvNutrition.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNutrition.MultiSelect = false;
            dgvNutrition.ReadOnly = true;
            dgvNutrition.AllowUserToAddRows = false;

            StyleButton(btnAdd);
            StyleButton(btnViewAll);
            StyleButton(btnClear);
            StyleButton(btnBack);
            StyleButton(btnViewFirstName);
            StyleButton(btnViewLastName);
            StyleButton(btnViewPhone);

            btnDelete.BackColor = Color.DarkRed;
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            StyleTextBox(txtNFname);
            StyleTextBox(txtNLname);
            StyleTextBox(txtNPN);

            StyleComboBox(cmbFirstName);
            StyleComboBox(cmbLastName);
            StyleComboBox(cmbPhone);

            if (label1 != null) label1.ForeColor = Color.Goldenrod;
            if (label2 != null) label2.ForeColor = Color.Goldenrod;
            if (label3 != null) label3.ForeColor = Color.Goldenrod;
            if (label4 != null) label4.ForeColor = Color.Goldenrod;
            if (label5 != null) label5.ForeColor = Color.Goldenrod;
            if (label6 != null) label6.ForeColor = Color.Goldenrod;
        }

        void StyleButton(Button btn)
        {
            btn.BackColor = Color.Goldenrod;
            btn.ForeColor = Color.Black;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
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
    }
}